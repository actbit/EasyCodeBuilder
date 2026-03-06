using System.Windows.Forms;

namespace EasyCodeBuilder.Application.Interfaces
{
    /// <summary>
    /// ファイルダイアログサービスのインターフェース
    /// </summary>
    public interface IFileDialogService
    {
        /// <summary>
        /// 保存ダイアログの種類
        /// </summary>
        enum SaveDialogType
        {
            SourceCode = 0,
            Project = 1,
            Executable = 3
        }

        /// <summary>
        /// 保存ファイルパスを取得します
        /// </summary>
        /// <param name="type">ダイアログタイプ</param>
        /// <returns>選択されたファイルパス (キャンセル時はnull)</returns>
        string GetSaveFilePath(SaveDialogType type);

        /// <summary>
        /// 開くファイルパスを取得します
        /// </summary>
        /// <returns>選択されたファイルパス (キャンセル時はnull)</returns>
        string GetOpenFilePath();
    }
}
