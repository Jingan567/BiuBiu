using BiuBiu.Views;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BiuBiu.ViewModels
{
    internal partial class MainViewModel : ViewModelBase
    {
        [RelayCommand]
        public void Start()
        {
            for (int i = 0; i < 100; i++)
            {
                var control = new MessageView();
                
            }
        }
    }
}
