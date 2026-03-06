using System;
using System.Windows.Forms;
using EasyCodeBuilder.Application.Interfaces;

namespace EasyCodeBuilder.Infrastructure.Services
{
    /// <summary>
    /// ファイルダイアログサービスの実装
    /// </summary>
    public class FileDialogService : IFileDialogService
    {
        public string GetSaveFilePath(IFileDialogService.SaveDialogType type)
        {
            string fileName = null;
            var sa = new SaveFileDialog
            {
                Title = "ファイルを保存する",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
            };

            switch (type)
            {
                case IFileDialogService.SaveDialogType.SourceCode:
                    sa.Filter = "C#ソースファイル(*.cs)|*.cs|テキストファイル(*.txt;*.text)|*.txt;*.text";
                    sa.FileName = @"Program.cs";
                    break;
                case IFileDialogService.SaveDialogType.Project:
                    sa.Filter = "保存ファイル形式(*.esycb)|*.esycb";
                    sa.FileName = @"Project.esycb";
                    break;
                case IFileDialogService.SaveDialogType.Executable:
                    sa.Filter = "実行ファイル(*.exe)|*.exe";
                    sa.FileName = @"Project.exe";
                    break;
            }

            sa.FilterIndex = 1;

            DialogResult result = sa.ShowDialog();

            if (result == DialogResult.OK)
            {
                fileName = sa.FileName;
            }

            return fileName;
        }

        public string GetOpenFilePath()
        {
            var ofd = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = "ESYCB保存ファイル(*.esycb) | *.esycb",
                Title = "開くファイルを選択してください",
                RestoreDirectory = true,
                CheckFileExists = true,
                CheckPathExists = true
            };

            string fileName = null;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = ofd.FileName;
            }

            return fileName;
        }
    }
}
