using System.Windows.Forms;
using EasyCodeBuilder.Application.Interfaces;

namespace EasyCodeBuilder.Infrastructure.Services
{
    /// <summary>
    /// メッセージボックス表示サービスの実装
    /// </summary>
    public class MessageBoxService : IMessageBoxService
    {
        private bool _codeOk = true;

        /// <summary>
        /// 現在のコード生成状態を取得・設定します
        /// </summary>
        public bool CodeOk
        {
            get => _codeOk;
            set => _codeOk = value;
        }

        public void ShowValidationError(string message, bool isError)
        {
            if (isError)
            {
                MessageBox.Show(message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _codeOk = false;
            }
            else
            {
                MessageBox.Show(message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ShowInformation(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool ShowConfirmation(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }

        public DialogResult ShowYesNoCancel(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }
    }
}
