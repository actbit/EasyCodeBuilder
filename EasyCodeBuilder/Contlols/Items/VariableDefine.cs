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
    public partial class VariableDefine : StatementBase
    {
        public string itemType = "";
        public static List<string> NameList = new List<string>();
        public string name = "";
        
        public VariableDefine()
        {
            InitializeComponent();
            textBox2.Enabled = false;
            
        }
        
        private void ComboBox1_DropDown(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.Enabled = true;
            }
            else
            {
                textBox2.Enabled = false;
            }
            textBox2.Text = "";
        }
        public override Statement CreateProgramDefine()
        {
            XmlVariable var = new XmlVariable();

            var.Type = comboBox1.SelectedIndex;
            var.Name = this.textBox1.Text;
            var.Value = textBox2.Text;
            var.Substitute = checkBox1.Checked;
            return var;
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

            CheckLetters.CheckName(textBox1.Text, false);
            List<String> vList = Util.GetVariableList(this, 0);
            if (vList.Contains(textBox1.Text) == true)
            {
                Form1.MessageBoxValue("同じ名前が存在します", false);
            }
            else
            {
                if (string.IsNullOrEmpty(textBox1.Text) == false)
                {
                    
                    ((StatementBlock)this.Parent).CheckName(textBox1.Text, name, true);
                    
                }
                else
                {
                    ((StatementBlock)this.Parent).CheckName(textBox1.Text, name, false);
                }
                name = textBox1.Text;
            }

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            CheckLetters.CheckValue(itemType, textBox2.Text,false);
            //((StatementBlock)this.Parent).CheckName(textBox1.Text, Name, false);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case -1:
                    Form1.MessageBoxValue("変数の型が選択されていません",false);
                    break;
                case 0:
                    itemType = "int";
                    break;
                case 1:
                    itemType = "string";
                    break;
                case 2:
                    itemType = "char";
                    break;
                case 3:
                    itemType = "double";
                    break;
                case 4:
                    itemType = "byte";
                    break;
                case 5:
                    itemType = "bool";
                    break;
            }
        }
        public override void ControlSetup(Statement name)
        {
            XmlVariable VarName = ((XmlVariable)name);
            textBox1.Text = VarName.Name;
            comboBox1.SelectedIndex = VarName.Type;
            checkBox1.Checked = VarName.Substitute;
            if (VarName.Substitute)
            {
                textBox2.Text = VarName.Value;
            }
            
        }

        private void VariableDefine_Load(object sender, EventArgs e)
        {
            List<String> TypeAddList = Type.TypeList();
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.AddRange(TypeAddList.ToArray());
        }
        public override string CodeOutput(int level)
        {
            string Quotation="";
            

            String levelString = new string('\t', level);
            CheckLetters.CheckName(textBox1.Text,true);
            if (NameList.Contains(textBox1.Text))
            {
                Form1.MessageBoxValue("同じ名前の変数が既にあります", true);
                
            }
            else
            {
                NameList.Add(textBox1.Text);
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    Form1.MessageBoxValue("変数の名前が入力されていません", true);
                }
            }
            switch (comboBox1.SelectedIndex)
            {
                case -1:
                    Form1.MessageBoxValue("変数の型が選択されていません",true);
                    break;
                case 0:
                    itemType = "int";
                    break;
                case 1:
                    itemType = "string";
                    break;
                case 2:
                    itemType = "char";
                    break;
                case 3:
                    itemType = "double";
                    break;
                case 4:
                    itemType = "byte";
                    break;
                case 5:
                    itemType = "bool";
                    break;
            }
            if (checkBox1.Checked == true)
            {
                if (String.IsNullOrWhiteSpace(textBox2.Text) == false)
                {
                    if (itemType == "char")
                    {
                        char a;
                        if (char.TryParse(textBox2.Text, out a))
                        {
                            Quotation = "\'";
                        }
                        else
                        {
                            Form1.MessageBoxValue("型にあっていません",true);
                        }
                        if (string.IsNullOrWhiteSpace(textBox1.Text))
                        {
                            Form1.MessageBoxValue("入力されていないところがあります",true);
                        }
                        
                    }
                    else if (itemType == "string")
                    {
                        Quotation = "\"";
                    }
                    CheckLetters.CheckValue(itemType,textBox2.Text, true);
                    return (levelString + itemType + " " + this.textBox1.Text + " = "+Quotation + textBox2.Text+Quotation + ";\r\n");
                }
                else
                {
                    if (itemType != "string")
                    {
                        Form1.MessageBoxValue("変数に代入する値が入力されていません", true);
                    }
                    else
                    {
                        return (levelString + itemType + " " + this.textBox1.Text + " = " + "\"\"" + ";\r\n");
                    }
                }
            }

            
            return (levelString + itemType + " " + this.textBox1.Text + ";\r\n");

        }
    }
}
