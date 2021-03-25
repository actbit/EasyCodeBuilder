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
    public partial class Calculation : StatementBase
    {
        public Calculation()
        {
            InitializeComponent();
        }
        string CalculationType="";


        private void ComboBox1_DropDown(object sender, EventArgs e)
        {
            List<String> vList = Util.GetVariableList(this, 1);
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.AddRange(vList.ToArray());
        }

        private void ComboBox4_DropDown(object sender, EventArgs e)
        {
            List<String> vList = Util.GetVariableList(this, 1);
            this.comboBox4.Items.Clear();
            this.comboBox4.Items.AddRange(vList.ToArray());
        }

        private void ComboBox2_DropDown(object sender, EventArgs e)
        {
            List<String> vList = Util.GetVariableList(this, 1);
            this.comboBox2.Items.Clear();
            this.comboBox2.Items.AddRange(vList.ToArray());
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

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                comboBox4.DropDownStyle = ComboBoxStyle.Simple;
            }
            else
            {
                comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            comboBox4.SelectedIndex = -1;

        }

        private void ComboBox2_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                CheckLetters.CheckNumbers(comboBox2.Text,false);
            }
        }

        private void ComboBox4_TextChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                CheckLetters.CheckNumbers(comboBox4.Text,false);
            }
        }

        public override string CodeOutput(int level)
        {
            string levelString = new string('\t', level);
            string Code=levelString;
            List<string> vList = Util.GetVariableList(this, 1);
            if (comboBox1.SelectedIndex!=-1)
            {
                Code = Code + comboBox1.Text;
                if (checkBox1.Checked)
                {
                    if (string.IsNullOrWhiteSpace(comboBox2.Text))
                    {
                        Form1.MessageBoxValue("計算するときの数が選択されていません", true);
                    }
                    else
                    {

                        Code = Code + " = " + comboBox2.Text;
                    }
                }
                else
                {
                    if (vList.Contains(comboBox2.Text))
                    {
                        if (comboBox2.SelectedIndex != -1)
                        {
                            if (Util.VariableConfirmation(this).Contains(comboBox2.Text) == false)
                            {
                                Form1.MessageBoxValue("計算で未割当の変数が使われています", true);
                            }
                            Code = Code + " = " + comboBox2.Text;
                        }
                        else
                        {
                            Form1.MessageBoxValue("計算するときの変数が選択されていません", true);
                        }
                    }
                    else
                    {
                        Form1.MessageBoxValue("未宣言の変数が使われています",true);
                    }

                }

                if (checkBox2.Checked)
                {
                    if (string.IsNullOrWhiteSpace(comboBox4.Text))
                    {
                        Form1.MessageBoxValue("計算するときの数が選択されていません", true);

                    }
                    else
                    {
                        if (comboBox3.SelectedIndex != -1)
                        {
                            Code = Code + " " + CalculationType + " " + comboBox4.Text+";\r\n";
                        }
                    }
                }
                else
                {
                    if (vList.Contains(comboBox4.Text))
                    {
                        if (comboBox4.SelectedIndex != -1)
                        {
                            if (comboBox3.SelectedIndex != -1)
                            {
                                if (Util.VariableConfirmation(this).Contains(comboBox4.Text) == false)
                                {
                                    Form1.MessageBoxValue("計算で未割当の変数が使われています", true);
                                }

                                Code = Code + " " + CalculationType + " " + comboBox4.Text + ";\r\n";
                            }
                        }
                        else
                        {
                            Form1.MessageBoxValue("計算するときの変数が選択されていません", true);
                        }
                    }
                    else
                    {
                        Form1.MessageBoxValue("未宣言の変数が使われています",true);
                    }
                }

            }
            else
            {
                Form1.MessageBoxValue("計算するときの数が選択されていません", true);
            }

            Dictionary<string, string> typeDic = Util.GetVariableType(this);
            if (checkBox1.Checked == false)
            {
                if (checkBox2.Checked == false)
                {
                    if (typeDic[comboBox1.Text] == typeDic[comboBox2.Text] && typeDic[comboBox1.Text] == typeDic[comboBox4.Text])
                    {

                    }
                    else
                    {
                        Form1.MessageBoxValue("型が異なります", true);
                    }
                }
                else
                {
                    if (typeDic[comboBox1.Text] == typeDic[comboBox2.Text])
                    {

                    }
                    else
                    {
                        Form1.MessageBoxValue("型が異なります", true);
                    }
                }
            }
            else
            {
                if (typeDic[comboBox1.Text] == typeDic[comboBox4.Text])
                {

                }
                else
                {
                    Form1.MessageBoxValue("型が異なります", true);
                }
            }
            
            
            return Code;
        }
        public override Statement CreateProgramDefine()
        {
            XmlCalculation XCal = new XmlCalculation();
            XCal.Variable = comboBox1.Text;
            XCal.Variable2 = comboBox2.Text;
            XCal.Variable3 = comboBox4.Text;
            XCal.Type = comboBox3.SelectedIndex;
            XCal.constant1 = checkBox1.Checked;
            XCal.constant2 = checkBox2.Checked;
            return XCal;
        }
        public override void ControlSetup(Statement name)
        {
            XmlCalculation XCal = (XmlCalculation)name;
            List<string> vList = Util.GetVariableList(this,1);
            comboBox1.Items.AddRange(vList.ToArray());
            comboBox2.Items.AddRange(vList.ToArray());
            comboBox4.Items.AddRange(vList.ToArray());
            comboBox1.SelectedItem = XCal.Variable;
            if (XCal.constant1)
            {
                comboBox2.DropDownStyle = ComboBoxStyle.Simple;
                comboBox2.Text = XCal.Variable2;
                
            }
            else
            {
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox2.SelectedItem = XCal.Variable2;
            }
            if (XCal.constant2)
            {
                comboBox4.DropDownStyle = ComboBoxStyle.Simple;
                comboBox4.Text = XCal.Variable3;
            }
            else
            {
                comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox4.SelectedItem = XCal.Variable3;
            }
            checkBox1.Checked = XCal.constant1;
            checkBox2.Checked = XCal.constant2;
            comboBox3.SelectedIndex = XCal.Type;
            return ;
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox3.SelectedIndex)
            {
                case -1:
                    CalculationType = "";
                    break;
                case 0:
                    CalculationType = "+";
                    break;
                case 1:
                    CalculationType = "-";
                    break;
                case 2:
                    CalculationType = "*";
                    break;
                case 3:
                    CalculationType = "/";
                    break;
            }
        }
        public override void ChangeName(string Aftername, string Beforename, bool type)
        {
            if (comboBox1.Text == Beforename)
            {
                List<String> vList = Util.GetVariableList(this, 1);
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
                List<String> vList = Util.GetVariableList(this, 1);
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
            if (comboBox4.Text == Beforename)
            {
                List<String> vList = Util.GetVariableList(this, 1);
                this.comboBox4.Items.Clear();
                this.comboBox4.Items.AddRange(vList.ToArray());
                if (type)
                {
                    if (Beforename != "")
                    {
                        comboBox4.SelectedItem = Aftername;
                    }
                    
                }
                else
                {
                    comboBox4.SelectedIndex = -1;
                }
            }
        }
    }

}
