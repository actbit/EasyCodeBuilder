using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyCodeBuilder
{
    public partial class Assignment : StatementBase
    {
        public Assignment()
        {
            InitializeComponent();
        }
        int Type = 0;
        private void ComboBox1_DropDown(object sender, EventArgs e)
        {
            List<string> vList = Util.GetVariableList(this, 0);
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(vList.ToArray());
        }

        private void ComboBox2_DropDown(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                Form1.MessageBoxValue("先に代入する変数を選択してください",false);
            }
            else
            {
                List<string> vList = Util.GetVariableList(this, Type);
                comboBox2.Items.Clear();
                comboBox2.Items.AddRange(vList.ToArray());
            }
        }

        private void ComboBox1_DropDownClosed(object sender, EventArgs e)
        {
            Dictionary<string, string> CheckDic = Util.GetVariableType(this);
            if (comboBox1.SelectedIndex!=-1)
            {
                switch (CheckDic[comboBox1.Text])
                {
                    case "":
                        break;
                    case "int":
                        Type = 10;
                        break;
                    case "string":
                        Type = 11;
                        break;
                    case "char":
                        Type = 12;
                        break;
                    case "double":
                        Type = 13;
                        break;
                    case "byte":
                        Type = 14;
                        break;
                    case "bool":
                        Type = 15;
                        break;
                }
            }
        }

        public override string CodeOutput(int level)
        {
            string Code="";
            string levelString = new string('\t', level);
            Dictionary<string, string> CheckDic = Util.GetVariableType(this);

            if (comboBox1.SelectedIndex != -1)
            {
                List<string> vList = Util.GetVariableList(this, 0);
                if (comboBox2.SelectedIndex != -1)
                {
                    
                    if (vList.Contains(comboBox1.Text) && vList.Contains(comboBox2.Text))
                    {
                        if (CheckDic[comboBox1.Text] == CheckDic[comboBox2.Text])
                        {
                            if (Util.VariableConfirmation(this).Contains(comboBox2.Text) == false)
                            {
                                Form1.MessageBoxValue("条件で使われている変数は未割当です", true);
                            }
                            Code = levelString + comboBox1.Text + " = " + comboBox2.Text + ";\r\n";
                        }
                        else
                        {
                            Form1.MessageBoxValue("型が異なります", true);

                        }
                    }
                    else
                    {
                        Form1.MessageBoxValue("未宣言の変数が使われています", true);
                    }

                }
                else
                {
                    if (checkBox1.Checked)
                    {
                        if (vList.Contains(comboBox1.Text))
                        {
                            if (CheckDic[comboBox1.Text] == "string")
                            {
                                Code = levelString + comboBox1.Text + " = \"" + comboBox2.Text + "\";\r\n";
                            }
                            else if (CheckDic[comboBox1.Text] == "char")
                            {
                                Code = levelString + comboBox1.Text + " = \'" + comboBox2.Text + "\';\r\n";
                            }
                            else
                            {
                                Code = levelString + comboBox1.Text + " = " + comboBox2.Text + ";\r\n";
                            }
                        }
                        else
                        {
                            Form1.MessageBoxValue("未宣言の変数が使われています", true);
                        }
                    }
                    else
                    {
                        Form1.MessageBoxValue("型が異なります", true);
                    }
                }
            }
            else
            {
                Form1.MessageBoxValue("代入される変数が入力されていません",true);
            }
            return Code;
        }
        public override Statement CreateProgramDefine()
        {
            XmlAssignment XmlAss = new XmlAssignment();
            XmlAss.TypeXml = Type;
            XmlAss.Variable1 = comboBox1.Text;
            XmlAss.Variable2 = comboBox2.Text;
            XmlAss.Constant = checkBox1.Checked;
            return XmlAss;
        }
        public override void ControlSetup(Statement name)
        {
            List<string> vList = Util.GetVariableList(this, 0);
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(vList.ToArray());
            XmlAssignment XmlAss = (XmlAssignment)name;
            comboBox1.SelectedItem = XmlAss.Variable1;
            checkBox1.Checked = XmlAss.Constant;
            Type = XmlAss.TypeXml;
            if (checkBox1.Checked)
            {
                List<string> vList1 = Util.GetVariableList(this, Type);
                comboBox2.Items.Clear();
                comboBox2.Items.AddRange(vList1.ToArray());
                comboBox2.SelectedItem = XmlAss.Variable2;
            }
            else
            {
                comboBox2.Text = XmlAss.Variable2;
            }

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                comboBox2.DropDownStyle = ComboBoxStyle.Simple;
            }
            else
            {
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            comboBox2.SelectedIndex = -1;
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
                    if(Beforename!="")
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
                    if (Beforename != "")
                    {
                        comboBox2.SelectedItem = Aftername;
                    }
                }
                else
                {
                    comboBox2.SelectedIndex = -1;
                }
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}