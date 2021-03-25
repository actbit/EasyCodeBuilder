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
    public partial class OutputConsole : StatementBase
    {
        int AddNumber;
        List<AddOutputObject> OutputOrder = new List<AddOutputObject>();
        public OutputConsole()
        {

            InitializeComponent();
            AddNumber = 0;
            AddOutputObject us = new AddOutputObject();
            us.Name = "AddOutputObject0";
            us.Location = new Point(this.panel1.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            this.panel1.Controls.Add(us);
            OutputOrder.Add(us);
            us.button2.Enabled = false;
        } 

        public void AddObject(AddOutputObject AddThis)
        {
            AddNumber = OutputOrder.IndexOf(AddThis)+1;
            AddOutputObject us = new AddOutputObject();
            us.Name = "AddOutputObject" + AddNumber.ToString();
            this.panel1.Controls.Add(us);
            OutputOrder.Insert(AddNumber,us);
            ObjectSorting();
        }

        public void EraseObject(AddOutputObject EraseThis)
        {
            if (EraseThis.Name != "AddOutputObject0")
            {
                this.panel1.Controls.Remove(EraseThis);
                OutputOrder.Remove(EraseThis);
                ObjectSorting();
                EraseThis.Dispose();
                ObjectSorting();
            }

        }

        private void ObjectSorting()
        {
            for(int i = 0; i < OutputOrder.Count; i++)
            {
                AddOutputObject Me = OutputOrder[i];
                Me.Location = new Point(this.panel1.AutoScrollPosition.Y, this.panel1.AutoScrollPosition.X + 45 * i);
            }
        }

        private void ValueOutput_Load(object sender, EventArgs e)
        {

        }
        public override string CodeOutput(int level)
        {
            string Code="";
            string Output;
            string levelString = new string('\t', level);
            if (checkBox1.Checked)
            {
                Output = "Console.Write";
            }
            else
            {
                Output = "Console.WriteLine";
            }
            for(int i = 0; i < OutputOrder.Count; i++)
            {
                AddOutputObject Me = OutputOrder[i];
                if (Me.radioButton1.Checked)
                {
                    
                    
                    if (i == 0)
                    {
                        Code = Code + "\"" + Me.comboBox1.Text + "\"";
                    }
                    else
                    {
                        Code = Code + "+\"" + Me.comboBox1.Text + "\"";
                    }
                }
                else
                {
                    List<string> vList = Util.GetVariableList(this, 0);

                    if (vList.Contains(Me.comboBox1.Text)==false)
                    {
                        Form1.MessageBoxValue("未宣言の変数が使われています",true);

                    }

                    if (Me.comboBox1.SelectedIndex != -1)
                    {
                        if (i == 0)
                        {
                            Code =Code + Me.comboBox1.Text;
                        }
                        else
                        {
                            Code = Code + "+" + Me.comboBox1.Text;
                        }
                        List<string> name = Util.VariableConfirmation(this);
                        if (name.Contains(Me.comboBox1.Text) == false)
                        {
                            Form1.MessageBoxValue("コンソールに表示する変数に値が入力されていません", true);
                        }

                    }
                    else
                    {
                        Form1.MessageBoxValue("変数が設定されていません",true);
                    }
                }
            }
            return levelString + Output + "(" + Code + ");\r\n"; ;
        }
        public override Statement CreateProgramDefine()
        {
            XmlOutputC Output = new XmlOutputC();
            for (int i = 0; i < OutputOrder.Count; i++)
            {
                AddOutputObject Me = OutputOrder[i];
                Output.Objects.Add(Me.CreateProgramDefine());
            }
            return Output;
        }
        public override void ControlSetup(Statement name)
        {
            XmlOutputC outputC = (XmlOutputC)name;
            for (int i = 0; i < outputC.Objects.Count; i++)
            {
                XmlAddOutput Add = outputC.Objects[i];
                if (i == 0)
                {
                    AddOutputObject us = OutputOrder[0];
                    us.radioButton1.Checked = Add.Isvariable;
                    us.radioButton2.Checked = !Add.Isvariable;
                    if (Add.Isvariable)
                    {
                        us.comboBox1.Text = Add.Value;
                    }
                    else
                    {
                        us.GetVariable();
                        us.comboBox1.SelectedItem = Add.Value;
                    }
                }
                else
                {
                    AddNumber = i;
                    AddOutputObject us = new AddOutputObject();
                    us.Name = "AddOutputObject" + AddNumber.ToString();
                    this.panel1.Controls.Add(us);
                    OutputOrder.Insert(AddNumber, us);
                    us.radioButton1.Checked = Add.Isvariable;
                    us.radioButton2.Checked =! Add.Isvariable;
                    if (Add.Isvariable)
                    {
                        us.comboBox1.Text = Add.Value;
                    }
                    else
                    {
                        us.GetVariable();
                        us.comboBox1.SelectedItem = Add.Value;
                    }
                    ObjectSorting();
                }
                

            }
        }
        public override void ChangeName(string Aftername, string Beforename, bool type)
        {
            List<string> vList = Util.GetVariableList(this, 0);

            for (int i= 0; i < OutputOrder.Count; i++)
            {
                if (OutputOrder[i].radioButton2.Checked&&OutputOrder[i].comboBox1.Text==Beforename)
                {
                    if (type)
                    {
                        if (Beforename != "")
                        {
                            
                            OutputOrder[i].comboBox1.Items.Clear();
                            OutputOrder[i].comboBox1.Items.AddRange(vList.ToArray());
                            OutputOrder[i].comboBox1.SelectedItem = Aftername;
                        }

                    }
                    else
                    {
                        OutputOrder[i].comboBox1.SelectedIndex = -1;
                    }

                    
                }

            }
 
        }

    }
}
