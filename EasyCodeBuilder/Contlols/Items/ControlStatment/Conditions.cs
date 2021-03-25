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
    public partial class Conditions : StatementBase
    {

        int distanceX;

        string ConditionsType;

        public Conditions()
        {
            InitializeComponent();
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            label3.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            label4.Visible = false;
        }
        public override void Sorting()
        {
            if(checkBox2.Checked)
            {
                statementBlock2.Location = new Point(6,statementBlock1.Bottom + 16);
                label4.Location = new Point(6, statementBlock1.Bottom + 3);
                this.Height = 65 + this.statementBlock1.Height +6+this.statementBlock2.Height+18;
                if (statementBlock2.Width < statementBlock1.Width)
                {
                    this.Width = statementBlock1.Width + distanceX;
                }
                else
                {
                    this.Width = statementBlock2.Width + distanceX;
                }
                
            }
            else
            {
                this.Height = this.statementBlock1.Top +71;
                this.Width = this.statementBlock1.Left + this.statementBlock1.Width + distanceX;
            }
            //statementBlock2.Location = new Point(6,statementBlock1.Bottom + distanceX1);

            //this.Height = this.statementBlock2.Top + this.statementBlock1.Height + distanceY1;
            //this.Width = this.statementBlock2.Left + this.statementBlock1.Width + distanceX1;
            if (this.Parent is StatementBlock)
            {
                ((StatementBlock)this.Parent).Sorting();
            }
        }

        private void Conditions_Load(object sender, EventArgs e)
        {

            distanceX = this.Width - (this.statementBlock1.Left + this.statementBlock1.Width);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    checkBox2.Visible = true;
                    comboBox2.Visible = true;
                    comboBox3.Visible = true;
                    comboBox4.Visible = true;
                    label3.Visible = true;
                    checkBox1.Visible = true;
                    comboBox2.Location = new Point(6,35);
                    //statementBlock1.Size = new Size(400,110);
                    //statementBlock1.MinimumSize = new Size(400, 110);
                    checkBox2.Checked = false;
                    statementBlock1.RemoveAll();
                    statementBlock2.RemoveAll();
                    Sorting();
                    break;
                case 1:
                    
                    checkBox2.Visible = false;
                    comboBox2.Visible = true;
                    comboBox3.Visible = false;
                    comboBox4.Visible = false;
                    checkBox1.Visible = false;
                    label3.Visible = true;
                    //statementBlock1.MinimumSize = new Size(400, 129);
                    comboBox2.Location = new Point(90, 35);
                    checkBox2.Checked = false;
                    statementBlock1.RemoveAll();
                    statementBlock2.RemoveAll();
                    Sorting();
                    break;
            }
        }
        private void ComboBox2_DropDown(object sender, EventArgs e)
        {
            List<string> vList = Util.GetVariableList(this, 0);
            this.comboBox2.Items.Clear();
            this.comboBox2.Items.AddRange(vList.ToArray());
        }
        private void ComboBox4_DropDown(object sender, EventArgs e)
        {
            List<string> vList = Util.GetVariableList(this, 0);
            this.comboBox4.Items.Clear();
            this.comboBox4.Items.AddRange(vList.ToArray());
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


        private void ComboBox4_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Dictionary<string, string> TypeDictionary = Util.GetVariableType(this);
                CheckLetters.CheckVariables(comboBox2.Text,comboBox4.Text,TypeDictionary,false);
            }
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, string> TypeDictionary = Util.GetVariableType(this);
            if (string.IsNullOrWhiteSpace(comboBox4.Text) == false)
            {
                if (string.IsNullOrWhiteSpace(comboBox2.Text) == false)
                {
                    List<string> vList = Util.GetVariableList(this, 0);
                    if (vList.Contains(comboBox2.Text) == false || vList.Contains(comboBox4.Text) == false)
                    {
                        Form1.MessageBoxValue("未宣言の変数が使われています", true);
                    }
                    else
                    {
                        CheckLetters.CheckVariablesAndVariables(comboBox2.Text, comboBox4.Text, TypeDictionary,false);
                    }


                }
            }
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox4.DropDownStyle = ComboBoxStyle.Simple;
            }
            else
            {
                comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            comboBox4.SelectedIndex = -1;
        }
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, string> TypeDictionary = Util.GetVariableType(this);
            if (string.IsNullOrWhiteSpace(comboBox4.Text) == false)
            {
                if (string.IsNullOrWhiteSpace(comboBox2.Text) == false)
                {

                    List<string> vList = Util.GetVariableList(this, 0);
                    if (vList.Contains(comboBox2.Text) == false || vList.Contains(comboBox4.Text) == false)
                    {
                        
                    }
                    else
                    {
                        CheckLetters.CheckVariablesAndVariables(comboBox2.Text, comboBox4.Text, TypeDictionary,false);
                    }

                }
            }
        }
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {

                statementBlock2.Visible = true;
                label4.Visible = true;

                Sorting();
            }
            else
            {
                statementBlock2.Visible = false;
                label4.Visible = false;
                statementBlock2.Location = new Point(6, 64);
                Sorting();
            }
        }
        public override string CodeOutput(int level)
        {
            string CodeOutput="";
            string childcontrol = this.statementBlock1.CodeOutput(level,true);
            string childcontrol2 = this.statementBlock2.CodeOutput(level,true);
            string levelString = new string('\t', level);

            Dictionary<string, string> TypeDictionary = Util.GetVariableType(this);
            string value;
            if (comboBox1.SelectedIndex == 0)
            {
                List<string> vList = Util.GetVariableList(this, 0);
                if (comboBox2.SelectedIndex==-1)
                {
                    Form1.MessageBoxValue("条件の変数又は定数が入力されていません",true);
                }
                else if (comboBox3.SelectedIndex == -1)
                {
                    Form1.MessageBoxValue("条件が正しくありません",true);
                }
                else if (vList.Contains(comboBox1.Text))
                {
                    Form1.MessageBoxValue("未宣言の変数が使われています",true);
                }
                else
                {
                    
                    
                    if (checkBox1.Checked)
                    {
                        CheckLetters.CheckVariables(comboBox2.Text, comboBox4.Text, TypeDictionary,true);
                        if (TypeDictionary[comboBox2.Text] == "char")
                        {
                            value = "\'" + comboBox4.Text + "\'";
                        }
                        else if(TypeDictionary[comboBox2.Text] == "string")
                        {
                            value = "\"" + comboBox4.Text + "\"";
                        }
                        else
                        {
                            value = comboBox4.Text;
                        }


                    }
                    else
                    {
                        if (Util.VariableConfirmation(this).Contains(comboBox2.Text)==false || Util.VariableConfirmation(this).Contains(comboBox4.Text)==false)
                        {
                            Form1.MessageBoxValue("条件で使われている変数は未割当です",true);
                        }
                        if (string.IsNullOrWhiteSpace(comboBox4.Text) == true)
                        {
                            Form1.MessageBoxValue("条件の変数が入力されていません", true);

                        }
                        else
                        {
                            CheckLetters.CheckVariablesAndVariables(comboBox2.Text, comboBox4.Text, TypeDictionary, true);
                        }
                        value = comboBox4.Text;
                    }

                    if (checkBox2.Checked)
                    {
                        CodeOutput = levelString + "if(" + comboBox2.Text + ConditionsType + value + ")\r\n" + childcontrol + levelString + "else\r\n" + childcontrol2;
                    }
                    else
                    {
                        CodeOutput = levelString + "if(" + comboBox2.Text + ConditionsType + value + ")\r\n" + childcontrol;
                    }
                    
                }


            }
            else if(comboBox1.SelectedIndex==1)
            {
                if(comboBox2.SelectedIndex == -1)
                {
                    Form1.MessageBoxValue("変数が入力されていません",true);
                }
                else
                {
                    if (Util.VariableConfirmation(this).Contains(comboBox2.Text)==false)
                    {
                        Form1.MessageBoxValue("条件で使われている変数は未割当です", true);
                    }
                    CodeOutput = levelString + "switch(" + comboBox2.Text + ")\r\n" + childcontrol;
                }
                
            }


            return CodeOutput;
        }
        public override Statement CreateProgramDefine()
        {
            XmlCondition Condition = new XmlCondition();
            Condition.ConditionType = comboBox1.SelectedIndex;
            Condition.Value1 = comboBox2.Text;
            Condition.Value2 = comboBox4.Text;
            Condition.UseElse = checkBox1.Checked;
            Condition.Constant = checkBox2.Checked;
            Condition.Opreater = comboBox3.SelectedIndex;
            Condition.Block1 = statementBlock1.CreateProgramDefine();
            Condition.Block2 = statementBlock2.CreateProgramDefine();
            return Condition;
        }
        public override void ControlSetup(Statement name)
        {
            List<string> vList = Util.GetVariableList(this, 0);
            this.comboBox4.Items.Clear();
            this.comboBox4.Items.AddRange(vList.ToArray());
            this.comboBox2.Items.Clear();
            this.comboBox2.Items.AddRange(vList.ToArray());
            XmlCondition ConName = (XmlCondition)name;
            comboBox1.SelectedIndex = ConName.ConditionType;
            comboBox2.SelectedItem = ConName.Value1;
            statementBlock1.Open(ConName.Block1);
            checkBox2.Checked = ConName.UseElse;
            if (ConName.UseElse)
            {
                statementBlock2.Open(ConName.Block2);
            }
            checkBox1.Checked = ConName.Constant;
            if (ConName.Constant)
            {
                comboBox4.DropDownStyle = ComboBoxStyle.Simple;
                comboBox4.Text = ConName.Value2;
            }
            else
            {
                comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox4.SelectedItem = ConName.Value2;
            }
            comboBox3.SelectedIndex = ConName.Opreater;
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
                    if (string.IsNullOrEmpty(Beforename)==false)
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
                    if (string.IsNullOrEmpty(Beforename)==false)
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
