using Avalonia.Controls;
using BiuBiu.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiuBiu.Services
{
    public class AvaloniaDialogService : IDialogService
    {
        // 为了正确显示模态对话框，我们需要一个主窗口的引用
        private readonly Window _mainWindow;

        public AvaloniaDialogService(Window mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public async Task<bool> ShowConfirmationDialogAsync(string title, string message)
        {
            //var result = await MessageBox.Show(
            //    _mainWindow,
            //    message,
            //    title,
            //    MessageBoxButton.YesNo,
            //    MessageBoxImage.Question
            //);

            //return result == MessageBoxResult.Yes;
            throw new InvalidOperationException();    
        }

        public async Task<TResult> ShowCustomDialogAsync<TResult>(ViewModelBase viewModel)
        {
            // 这里可以使用一个约定：View 的名称和 ViewModel 的名称对应
            // 例如，MyDialogViewModel 对应 MyDialog
            string viewName = viewModel.GetType().Name.Replace("ViewModel", "");
            Type? viewType = Type.GetType($"YourAppName.Avalonia.Views.{viewName}");

            if (viewType == null)
            {
                throw new ArgumentException($"找不到与 ViewModel '{viewModel.GetType().Name}' 对应的 View。");
            }

            // 创建 View 实例
            Window? dialogWindow = (Window)Activator.CreateInstance(viewType);

            // 将 ViewModel 设置为 View 的 DataContext
            dialogWindow?.DataContext = viewModel;

            // 设置弹窗的所有者，确保它是模态的
            //dialogWindow.Owner = _mainWindow;
            dialogWindow?.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            // 显示弹窗并等待结果
            var result = await dialogWindow?.ShowDialog<TResult>(_mainWindow);

            return result;
        }
    }
}
