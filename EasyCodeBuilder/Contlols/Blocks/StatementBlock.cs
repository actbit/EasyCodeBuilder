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
    public partial class StatementBlock : UserControl
    {
        string Name1;
        public int number = 0;
        public List<StatementBase> ControlOrder = new List<StatementBase>();
        List<Button> ControlAddButton = new List<Button>();
        Dictionary<string ,string> SizeDate =new Dictionary<string , string>();
        public int DialogType = 0;
        int IndexNumber=-1;
        public int index = -1;
        public string OutCode;
        public void addbutton(object sender, EventArgs e)
        {
            
            IndexNumber = ControlAddButton.IndexOf((Button)sender);

            if (this.Parent.GetType().Equals(typeof(Conditions)))
            {
                Conditions MyParent = (Conditions)this.Parent;
                if (MyParent.comboBox1.SelectedIndex == 1)
                {
                    DialogType = 0;
                }
                else
                {
                    DialogType = 1;
                }
            }
            else
            {
                DialogType = 1;
            }
            if (this.Parent.GetType() == typeof(Loop))
            {
                DialogType = 2;
            }
            Control Parenta = this.Parent;
            for (; ; )
            {

                if (Parenta.Parent.Parent.GetType() == typeof(Form1))
                {
                    break;
                }
                if (Parenta.GetType() == typeof(Loop))
                {
                    DialogType = 2;
                    break;
                }
                Parenta = Parenta.Parent;

            }



            Form2 AddForm = new Form2(this,DialogType);
            AddForm.ShowDialog(this);
            AddForm.Dispose();
        }
        public void addbutton2(object sender, EventArgs e)
        {
            IndexNumber = -1;
            if (this.Parent.GetType().Equals(typeof(Conditions)))
            {
                Conditions MyParent = (Conditions)this.Parent;
                if (MyParent.comboBox1.SelectedIndex == 1)
                {
                    DialogType = 0;
                }
                else
                {
                    DialogType = 1;
                }
            }
            else
            {
                DialogType = 1;
            }
            if (this.Parent.GetType() == typeof(Loop))
            {
                DialogType = 2;
            }
            Control Parenta = this.Parent;
            for(; ; )
            {
                
                if (Parenta.Parent.Parent.GetType()==typeof(Form1))
                {
                    break;
                }
                if (Parenta.GetType() == typeof(Loop))
                {
                    DialogType = 2;
                    break;
                }
                Parenta = Parenta.Parent;

            }



            Form2 AddForm = new Form2(this,DialogType);
            AddForm.ShowDialog(this);
            AddForm.Dispose();
        }

        public void UpStatement(StatementBase statement)
        {
            int IndexNumber = ControlOrder.IndexOf(statement) - 1;
            ControlOrder.Remove(statement);
            Button btn = ControlAddButton[IndexNumber + 1];
            ControlAddButton.RemoveAt(IndexNumber+1);
            ControlOrder.Insert(IndexNumber, statement);
            ControlAddButton.Insert(IndexNumber, btn);


            Sorting();


        }
        public void DownStatement(StatementBase statement)
        {
            int IndexNumber = ControlOrder.IndexOf(statement) + 1;
            ControlOrder.Remove(statement);
            Button btn = ControlAddButton[IndexNumber - 1];
            ControlAddButton.Remove(btn);
            ControlOrder.Insert(IndexNumber, statement);
            ControlAddButton.Insert(IndexNumber, btn);
            Sorting();

        }


        public StatementBlock()
        {
            InitializeComponent();
            Button us1 = new Button();
            us1.Location = new Point(this.AutoScrollPosition.X, this.AutoScrollPosition.Y + 0);
            Name = "AddButtonDefault";
            us1.Name = Name;
            us1.Text = "コントロールをたす";
            this.Controls.Add(us1);
            us1.Size = new Size(400, 30);
            us1.Click += addbutton2;
        }


        public void InsertContlols (StatementBase item)
        {
            IndexNumber++;
            if (item.GetType().Equals(typeof(AddMethod)))
            {
                item.Name = "AddMethod" + number.ToString();
                item.Size = new Size(460, 270);
            }
            if (item.GetType().Equals(typeof(MainMethod)))
            {
                item.Name = "Main" + number.ToString();
                item.Size = new Size(500, 400);
            }
            else if(item.GetType().Equals(typeof(VariableDefine)))
            {
                item.Name = "VariableDefine" + number.ToString();
                item.Size = new Size(400, 200);

            }
            else if(item.GetType().Equals(typeof(OutputConsole)))
            {
                item.Name = "OutputConsole" + number.ToString();
                item.Size = new Size(400, 200);

            }
            else if(item.GetType().Equals(typeof(Conditions)))
            {
                
                item.Name = "Conditions" + number.ToString();
                item.Size = new Size(460, 200);
            }
            else if(item.GetType().Equals(typeof(Calculation)))
            {
                item.Name = "Calculation" + number.ToString();
                item.Size = new Size(400, 200);
            }
            else if(item.GetType().Equals(typeof(InputConsole)))
            {
                item.Name = "ImputConsole" + number.ToString();
                item.Size=new Size (400,200);
            }
            else if(item.GetType().Equals(typeof(Loop)))
            {
                item.Name = "Loop" + number.ToString();
                item.Size = new Size(460, 200);
            }
            else if(item.GetType().Equals(typeof(ListDefine)))
            {
                item.Name = "ListDefine" + number.ToString();
                item.Size = new Size(460, 200);
            }
            else if (item.GetType().Equals(typeof(ArrayDefine)))
            {
                item.Name = "ArrayDefine" + number.ToString();
                item.Size = new Size(400, 200);
            }
            else if (item.GetType().Equals(typeof(BreakControl)))
            {
                item.Name = "ArrayDefine" + number.ToString();
                item.Size = new Size(400, 100);
            }
            else if (item.GetType().Equals(typeof(ReturnMold)))
            {
                item.Name = "ReturnMold" + number.ToString();
                item.Size = new Size(400, 200);
            }
            else if (item.GetType().Equals(typeof(Assignment)))
            {
                item.Name = "Assignment" + number.ToString();
                item.Size = new Size(400, 200);
            }
            else if (item.GetType().Equals(typeof(CaseControl)))
            {
                item.Name = "CaseControl" + number.ToString();
            }

            this.Controls.Add(item);
            Button us1 = new Button();
            Name1 = "AddButton" + number.ToString();
            us1.Name = Name1;
            us1.Size = new Size(400, 30);
            us1.Text = "コントロールをたす";
            us1.Click += addbutton;
            this.Controls.Add(us1);
            ControlAddButton.Insert(IndexNumber, us1);

            ControlOrder.Insert(IndexNumber, item);
            
            number++;

            Sorting();
        }
        public void RemoveStatement(StatementBase statement)
        {
            int IndexNumber = ControlOrder.IndexOf(statement);
            this.Controls.Remove(statement);
            Button btn = ControlAddButton[IndexNumber];
            ControlOrder.Remove(statement);
            ControlAddButton.Remove(btn);
            this.Controls.Remove(statement);
            this.Controls.Remove(btn);
            statement.Dispose();
            btn.Dispose();
            Sorting();
            if (ControlOrder.Count == 0)
            {
                number = 0;
            }
        }
        public void RemoveAll()
        {
            while( 0 < ControlOrder.Count)
            {
                RemoveStatement(ControlOrder[0]);
            }
            Sorting();
        }

        public void Sorting()
        {
            int top = 30;
            int maxWidth = 0;
            for (int i=0; i < ControlOrder.Count;i++)
            {
                StatementBase us1 = ControlOrder[i];
                us1.Location = new Point(this.AutoScrollPosition.X, this.AutoScrollPosition.Y + top);
                top += us1.Height;
                if (maxWidth < us1.Width)
                {
                    maxWidth = us1.Width;
                }


                Button us2 = ControlAddButton[i];
                us2.Location = new Point(this.AutoScrollPosition.X, this.AutoScrollPosition.Y + top);
                top += us2.Height;
                us1.button1.Enabled = true;
                us1.button2.Enabled = true;
                if (i == 0)
                {
                    us1.button1.Enabled = false;
                }
                if (i == ControlOrder.Count - 1)
                {
                    us1.button2.Enabled = false;
                }

            }
            if ((this.Anchor & AnchorStyles.Right) == 0)
            {
                this.Width = this.AutoScrollPosition.X + maxWidth;
            }
            if ((this.Anchor & AnchorStyles.Bottom) == 0)
            {
                this.Height = this.AutoScrollPosition.Y + top;
            }
            if(this.Parent is StatementBase)
            {
                ((StatementBase)this.Parent).Sorting();
            }
        }
        public List<StatementBase> GetOrderControls()
        {
            return ControlOrder;
        }
        public static bool CodeOk=true;

        public String CodeOutput(int level,bool Type)
        {
            CodeOk = true;
            String code = "";
            String levelString = new string('\t', level);
            string space;
            string space1;
            if (Type)
            {
                space = "{\r\n";
                space1 = "}\r\n";
            }
            else
            {
                space = "\r\n";
                space1 = "\tbreak;\r\n";
            }
            code += levelString + space;
            
            foreach(Control child in this.GetOrderControls() )
            {
                if (child is StatementBase)
                {
                    code += ((StatementBase)child).CodeOutput(level + 1);
                }
            }
            
            code += levelString+ space1;
            

            return code;
        }

        public String outCodeOutput()
        {
            CodeOk = true;
            String code = "";

            code += "\t{\r\n";

            foreach (Control child in this.GetOrderControls())
            {
                if (child is StatementBase)
                {
                    code += ((StatementBase)child).CodeOutput(1 + 1);
                }
            }

            code += "\t\tConsole.Write(\"続行するには何かキーを押してください. . .\");\r\n" + "\t\tConsole.ReadKey();\r\n" + "\t}\r\n";

            return code;
        }

        public Block CreateProgramDefine()
        {
            Block blk = new Block();
            foreach (Control child in this.GetOrderControls())
            {
                if (child is StatementBase)
                {
                    blk.Statement.Add(((StatementBase)child).CreateProgramDefine());
                }
            }

            return blk;
        }
        public void Open(Block Block)
        {
            RemoveAll();
            number = 0;
            IndexNumber = -1;
            for(int i = 0; i < Block.Statement.Count; i++)
            {
                OpenAdd(Block.Statement[i]);
            }
            
        }
        private void OpenAdd(Statement name)
        {
            StatementBase StatementName = null;
            if (name.GetType() == typeof(XmlVariable))
            {
                StatementName = new VariableDefine();
            }
            else if (name.GetType() == typeof(XmlImputC))
            {
                StatementName = new InputConsole();
            }
            else if (name.GetType() == typeof(XmlCondition))
            {
                StatementName = new Conditions();
            }
            else if (name.GetType() == typeof(XmlLoop))
            {
                StatementName = new Loop();
            }
            else if (name.GetType() == typeof(XmlArray))
            {
                StatementName = new ArrayDefine();
            }
            else if (name.GetType() == typeof(XmlCase))
            {
                StatementName = new CaseControl();
            }
            else if (name.GetType() == typeof(XmlOutputC))
            {
                StatementName = new OutputConsole();
            }
            else if (name.GetType() == typeof(XmlBreak))
            {
                StatementName = new BreakControl();
            }
            else if (name.GetType() == typeof(XmlCalculation))
            {
                StatementName = new Calculation();
            }
            else if (name.GetType() == typeof(XmlMold))
            {
                StatementName = new ReturnMold();
            }
            else if (name.GetType() == typeof(XmlAssignment))
            {
                StatementName = new Assignment();
            }
            InsertContlols(StatementName);
            ControlOrder[IndexNumber].ControlSetup(name);
            number++;
            if (this.Parent.Parent.Parent.GetType() == typeof(Form1))
            {
                Form1 Mparent = (Form1)Parent.Parent.Parent;
                Mparent.AddBar(1);
            }
        }
        public void CheckName(string afterName ,string beforeName,bool type)
        {
            for(int i = 0;i<ControlOrder.Count;i++)
            {
                if(ControlOrder[i].Parent is StatementBase)
                {
                    ControlOrder[i].ChangeName(afterName, beforeName,type);
                }

                ControlOrder[i].ChangeName(afterName, beforeName,type);
            }
        }


        public bool BreakCheck()
        {
            bool BoolOutput=false;
            for(int i = 0; i < ControlOrder.Count; i++)
            {
                StatementBase us = ControlOrder[i];

                if (us.GetType() == typeof(BreakControl))
                {
                    BoolOutput = true;
                }
                else if (us.GetType() == typeof(Loop))
                {
                    Loop Me = (Loop)us;
                    BoolOutput = Me.statementBlock1.BreakCheck();
                }
                else if (us.GetType() == typeof(Conditions))
                {
                    Conditions Me = (Conditions)us;
                    BoolOutput=Me.statementBlock1.BreakCheck();
                    BoolOutput = Me.statementBlock2.BreakCheck();
                }
                else if (us.GetType() == typeof(CaseControl))
                {
                    CaseControl Me = (CaseControl)us;
                    BoolOutput = Me.statementBlock1.BreakCheck();
                }
            }
            return BoolOutput;
        }

        private void StatementBlock_Load(object sender, EventArgs e)
        {
            //mainを足す

            //if (this.Parent.GetType() == typeof(Form1))
            //{
            //    MainMethod Main = new MainMethod();

            //    bool OkBool = true;
            //    for (int i = 0; i < ControlOrder.Count; i++)
            //    {
            //        if (ControlOrder[i].GetType() == typeof(MainMethod))
            //        {
            //            OkBool = false;
            //        }
            //    }

            //    if (OkBool)
            //    {
            //        InsertContlols(Main);
            //    }
            //}

        }
    }
}