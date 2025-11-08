using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using BiuBiu.Services;
using BiuBiu.ViewModels;
using BiuBiu.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BiuBiu;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        #region DI
        //var serviceCollection = new ServiceCollection();

        //// 注册主窗口（在构建容器后再解析，这里先提供一个实例）
        //var mainWindow = new MainWindow();
        //serviceCollection.AddSingleton<Window>(mainWindow);

        //// 注册弹窗服务
        //serviceCollection.AddSingleton<IDialogService, AvaloniaDialogService>();

        // 注册其他服务和 ViewModel
        //serviceCollection.AddTransient<MainViewModel>();
        //serviceCollection.AddTransient<NameInputViewModel>();

        //Services = serviceCollection.BuildServiceProvider();
        #endregion

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}