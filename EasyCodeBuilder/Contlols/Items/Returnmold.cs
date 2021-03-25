using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyCodeBuilder
{
    public partial class ReturnMold : StatementBase
    {
        string Type;
        public ReturnMold()
        {
            InitializeComponent();
        }

        private void ReturnMold_Load(object sender, EventArgs e)
        {
            comboBox3.Enabled = false;
        }

        private void ComboBox2_DropDown(object sender, EventArgs e)
        {
            List<String> vList=Util.GetVariableList(this, 0);
            this.comboBox2.Items.Clear();
            this.comboBox2.Items.AddRange(vList.ToArray());
        }

        private void ComboBox1_DropDown(object sender, EventArgs e)
        {
            List<String> vList = Util.GetVariableList(this, 0);
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.AddRange(vList.ToArray());
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = -1;
            comboBox3.Enabled = checkBox1.Checked;
        }
        private void ComboBox3_DropDown(object sender, EventArgs e)
        {
            List<String> vList1 = Util.GetVariableList(this, 4);
            this.comboBox3.Items.Clear();
            this.comboBox3.Items.AddRange(vList1.ToArray());
        }

        private void ComboBox2_DropDownClosed(object sender, EventArgs e)
        {
            Dictionary<string, string> CheckDic = Util.GetVariableType(this);
            if (comboBox2.SelectedIndex != -1)
            {
                Type = CheckDic[comboBox2.Text];
            }
            
        }
        public override string CodeOutput(int level)
        {
            List<string> vlist = Util.GetVariableList(this, 0);
            if (checkBox1.Checked)
            {
                if (vlist.Contains(comboBox1.Text)&&vlist.Contains(comboBox2.Text)&&vlist.Contains(comboBox3.Text))
                {

                }
            }
            else
            {
                if (vlist.Contains(comboBox1.Text) && vlist.Contains(comboBox2.Text))
                {

                }
            }
            string levelString = new string('\t', level);
            string Code = "";
            List<string> Vlist = Util.GetVariableList(this,0);
            if (comboBox1.SelectedIndex != -1)
            {
                if (comboBox2.SelectedIndex != -1)
                {
                    if (checkBox1.Checked)
                    {
                        if (comboBox3.SelectedIndex != -1)
                        {
                            if (Vlist.Contains(comboBox1.Text) && Vlist.Contains(comboBox2.Text) && Vlist.Contains(comboBox3.Text))
                            {
                                
                                Code = levelString + comboBox3.Text + " = " + Type + ".TryParse(" + comboBox1.Text +".ToString() "+ ",out " + comboBox2 + ";";
                                if (Util.VariableConfirmation(this).Contains(comboBox1.Text) == false)
                                {
                                    Form1.MessageBoxValue("型の変換で未割当の変数が使われています", true);
                                }
                            }
                            else
                            {
                                Form1.MessageBoxValue("未宣言の変数が使われています", true);
                            }
                        }
                        else
                        {
                            Form1.MessageBoxValue("bool型に変換結果を送る変数が選択されていません", true);
                        }
                    }
                    else
                    {
                        Code = levelString + Type + ".TryParse(" + comboBox1.Text+".ToString()" + ",out " + comboBox2.Text + ");\r\n";
                        
                    }
                }
                else
                {
                    Form1.MessageBoxValue("変数が選択されていません", true);
                }
            }
            else
            {
                Form1.MessageBoxValue("変数が選択されていません", true);
            }
            return Code;
            
        }
        public override Statement CreateProgramDefine()
        {
            XmlMold XmlM = new XmlMold();
            XmlM.InVariable = comboBox1.Text;
            XmlM.OutVariable = comboBox2.Text;
            XmlM.BooolVariable = comboBox3.Text;
            XmlM.BoolOnOf = checkBox1.Checked;
            return XmlM;
        }
        public override void ControlSetup(Statement name)
        {

            List<String> vList = Util.GetVariableList(this, 0);
            this.comboBox2.Items.Clear();
            this.comboBox2.Items.AddRange(vList.ToArray());
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.AddRange(vList.ToArray());
            List<String> vList1 = Util.GetVariableList(this, 4);
            this.comboBox3.Items.Clear();
            this.comboBox3.Items.AddRange(vList1.ToArray());

            XmlMold XmlM = (XmlMold)name;
            comboBox1.SelectedItem = XmlM.InVariable;
            comboBox2.SelectedItem = XmlM.OutVariable;
            if (XmlM.BoolOnOf)
            {
                checkBox1.Checked = XmlM.BoolOnOf;
                comboBox3.SelectedItem = XmlM.BooolVariable;
            }
            Dictionary<string, string> CheckDic = Util.GetVariableType(this);
            if (comboBox2.SelectedIndex != -1)
            {
                Type = CheckDic[comboBox2.Text];
            }

        }
        public override void ChangeName(string Aftername, string Beforename,bool type)
        {
            if (comboBox1.Text == Beforename)
            {
                List<String> vList = Util.GetVariableList(this, 0);
                this.comboBox1.Items.Clear();
                this.comboBox1.Items.AddRange(vList.ToArray());
                if (type)
                {
                    comboBox1.SelectedItem = Aftername;
                }
                else
                {
                    comboBox1.SelectedIndex = -1;
                }
            }
            if (comboBox2.Text == Beforename)
            {
                List<String> vList = Util.GetVariableList(this, 0);
                this.comboBox2.Items.Clear();
                this.comboBox2.Items.AddRange(vList.ToArray());
                if (type)
                {
                    comboBox2.SelectedItem = Aftername;
                }
                else
                {
                    comboBox2.SelectedIndex = -1;
                }
            }
            if (comboBox3.Text == Beforename)
            {
                List<String> vList = Util.GetVariableList(this, 0);
                this.comboBox3.Items.Clear();
                this.comboBox3.Items.AddRange(vList.ToArray());
                if (type)
                {
                    comboBox3.SelectedItem = Aftername;
                }
                else
                {
                    comboBox3.SelectedIndex = -1;
                }
            }

        }

       


    }
}
