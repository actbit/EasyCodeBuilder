using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyCodeBuilder
{
    
    public partial class Form2 : Form
    {

        int DialogType;

        private StatementBlock mTargetStatementBlock;
        public Form2(StatementBlock targetStatementBlock,int dialogbool)
        {
            InitializeComponent();
            mTargetStatementBlock = targetStatementBlock;
            DialogType = dialogbool;
        }

        private void CanselButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        StatementBase Me = null;

        private void AddVariableDefineButton_Click(object sender, EventArgs e)
        {
            Me = new VariableDefine();
            // ((Form1)this.Owner).statementBlock.InsertContlols("VariableDefine");
            Confirmation(Me);
        }

        private void AddOutputConsoleButton_Click(object sender, EventArgs e)
        {
            Me = new OutputConsole();
            Confirmation(Me);
        }

        private void AddConditionsButton_Click(object sender, EventArgs e)
        {
            Me = new Conditions();
            Confirmation(Me);
        }

        private void AddCalculationButton_Click(object sender, EventArgs e)
        {
            Me = new Calculation();
            Confirmation(Me);
        }


        private void AddImputConsoleButton_Click(object sender, EventArgs e)
        {
            Me = new InputConsole();
            Confirmation(Me);

        }

        private void AddLoopButton_Click(object sender, EventArgs e)
        {
            Me = new Loop();
            Confirmation(Me);
        }
        private void ListDefine_Click(object sender, EventArgs e)
        {
            Me = new ListDefine();
            Confirmation(Me);
        }
        private void ArrayDefineButton_Click(object sender, EventArgs e)
        {
            Me = new ArrayDefine();
            Confirmation(Me);
        }
        private void AddBreakButton_Click(object sender, EventArgs e)
        {
            Me = new BreakControl();
            Confirmation(Me);
        }
        private void Confirmation(StatementBase AddName)
        {
            mTargetStatementBlock.InsertContlols(AddName);
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            if (DialogType==0)
            {
                AddCaseButton.Visible = true;
                panel1.Visible = false;
                AddBreakButton.Visible = false;
            }
            else if(DialogType==1)
            {
                AddCaseButton.Visible = false;
                panel1.Visible = true;
                AddBreakButton.Visible = false;
            }
            else if(DialogType==2)
            {
                AddCaseButton.Visible = false;
                panel1.Visible = true;
                AddBreakButton.Visible = true;
            }
        }

        private void AddCaseButton_Click(object sender, EventArgs e)
        {
            Me = new CaseControl();
            Confirmation(Me);
        }

        private void AddReturnMold_Click(object sender, EventArgs e)
        {
            Me = new ReturnMold();
            Confirmation(Me);
        }

        private void AddAssignmentButton_Click(object sender, EventArgs e)
        {
            Me = new Assignment();
            Confirmation(Me);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Me = new AddMethod();
            Confirmation(Me);
        }
    }
}
