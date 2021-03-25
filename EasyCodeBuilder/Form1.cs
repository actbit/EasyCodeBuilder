using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using System.Xml.Serialization;
using System.Reflection;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.CSharp;

namespace EasyCodeBuilder
{

    public partial class Form1 : Form
    {
        string ExePath;
        string fileName;
        string SaveCode = "";
        string NowPath = "";
        public static bool CodeOk;
        public static Form1 ThisForm;
        string appPath;
        Process Execution=null;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            appPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //appPath=Path.GetDirectoryName(appPath);
            appPath = Path.Combine(appPath, "一時ファイルEasyCodeBuilder");
            label4.Text = "";
            try
            {
                Directory.Delete(appPath, true);
            }
            catch
            {

            }

            Directory.CreateDirectory(appPath);
            DirectoryInfo di = new DirectoryInfo(appPath);
            di.Attributes |= FileAttributes.Hidden;

        }


        private void StatementBlock_Load(object sender, EventArgs e)
        {

        }
        public static void MessageBoxValue(string DisplayType, bool pattern)
        {
            if (pattern)
            {
                MessageBox.Show(DisplayType, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CodeOk = false;
            }
            else
            {
                MessageBox.Show(DisplayType, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            fileName = Destination(1);
            if (fileName != null && fileName != "")
            {
                SaveXml(fileName);
            }

        }


        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (statementBlock.ControlOrder.Count != 0)
            {
                DialogResult Dialog = MessageBox.Show("保存されていないファイルは消去されます消去してもよろしいですか", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (Dialog == DialogResult.Yes)
                {
                    statementBlock.RemoveAll();
                    NowPath = "";
                    textBox1.Text = null;
                }
                else if (Dialog == DialogResult.No)
                {

                }
            }
            else
            {
                textBox1.Text = null;
            }

        }
        private void 新規作成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult Dialog = MessageBox.Show("保存されていないファイルは消去されます消去してもよろしいですか", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (Dialog == DialogResult.Yes)
            {
                statementBlock.RemoveAll();
                NowPath = "";
            }
            else if (Dialog == DialogResult.No)
            {

            }
        }
        private string Destination(int type)
        {
            string fileName = null;
            //SaveFileDialogを生成する
            SaveFileDialog sa = new SaveFileDialog();
            sa.Title = "ファイルを保存する";
            sa.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            switch (type)
            {
                case 0:
                    sa.Filter = "C#ソースファイル(*.cs)|*.cs|テキストファイル(*.txt;*.text)|*.txt;*.text";
                    sa.FileName = @"Program.cs";
                    break;
                case 1:
                    sa.Filter = "保存ファイル形式(*.esycb)|*.esycb";
                    sa.FileName = @"Project.esycb";
                    break;
                case 3:
                    sa.Filter = "実行ファイル(*.exe)|*exe";
                    sa.FileName = @"Project.exe";
                    break;

            }

            sa.FilterIndex = 1;

            //オープンファイルダイアログを表示する
            DialogResult result = sa.ShowDialog();

            if (result == DialogResult.OK)
            {
                //「保存」ボタンが押された時の処理
                fileName = sa.FileName;  //こんな感じで指定されたファイルのパスが取得できる
                if (type == 1)
                {
                    NowPath = sa.FileName;
                }

            }
            return fileName;
        }

        private void SaveXml(String fileName)
        {
            if (fileName != null && fileName != "")
            {
                File.WriteAllText(fileName, TextXml(),Encoding.UTF8);
            }

        }

        private string TextXml()
        {
            string xmlStr = "";
            ProgramDefine pd = new ProgramDefine();
            pd.Block = this.statementBlock.CreateProgramDefine();
            using (StringWriter stream = new StringWriterUtf8())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ProgramDefine));
                serializer.Serialize(stream, pd);
                xmlStr = stream.ToString();
            }

            return xmlStr;
        }
        string code = "";


        private void Button1_Click(object sender, EventArgs e)
        {
            fileName = Destination(0);
            if (fileName != null && fileName != "")
            {
                StreamWriter sw = new StreamWriter(fileName, false, new UTF8Encoding(true));
                sw.Write(SaveCode);
                sw.Close();
            }

        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            if (NowPath == "")
            {
                fileName = Destination(1);
                if (fileName != null && fileName != "")
                {
                    SaveXml(fileName);
                }
                else
                {
                    MessageBox.Show("保存場所が選択されていないため保存できません", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                SaveXml(NowPath);
            }
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {

            string FileName = OpenFile();
            label4.Text = "読み込み中";
            if (FileName != "" && FileName != null)
            {

                OpenXml(FileName);
            }
            label4.Text = "";

        }
        int number = 0;
        private void OpenXml(String fileName)
        {
            if (fileName != "" && fileName != null)
            {
                ProgramDefine pd;
                using (FileStream stream = new FileStream(fileName, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ProgramDefine));
                    pd = (ProgramDefine)serializer.Deserialize(stream);
                }



                int a = pd.Block.Statement.Count();
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

        private string OpenXmlstring(String fileName)
        {
            string textXml = "";
            if (fileName != "" && fileName != null)
            {
                textXml = File.ReadAllText(fileName, System.Text.Encoding.UTF8);
            }
            return textXml;
        }
        private string OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            ofd.Filter = "ESYCB保存ファイル(*.esycb) | *.esycb";
            ofd.Title = "開くファイルを選択してください";
            ofd.RestoreDirectory = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            string fileName = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = ofd.FileName;
                NowPath = ofd.FileName;
            }

            return fileName;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (statementBlock.ControlOrder.Count != 0)
            {
                if (NowPath != "")
                {
                    string xmltext = TextXml();
                    //xmltext = xmltext.Replace(" encoding=\"utf-16\"", "");
                    string xmlsave = OpenXmlstring(NowPath);
                    if (xmltext != xmlsave)
                    {
                        DialogResult Dialog = MessageBox.Show("ファイルを上書き保存し閉じますか", "警告", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        if (Dialog == DialogResult.Yes)
                        {
                            SaveXml(NowPath);
                        }
                        else if (Dialog == DialogResult.No)
                        {

                        }
                        else if (Dialog == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                        }
                    }
                }
                else
                {
                    int i = 0;
                    string newpath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    if (File.Exists(Path.Combine(newpath, "Project.esycb")))
                    {
                        for (i = 1; ; i++)
                        {
                            if (File.Exists(Path.Combine(newpath, "Project" + "(" + i + ").esycb")) == false)
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
                    DialogResult Dialog = MessageBox.Show(newpath + "に保存しますか", "警告", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    if (Dialog == DialogResult.Yes)
                    {
                        if (newpath != null && newpath != "")
                        {
                            SaveXml(newpath);
                        }
                    }
                    else if (Dialog == DialogResult.No)
                    {

                    }
                    else if (Dialog == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }

            }
            if (Execution != null)
            {
                if (Execution.HasExited == false)
                {
                    Execution.Kill();
                    Execution.Close();
                    Execution.Dispose();
                }
            }


        }

        private void 上書き保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NowPath == "")
            {
                MessageBox.Show("保存場所が選択されていません", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SaveXml(NowPath);
            }
        }




        private void コード生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeOk = true;
            VariableDefine.NameList.Clear();
            SaveCode = this.statementBlock.CodeOutput(1, true);
            VariableDefine.NameList.Clear();
            SaveCode = "using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\n\r\nclass Program\r\n{\r\n" + "\tstatic void Main(string[] args)\r\n" + SaveCode + "}\r\n";
            textBox1.Text = SaveCode.Replace("\t", "    ");
            if (CodeOk == false)
            {
                textBox1.Text = code;
            }
            else
            {
                code = SaveCode.Replace("\t", "    ");
            }

        }

        private void ToolStripButton6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                DialogResult result = MessageBox.Show("コードが生成されていませんが、白紙で保存しますか", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    fileName = Destination(0);
                    if (fileName != null && fileName != "")
                    {

                        StreamWriter sw = new StreamWriter(fileName, false, new UTF8Encoding(true));
                        sw.Write(SaveCode);
                        sw.Close();
                    }
                }
                else
                {

                }
            }
            else
            {
                fileName = Destination(0);
                if (fileName != null && fileName != "")
                {

                    StreamWriter sw = new StreamWriter(fileName, false, new UTF8Encoding(true));
                    sw.Write(SaveCode);
                    sw.Close();
                }
            }
        }

        

        private void ToolStripButton7_Click(object sender, EventArgs e)
        {
            if (File.Exists(appPath)==false)
            {
                Directory.CreateDirectory(appPath);
            }
            if (Execution != null)
            {
                try
                {
                    Execution.Kill();
                    Execution.Close();
                    Execution.Dispose();
                }
                catch
                {

                }
                
            }
            

            VariableDefine.NameList.Clear();
            string OutString = "using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\n\r\nclass Program\r\n{\r\n" + "\tstatic void Main(string[] args)\r\n" + statementBlock.outCodeOutput() + "}\r\n";
            string NewString = OutString.Replace("\t\tConsole.Write(\"続行するには何かキーを押してください. . .\");\r\n\t\tConsole.ReadKey();\r\n", "");
            NewString = NewString.Replace("\t", "    ");


            if (textBox1.Text == NewString)
            {
                int ii = 0;
                String exeName = Path.Combine(appPath, "Program.exe");
                while (File.Exists(exeName))
                {
                    ii++;
                    exeName = Path.Combine(appPath, "Program[" + ii + "].exe");
                }
                

                ExePath = exeName;

                CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

                CompilerParameters cp = new CompilerParameters();

                // クラスライブラリの代わりに実行可能ファイルを生成します。
                cp.GenerateExecutable = true;

                cp.OutputAssembly = exeName;

                // アセンブリを物理ファイルとして保存します。
                cp.GenerateInMemory = false;

                // すべての警告をエラーとして扱うかどうかを設定します。
                cp.TreatWarningsAsErrors = false;


                //コンソール場面の表示　非表示
                cp.CompilerOptions = "/optimize";

                //cp.CompilerOptions = "/optimize";

                cp.ReferencedAssemblies.Add("System.dll");
                cp.ReferencedAssemblies.Add("System.Threading.Tasks.dll");
                cp.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                cp.ReferencedAssemblies.Add("System.Windows.dll");
                cp.ReferencedAssemblies.Add("System.Linq.dll");
                cp.ReferencedAssemblies.Add("System.Drawing.dll");
                cp.ReferencedAssemblies.Add("System.Core.dll");
                cp.ReferencedAssemblies.Add("System.Xml.dll");
                cp.ReferencedAssemblies.Add("System.Xml.Linq.dll");
                cp.ReferencedAssemblies.Add("System.Data.DataSetExtensions.dll");
                cp.ReferencedAssemblies.Add("System.Data.dll");



                CompilerResults cr = provider.CompileAssemblyFromSource(cp, OutString);

                
                // ソースファイルのコンパイルを呼び出します。

                if (cr.Errors.Count > 0)
                {
                    // コンパイルエラーを表示します。

                    foreach (CompilerError ce in cr.Errors)
                    {
                        richTextBox1.Text = ce.ToString() + "\n";

                    }
                }
                else
                {
                    // 正常なコンパイルメッセージを表示します。
                    richTextBox1.Text = "正常に実行されました";
                    Execution = Process.Start(ExePath);
                    Execution.EnableRaisingEvents = true;
                    Execution.Exited += new EventHandler(this_Exited);
                }
            }
            else
            {
                MessageBox.Show("先にコードを生成してください","実行時エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void this_Exited(object sender, EventArgs e)
        {
            File.Delete(ExePath);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            try
            {
                Directory.Delete(appPath, true);
            }
            catch
            {

            }
        }

        private void ToolStripButton8_Click_1(object sender, EventArgs e)
        {


            VariableDefine.NameList.Clear();

            string Code = statementBlock.CodeOutput(1, true);
            Code = "using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\n\r\nclass Program\r\n{\r\n" + "\tstatic void Main(string[] args)\r\n" + Code + "}\r\n";

            Code = Code.Replace("\t", "    ");
            if (textBox1.Text != Code)
            {
                MessageBox.Show("コードとコントロールが一致しません、コード生成してください","エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {

                string locationFile = Destination(3);
                if (locationFile != null)
                {
                    if (CodeOk == true)
                    { 
                        CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

                        CompilerParameters cp = new CompilerParameters();

                        // クラスライブラリの代わりに実行可能ファイルを生成します。
                        cp.GenerateExecutable = true;

                        cp.OutputAssembly = locationFile;

                        // アセンブリを物理ファイルとして保存します。
                        cp.GenerateInMemory = false;

                        // すべての警告をエラーとして扱うかどうかを設定します。
                        cp.TreatWarningsAsErrors = false;

                        cp.OutputAssembly = locationFile;

                        //コンソール場面の表示　非表示
                        cp.CompilerOptions = "/optimize";

                        //cp.CompilerOptions = "/optimize";

                        cp.ReferencedAssemblies.Add("System.dll");
                        cp.ReferencedAssemblies.Add("System.Threading.Tasks.dll");
                        cp.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                        cp.ReferencedAssemblies.Add("System.Windows.dll");
                        cp.ReferencedAssemblies.Add("System.Linq.dll");
                        cp.ReferencedAssemblies.Add("System.Drawing.dll");
                        cp.ReferencedAssemblies.Add("System.Core.dll");
                        cp.ReferencedAssemblies.Add("System.Xml.dll");
                        cp.ReferencedAssemblies.Add("System.Xml.Linq.dll");
                        cp.ReferencedAssemblies.Add("System.Data.DataSetExtensions.dll");
                        cp.ReferencedAssemblies.Add("System.Data.dll");



                        CompilerResults cr = provider.CompileAssemblyFromSource(cp,code);

                        // ソースファイルのコンパイルを呼び出します。

                        if (cr.Errors.Count > 0)
                        {
                            // コンパイルエラーを表示します。

                            foreach (CompilerError ce in cr.Errors)
                            {
                                richTextBox1.Text = ce.ToString() + "\n";

                            }
                        }
                        else
                        {
                            // 正常なコンパイルメッセージを表示します。
                            richTextBox1.Text = "正常にコンパイルできました";

                        }


                    }
                    else
                    {
                        MessageBox.Show("コードに問題があります", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }    
            }
        }

    }
}
