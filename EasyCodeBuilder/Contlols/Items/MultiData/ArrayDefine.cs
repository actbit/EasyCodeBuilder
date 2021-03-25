using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace EasyCodeBuilder
{
    public partial class ArrayDefine : StatementBase
    {
        public string itemType = "";
        public ArrayDefine()
        {
            InitializeComponent();
        }
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            CheckLetters.CheckNumbers(textBox2.Text,false);
            List<String> vList = Util.GetVariableList(this, 0);
            if (vList.Contains(textBox2.Text) == true)
            {
                Form1.MessageBoxValue("同じ名前が存在します", false);
            }
            ((StatementBlock)this.Parent).CheckName("nothingnothing", "nothingnothing", false);
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

                    ((StatementBlock)this.Parent).CheckName(textBox1.Text, Name, true);
                }
                else
                {
                    ((StatementBlock)this.Parent).CheckName(textBox1.Text, Name, false);
                }
                Name = textBox1.Text;
            }
        }


        private void ArrayDefine_Load(object sender, EventArgs e)
        {
            List<String> TypeAddList = Type.TypeList();
            this.arrayType.Items.Clear();
            this.arrayType.Items.AddRange(TypeAddList.ToArray());
        }

        private void ArrayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (arrayType.SelectedIndex)
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
        public override string CodeOutput(int level)
        {
            string levelString = new string('\t', level);
            string CodeOutput="";
            if (VariableDefine.NameList.Contains(textBox1.Text))
            {
                Form1.MessageBoxValue("同じ名前の変数が既にあります", true);
            }
            else
            {
               VariableDefine.NameList.Add(textBox1.Text);
            }
            if (itemType == "")
            {
                Form1.MessageBoxValue("配列の型が選択されていません",true);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    Form1.MessageBoxValue("配列の宣言で配列の名前が入力されていません",true);
                }
                else
                {

                    CheckLetters.CheckName(textBox1.Text,true);


                    if (string.IsNullOrWhiteSpace(textBox2.Text))
                    {
                        Form1.MessageBoxValue("配列の宣言で配列の数の値が入力されていません",true);
                    }
                    else                        {
                        int OkNumber;
                        if(int.TryParse(textBox2.Text ,out OkNumber))
                        {
                            if (OkNumber < 0)
                            {
                            Form1.MessageBoxValue("配列の宣言の配列の数で不正な数値が入力されています",true);
                            }
                            else
                            {
                                CodeOutput=levelString+itemType+"[] "+textBox1.Text+" = new "+itemType+"[" + OkNumber + "];\r\n";
                            }
                        }
                        else
                        {
                            Form1.MessageBoxValue("配列の宣言の配列の数で数値以外が入力されています",true);
                        }
                    }


                }
            }
            return CodeOutput;
        }
        public override Statement CreateProgramDefine()
        {
            XmlArray array = new XmlArray();
            array.Type = arrayType.SelectedIndex;
            array.Name = textBox1.Text;
            array.ArrayNumber = textBox2.Text;

            return array;
        }
        public override void ControlSetup(Statement name)
        {
            XmlArray ArrayName = (XmlArray)name;
            arrayType.SelectedIndex = ArrayName.Type;
            textBox1.Text = ArrayName.Name;
            textBox2.Text = ArrayName.ArrayNumber;
        }


        
    }
}
