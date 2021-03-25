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
    public partial class ListDefine : StatementBase
    {
        public ListDefine()
        {
            InitializeComponent();
        }

        string itemType;
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            CheckLetters.CheckName(textBox1.Text,false);
            List<String> vList = Util.GetVariableList(this, 0);
            if (vList.Contains(textBox1.Text) == true)
            {
                Form1.MessageBoxValue("同じ名前が存在します",false);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case -1:
                    Form1.MessageBoxValue("変数の型が選択されていません", true);
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
        List<string> aaa = new List<string>();
        private void ListDefine_Load(object sender, EventArgs e)
        {
            List<String> TypeAddList = Type.TypeList();
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.AddRange(TypeAddList.ToArray());
        }
        public override string CodeOutput(int level)
        {
            string levelString = new string('\t', level);
            string Code = "";
            if (comboBox1.SelectedIndex != -1)
            {
                if (string.IsNullOrEmpty(textBox1.Text)==false)
                {
                    CheckLetters.CheckName(textBox1.Text, true);
                    List<String> vList = Util.GetVariableList(this, 0);
                    if (vList.Contains(textBox1.Text) == true)
                    {
                        Form1.MessageBoxValue("同じ名前が存在します", false);
                    }
                    else
                    {
                        Code = levelString + "List<" + itemType + ">" + textBox1.Text + " = new List<" + itemType + ">();";

                    }
                }
                else
                {
                    Form1.MessageBoxValue("リストの名前が設定されていません", true);
                }
            }
            else
            {
                Form1.MessageBoxValue("リストの型が設定されていません", true);
            }
            return Code;

        }

        private void ComboBox1_DropDown(object sender, EventArgs e)
        {

        }
    }
}
