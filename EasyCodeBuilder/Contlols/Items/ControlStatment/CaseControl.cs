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
    public partial class CaseControl : StatementBase
    {
        int distanceY;
        int distanceX;
        public CaseControl()
        {
            InitializeComponent();
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

        private void CaseControl_Load(object sender, EventArgs e)
        {
            distanceY = this.Height - (this.statementBlock1.Top + this.statementBlock1.Height);
            distanceX = this.Width - (this.statementBlock1.Left + this.statementBlock1.Width);
        }
        public override Statement CreateProgramDefine()
        {
            XmlCase Case = new XmlCase();
            Case.Block = statementBlock1.CreateProgramDefine();
            Case.Condition = textBox1.Text;
            return Case;
        }
        public override void ControlSetup(Statement name)
        {
            XmlCase CaseName = (XmlCase)name;
            textBox1.Text = CaseName.Condition;
            statementBlock1.Open(CaseName.Block);
        }
        public override string CodeOutput(int level)
        {
            string levelString =new string ('\t', level);
            string Code = "";
            Conditions ThisParent = ((Conditions)this.Parent.Parent);
            
            if (ThisParent.comboBox2.SelectedIndex != -1)
            {
                string type = "";
                Dictionary<string,string> constant = Util.GetVariableType(this);
                CheckLetters.CheckVariables(ThisParent.comboBox2.Text, this.textBox1.Text, Util.GetVariableType(this), true);
                if (constant[ThisParent.comboBox2.Text] == "string")
                {
                    type = "\"" + textBox1.Text + "\"";
                }
                else if(constant[ThisParent.comboBox2.Text] == "char")
                {
                    type = "\'" + textBox1.Text + "\"";
                }
                else
                {
                    type = textBox1.Text;
                }
                Code = levelString+"case "+type+":"+statementBlock1.CodeOutput(level, false);
            }
            else
            {
                Form1.MessageBoxValue("caseの定数が入力されていません",true);
            }
            return Code;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Conditions ThisParent = ((Conditions)this.Parent.Parent);
            CheckLetters.CheckVariables(ThisParent.comboBox2.Text, textBox1.Text, Util.GetVariableType(this),true);
        }
    }
}
