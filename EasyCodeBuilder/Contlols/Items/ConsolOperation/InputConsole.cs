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
    public partial class InputConsole : StatementBase
    {
        public InputConsole()
        {
            InitializeComponent();
        }

        private void ComboBox1_DropDown(object sender, EventArgs e)
        {
            List<String> vList = Util.GetVariableList(this,2);
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.AddRange(vList.ToArray());
        }

        private void ImputConsole_Load(object sender, EventArgs e)
        {

        }

        public override Statement CreateProgramDefine()
        {
            XmlImputC Imput = new XmlImputC();
            Imput.Variable = comboBox1.Text;
            return Imput;
        }
        public override void ControlSetup(Statement name)
        {
            XmlImputC ImputName = (XmlImputC)name;
            List<String> vList = Util.GetVariableList(this, 2);
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.AddRange(vList.ToArray());
            comboBox1.SelectedItem = ImputName.Variable;
        }
        public override void ChangeName(string Aftername, string Beforename, bool type)
        {
            if (comboBox1.Text == Beforename)
            {
                List<String>vList = Util.GetVariableList(this, 2);
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
        }
        public override String CodeOutput(int level)
        {
            string levelString = new string('\t', level);
            string Code = "";

            List<String> vList = Util.GetVariableList(this, 0);
            if (vList.Contains(comboBox1.Text))
            {

                List<String> vList1 = Util.GetVariableList(this, 2);
                if (vList1.Contains(comboBox1.Text))
                {

                    Code = levelString + comboBox1.Text + " = " + "Console.ReadLine();\r\n";
                }
                else
                {
                    Form1.MessageBoxValue("string型の変数しか使えません", true);
                }
            }
            else
            {
                
                if (comboBox1.SelectedIndex==-1)
                {
                    Code = levelString + "Console.ReadLine();\r\n";
                }
                else
                {
                    Form1.MessageBoxValue("宣言されていない変数です", true);
                }
            }

            
            return Code;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }



        private void Timer1_Tick(object sender, EventArgs e)
        {

        }
    }

}
