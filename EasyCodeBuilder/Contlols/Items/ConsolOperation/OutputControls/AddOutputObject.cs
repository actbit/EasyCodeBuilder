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
    public partial class AddOutputObject : UserControl
    {
        public AddOutputObject()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            label1.Text = "定数を表示";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ((OutputConsole)this.Parent.Parent).AddObject(this);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ((OutputConsole)this.Parent.Parent).EraseObject(this);
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                comboBox1.DropDownStyle = ComboBoxStyle.Simple;
                label1.Text = "定数を表示";
            }
            comboBox1.SelectedIndex = -1;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                label1.Text = "変数を表示";
            }
            comboBox1.SelectedIndex=-1;
        }

        private void ComboBox1_DropDown(object sender, EventArgs e)
        {
            List<string> vList = Util.GetVariableList(this.Parent.Parent, 0);
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.AddRange(vList.ToArray());
        }

        public XmlAddOutput CreateProgramDefine()
        {
            XmlAddOutput AddOut = new XmlAddOutput();
            AddOut.Value = comboBox1.Text;
            AddOut.Isvariable = radioButton1.Checked;
            return AddOut;
        }

        private void AddOutputObject_Load(object sender, EventArgs e)
        {

        }
        public void GetVariable()
        {
            List<string> vList = Util.GetVariableList(this.Parent.Parent, 0);
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.AddRange(vList.ToArray());
        }
    }
}
