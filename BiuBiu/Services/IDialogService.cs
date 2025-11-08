using BiuBiu.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiuBiu.Services
{
    public interface IDialogService
    {
        /// <summary>
        /// 显示一个确认对话框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="message">消息内容</param>
        /// <returns>如果用户点击了确认，则返回 true，否则返回 false</returns>
        Task<bool> ShowConfirmationDialogAsync(string title, string message);

        /// <summary>
        /// 显示一个自定义的弹窗
        /// </summary>
        /// <param name="viewModel">弹窗的 ViewModel</param>
        /// <returns>弹窗关闭时返回的结果</returns>
        Task<TResult> ShowCustomDialogAsync<TResult>(ViewModelBase viewModel);
    }

}
