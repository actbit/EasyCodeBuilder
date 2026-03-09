using System.Windows.Forms;

namespace EasyCodeBuilder.Application.Interfaces
{
    /// <summary>
    /// メッセージボックス表示サービスのインターフェース
    /// </summary>
    public interface IMessageBoxService
    {
        /// <summary>
        /// エラーメッセージを表示し、コード生成状態を更新します
        /// </summary>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="isError">true: エラー, false: 警告</param>
        void ShowValidationError(string message, bool isError);

        /// <summary>
        /// 情報メッセージを表示します
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="title">タイトル</param>
        void ShowInformation(string message, string title);

        /// <summary>
        /// 警告メッセージを表示します
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="title">タイトル</param>
        void ShowWarning(string message, string title);

        /// <summary>
        /// エラーメッセージを表示します
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="title">タイトル</param>
        void ShowError(string message, string title);

        /// <summary>
        /// 確認ダイアログを表示します
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="title">タイトル</param>
        /// <returns>Yesの場合true</returns>
        bool ShowConfirmation(string message, string title);

        /// <summary>
        /// Yes/No/Cancelダイアログを表示します
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="title">タイトル</param>
        /// <returns>ダイアログ結果</returns>
        DialogResult ShowYesNoCancel(string message, string title);
    }
}
