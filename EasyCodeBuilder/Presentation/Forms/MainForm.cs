using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using EasyCodeBuilder;
using EasyCodeBuilder.Application.Interfaces;
using EasyCodeBuilder.Core.Interfaces;
using EasyCodeBuilder.Infrastructure.Services;

namespace EasyCodeBuilder.Presentation.Forms
{
    /// <summary>
    /// メインフォーム - DI対応版
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly IMessageBoxService _messageBoxService;
        private readonly IFileDialogService _fileDialogService;
        private readonly IProjectPersistenceService _projectPersistenceService;
        private readonly ICompilerService _compilerService;
        private readonly IVariableService _variableService;

        private string _exePath;
        private string _fileName;
        private string _saveCode = "";
        private string _nowPath = "";
        private string _appPath;
        private string _code = "";

        public MainForm(
            IMessageBoxService messageBoxService,
            IFileDialogService fileDialogService,
            IProjectPersistenceService projectPersistenceService,
            ICompilerService compilerService,
            IVariableService variableService)
        {
            InitializeComponent();

            _messageBoxService = messageBoxService;
            _fileDialogService = fileDialogService;
            _projectPersistenceService = projectPersistenceService;
            _compilerService = compilerService;
            _variableService = variableService;
        }

        /// <summary>
        /// デザイナー用のパラメータなしコンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _appPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            _appPath = Path.Combine(_appPath, "一時ファイルEasyCodeBuilder");
            label4.Text = "";
            try
            {
                Directory.Delete(_appPath, true);
            }
            catch
            {
            }

            Directory.CreateDirectory(_appPath);
            DirectoryInfo di = new DirectoryInfo(_appPath);
            di.Attributes |= FileAttributes.Hidden;
        }

        private void StatementBlock_Load(object sender, EventArgs e)
        {
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            _fileName = _fileDialogService.GetSaveFilePath(IFileDialogService.SaveDialogType.Project);
            if (!string.IsNullOrEmpty(_fileName))
            {
                SaveXml(_fileName);
            }
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (statementBlock.ControlOrder.Count != 0)
            {
                if (_messageBoxService.ShowConfirmation("保存されていないファイルは消去されます消去してもよろしいですか", "警告"))
                {
                    statementBlock.RemoveAll();
                    _nowPath = "";
                    textBox1.Text = null;
                }
            }
            else
            {
                textBox1.Text = null;
            }
        }

        private void 新規作成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_messageBoxService.ShowConfirmation("保存されていないファイルは消去されます消去してもよろしいですか", "警告"))
            {
                statementBlock.RemoveAll();
                _nowPath = "";
            }
        }

        private void SaveXml(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                var programDefine = new ProgramDefine();
                programDefine.Block = this.statementBlock.CreateProgramDefine();
                _projectPersistenceService.SaveProject(fileName, programDefine);
            }
        }

        private string TextXml()
        {
            var programDefine = new ProgramDefine();
            programDefine.Block = this.statementBlock.CreateProgramDefine();
            return _projectPersistenceService.ToXmlString(programDefine);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _fileName = _fileDialogService.GetSaveFilePath(IFileDialogService.SaveDialogType.SourceCode);
            if (!string.IsNullOrEmpty(_fileName))
            {
                File.WriteAllText(_fileName, _saveCode, new UTF8Encoding(true));
            }
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            if (_nowPath == "")
            {
                _fileName = _fileDialogService.GetSaveFilePath(IFileDialogService.SaveDialogType.Project);
                if (!string.IsNullOrEmpty(_fileName))
                {
                    SaveXml(_fileName);
                    _nowPath = _fileName;
                }
                else
                {
                    _messageBoxService.ShowInformation("保存場所が選択されていないため保存できません", "");
                }
            }
            else
            {
                SaveXml(_nowPath);
            }
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            string fileName = _fileDialogService.GetOpenFilePath();
            label4.Text = "読み込み中";
            if (!string.IsNullOrEmpty(fileName))
            {
                OpenXml(fileName);
                _nowPath = fileName;
            }
            label4.Text = "";
        }

        int number = 0;
        private void OpenXml(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                var pd = _projectPersistenceService.LoadProject(fileName);

                int a = pd.Block.Statement.Count;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = a;
                progressBar1.Value = 0;
                statementBlock.Open(pd.Block);
                number = 0;
            }
        }

        public void AddBar(int addnumber)
        {
            number = number + addnumber;
            progressBar1.Value = number;
            if (number == progressBar1.Maximum)
            {
                progressBar1.Value = 0;
            }
        }

        private string OpenXmlstring(string fileName)
        {
            string textXml = "";
            if (!string.IsNullOrEmpty(fileName))
            {
                textXml = File.ReadAllText(fileName, Encoding.UTF8);
            }
            return textXml;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (statementBlock.ControlOrder.Count != 0)
            {
                if (_nowPath != "")
                {
                    string xmltext = TextXml();
                    string xmlsave = OpenXmlstring(_nowPath);
                    if (xmltext != xmlsave)
                    {
                        var dialog = _messageBoxService.ShowYesNoCancel("ファイルを上書き保存し閉じますか", "警告");
                        if (dialog == DialogResult.Yes)
                        {
                            SaveXml(_nowPath);
                        }
                        else if (dialog == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                        }
                    }
                }
                else
                {
                    string newpath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    if (File.Exists(Path.Combine(newpath, "Project.esycb")))
                    {
                        int i;
                        for (i = 1; ; i++)
                        {
                            if (!File.Exists(Path.Combine(newpath, "Project" + "(" + i + ").esycb")))
                            {
                                newpath = Path.Combine(newpath, "Project" + "(" + i + ").esycb");
                                break;
                            }
                        }
                    }
                    else
                    {
                        newpath = Path.Combine(newpath, "Project.esycb");
                    }
                    var dialog = _messageBoxService.ShowYesNoCancel(newpath + "に保存しますか", "警告");
                    if (dialog == DialogResult.Yes)
                    {
                        if (!string.IsNullOrEmpty(newpath))
                        {
                            SaveXml(newpath);
                        }
                    }
                    else if (dialog == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }

            _compilerService.TerminateRunningProcess();
        }

        private void 上書き保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_nowPath == "")
            {
                _messageBoxService.ShowInformation("保存場所が選択されていません", "お知らせ");
            }
            else
            {
                SaveXml(_nowPath);
            }
        }

        private void コード生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((MessageBoxService)_messageBoxService).CodeOk = true;
            _variableService.ClearSessionVariables();
            _saveCode = this.statementBlock.CodeOutput(1, true);
            _variableService.ClearSessionVariables();
            _saveCode = "using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\n\r\nclass Program\r\n{\r\n" + "\tstatic void Main(string[] args)\r\n" + _saveCode + "}\r\n";
            textBox1.Text = _saveCode.Replace("\t", "    ");
            if (!((MessageBoxService)_messageBoxService).CodeOk)
            {
                textBox1.Text = _code;
            }
            else
            {
                _code = _saveCode.Replace("\t", "    ");
            }
        }

        private void ToolStripButton6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                var result = MessageBox.Show("コードが生成されていませんが、白紙で保存しますか", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    _fileName = _fileDialogService.GetSaveFilePath(IFileDialogService.SaveDialogType.SourceCode);
                    if (!string.IsNullOrEmpty(_fileName))
                    {
                        File.WriteAllText(_fileName, _saveCode, new UTF8Encoding(true));
                    }
                }
            }
            else
            {
                _fileName = _fileDialogService.GetSaveFilePath(IFileDialogService.SaveDialogType.SourceCode);
                if (!string.IsNullOrEmpty(_fileName))
                {
                    File.WriteAllText(_fileName, _saveCode, new UTF8Encoding(true));
                }
            }
        }

        private void ToolStripButton7_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(_appPath))
            {
                Directory.CreateDirectory(_appPath);
            }

            _compilerService.TerminateRunningProcess();

            _variableService.ClearSessionVariables();
            string outString = "using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\n\r\nclass Program\r\n{\r\n" + "\tstatic void Main(string[] args)\r\n" + statementBlock.outCodeOutput() + "}\r\n";
            string newString = outString.Replace("\t\tConsole.Write(\"続行するには何かキーを押してください. . .\");\r\n\t\tConsole.ReadKey();\r\n", "");
            newString = newString.Replace("\t", "    ");

            if (textBox1.Text == newString)
            {
                ((MessageBoxService)_messageBoxService).CodeOk = true;
                var result = _compilerService.CompileAndRun(outString);

                if (result.Success)
                {
                    richTextBox1.Text = "正常に実行されました";
                }
                else
                {
                    richTextBox1.Text = result.ErrorMessage;
                }
            }
            else
            {
                _messageBoxService.ShowError("先にコードを生成してください", "実行時エラー");
            }
        }

        private void ToolStripButton8_Click_1(object sender, EventArgs e)
        {
            _variableService.ClearSessionVariables();

            string code = statementBlock.CodeOutput(1, true);
            code = "using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\n\r\nclass Program\r\n{\r\n" + "\tstatic void Main(string[] args)\r\n" + code + "}\r\n";

            code = code.Replace("\t", "    ");
            if (textBox1.Text != code)
            {
                _messageBoxService.ShowError("コードとコントロールが一致しません、コード生成してください", "エラー");
            }
            else
            {
                string locationFile = _fileDialogService.GetSaveFilePath(IFileDialogService.SaveDialogType.Executable);
                if (!string.IsNullOrEmpty(locationFile))
                {
                    if (((MessageBoxService)_messageBoxService).CodeOk)
                    {
                        var result = _compilerService.Compile(_code, locationFile);

                        if (result.Success)
                        {
                            richTextBox1.Text = "正常にコンパイルできました";
                        }
                        else
                        {
                            richTextBox1.Text = result.ErrorMessage;
                        }
                    }
                    else
                    {
                        _messageBoxService.ShowError("コードに問題があります", "エラー");
                    }
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Directory.Delete(_appPath, true);
            }
            catch
            {
            }
        }
    }
}
