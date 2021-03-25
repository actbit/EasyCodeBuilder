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
    public partial class Loop : StatementBase
    {
        
        int distanceY;
        int distanceX;
        string UseLoopType;
        string ConditionsType = "";
        public Loop()
        {
            InitializeComponent();
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            label3.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            textBox1.Visible = false;
        }
        public override void Sorting()
        {
            this.Height = this.statementBlock1.Top + this.statementBlock1.Height + distanceY;
            this.Width = this.statementBlock1.Left + this.statementBlock1.Width + distanceX;

            if (this.Parent is StatementBlock)
            {
                ((StatementBlock)this.Parent).Sorting();
            }
        }

        private void Loop_Load(object sender, EventArgs e)
        {
            distanceY = this.Height - (this.statementBlock1.Top + this.statementBlock1.Height);
            distanceX = this.Width - (this.statementBlock1.Left + this.statementBlock1.Width);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    LoopTypeIndex(true);
                    UseLoopType = ("while");
                    break;
                case 1:
                    LoopTypeIndex(true);
                    UseLoopType = ("do-while");
                    break;
                case 2:
                    LoopTypeIndex(false);
                    UseLoopType = ("for");
                    break;
            }

        }
        private void LoopTypeIndex(bool BoolType)
        {
            checkBox2.Visible = BoolType;
            comboBox2.Visible = BoolType;
            comboBox3.Visible = BoolType;
            comboBox4.Visible = BoolType;
            BoolType = !BoolType;
            label3.Visible = BoolType;
            checkBox1.Visible = BoolType;
            textBox1.Visible = BoolType;

        }
        private void ComboBox2_DropDown(object sender, EventArgs e)
        {
            List<String> vList = Util.GetVariableList(this, 0);
            this.comboBox2.Items.Clear();
            this.comboBox2.Items.AddRange(vList.ToArray());
        }

        private void ComboBox4_DropDown(object sender, EventArgs e)
        {
            List<String> vList = Util.GetVariableList(this, 0);
            this.comboBox4.Items.Clear();
            this.comboBox4.Items.AddRange(vList.ToArray());
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            CheckLetters.CheckNumbers(textBox1.Text,false);
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    ConditionsType = ("==");
                    break;
                case 1:
                    ConditionsType = ("!=");
                    break;
                case 2:
                    ConditionsType = ("<=");
                    break;
                case 3:
                    ConditionsType = (">=");
                    break;
                case 4:
                    ConditionsType = ("<");
                    break;
                case 5:
                    ConditionsType = (">");
                    break;

            }
        }

        public override string CodeOutput(int level)
        {
            string levelString = new string('\t', level);
            string childcontrol = this.statementBlock1.CodeOutput(level,true);
            string Code = "";
            string Quotation="";
            if (comboBox1.SelectedIndex != -1)
            {
                List<string> vlist = Util.GetVariableList(this, 0);

                if (UseLoopType == "while"|| UseLoopType == "do-while")
                {
                    if (ConditionsType != "")
                    {
                        if (comboBox2.SelectedIndex != -1)
                        {
                            if (checkBox2.Checked)
                            {

                                if (UseLoopType == "while")
                                {
                                    if (vlist.Contains(comboBox4.Text) == false)
                                    {
                                        CheckLetters.CheckVariables(comboBox2.Text, comboBox4.Text, Util.GetVariableType(this), true);
                                        if (Util.GetVariableType(this)[comboBox2.Text] == "char")
                                        {
                                            Quotation = "\'";
                                        }
                                        else if (Util.GetVariableType(this)[comboBox2.Text] == "string")
                                        {
                                            Quotation = "\"";
                                        }
                                    }
                                    else
                                    {
                                        Form1.MessageBoxValue("未宣言の変数が使われています", true);
                                    }

                                    Code = levelString + "while" + "(" + comboBox2.Text + " " + ConditionsType + Quotation + comboBox4.Text + Quotation + ")" + "\r\n" + childcontrol;
                                }
                                else
                                {
                                    if (vlist.Contains(comboBox2.Text) == false)
                                    {
                                        if (Util.GetVariableType(this)[comboBox2.Text] == "char")
                                        {
                                            Quotation = "\'";
                                        }
                                        else if (Util.GetVariableType(this)[comboBox2.Text] == "string")
                                        {
                                            Quotation = "\"";
                                        }
                                        CheckLetters.CheckVariables(comboBox2.Text, comboBox4.Text, Util.GetVariableType(this), true);
                                    }
                                    else
                                    {
                                        Form1.MessageBoxValue("未宣言の変数が使われています", true);
                                    }

                                    Code = levelString + "do\r\n" + childcontrol + levelString + "while(" + comboBox2.Text + " " + ConditionsType + " " + Quotation + comboBox4.Text + Quotation + ")\r\n";
                                }

                            }
                            else
                            {
                                if (Util.VariableConfirmation(this).Contains(comboBox2.Text)==false || Util.VariableConfirmation(this).Contains(comboBox4.Text)==false)
                                {
                                    Form1.MessageBoxValue("ループで未割当の変数が使われています", true);
                                }
                                
                                CheckLetters.CheckVariablesAndVariables(comboBox2.Text, comboBox4.Text, Util.GetVariableType(this), true);
                                Code = levelString + UseLoopType + "(" + comboBox2.Text + " " + ConditionsType + " " + comboBox4.Text + ")" + "\r\n" + childcontrol;
                            }


                        }
                        else
                        {
                            Form1.MessageBoxValue("条件の一部が入力されていません", true);
                        }
                    }
                    else
                    {
                        Form1.MessageBoxValue("条件が選択されていません", true);
                    }

                }
                else if (UseLoopType == "for")
                {
                    if (checkBox1.Checked == false)
                    {
                        int value;
                        if (int.TryParse(textBox1.Text, out value))
                        {
                            int i = 1;
                            Control MyGparent = this.Parent.Parent;
                        
                            while (MyGparent.GetType() == (typeof(Loop)))
                            { 
                                i++;
                                MyGparent = MyGparent.Parent.Parent;
                            }
                            string forNumber = new string ('i', i);
                            Code = levelString + UseLoopType + "(int "+ forNumber +"= 0;" + forNumber + " < " + textBox1.Text + ";"+forNumber+"++)\r\n" + childcontrol;
                        }        
                    }
                    else
                    {
                        Code = levelString + "for(;;)\r\n" + childcontrol;
                    }
                        
                }

            }
            else
            {
                Form1.MessageBoxValue("ループの種類が選択されていません",true);
            }       


            return Code;
        }

        private void ComboBox4_TextChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                Dictionary<string, string> TypeDictionary = Util.GetVariableType(this);
                CheckLetters.CheckVariables(comboBox2.Text, comboBox4.Text, TypeDictionary,false);
            }

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
        public override Statement CreateProgramDefine()
        {
            XmlLoop Loop = new XmlLoop();
            Loop.LoopType = comboBox1.SelectedIndex;
            Loop.WhileValue = comboBox2.Text;
            Loop.WhileValue2 = comboBox4.Text;
            Loop.WhileOperator = comboBox3.SelectedIndex;
            Loop.ForNumber = textBox1.Text;
            Loop.Constant = checkBox2.Checked;
            Loop.Infintite = checkBox1.Checked;
            Loop.Block = statementBlock1.CreateProgramDefine();
            return Loop;
        }
        public override void ControlSetup(Statement name)
        {
            XmlLoop LoopName = (XmlLoop)name;
            comboBox1.SelectedIndex = LoopName.LoopType;
            List<String> vList = Util.GetVariableList(this, 0);
            this.comboBox4.Items.Clear();
            this.comboBox4.Items.AddRange(vList.ToArray());
            this.comboBox2.Items.Clear();
            this.comboBox2.Items.AddRange(vList.ToArray());
            comboBox2.SelectedItem = LoopName.WhileValue;
            comboBox3.SelectedIndex = LoopName.WhileOperator;
            
            textBox1.Text = LoopName.ForNumber;
            checkBox1.Checked = LoopName.Infintite;

            checkBox2.Checked = LoopName.Constant;
            if (LoopName.Constant)
            {
                comboBox4.Text = LoopName.WhileValue2;
            }
            else
            {
                comboBox4.SelectedItem = LoopName.WhileValue2;
            }
            statementBlock1.Open(LoopName.Block);

        }
        public override void ChangeName(string Aftername, string Beforename,bool type)
        {
            if (comboBox2.Text == Beforename)
            {
                List<String> vList = Util.GetVariableList(this, 0);
                this.comboBox2.Items.Clear();
                this.comboBox2.Items.AddRange(vList.ToArray());
                if (type)
                {
                    if (string.IsNullOrEmpty(Beforename) == false)
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
                List<String> vList = Util.GetVariableList(this, 0);
                this.comboBox4.Items.Clear();
                this.comboBox4.Items.AddRange(vList.ToArray());
                if (type)
                {
                    if (string.IsNullOrEmpty(Beforename) == false)
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
