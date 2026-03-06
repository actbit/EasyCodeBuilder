using System;
using System.Windows.Forms;
using EasyCodeBuilder.Application.Interfaces;
using EasyCodeBuilder.Contlols.Blocks;
using EasyCodeBuilder.Contlols.Items;

namespace EasyCodeBuilder.Presentation.Forms
{
    /// <summary>
    /// コントロール追加ダイアログ - DI対応版
    /// </summary>
    public partial class AddControlDialog : Form
    {
        private readonly IStatementFactory _statementFactory;

        private int _dialogType;
        private StatementBlock _targetStatementBlock;
        private StatementBase _me = null;

        public AddControlDialog(IStatementFactory statementFactory)
        {
            InitializeComponent();
            _statementFactory = statementFactory;
        }

        public AddControlDialog(StatementBlock targetStatementBlock, int dialogType)
        {
            InitializeComponent();
            _targetStatementBlock = targetStatementBlock;
            _dialogType = dialogType;
        }

        private void CanselButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddVariableDefineButton_Click(object sender, EventArgs e)
        {
                _me = _statementFactory?.CreateVariableDefine() ?? new VariableDefine();
                Confirmation(_me);
            }

        private void AddOutputConsoleButton_Click(object sender, EventArgs e)
        {
                _me = _statementFactory?.CreateOutputConsole() ?? new OutputConsole();
                Confirmation(_me);
            }

        private void AddConditionsButton_Click(object sender, EventArgs e)
        {
                _me = _statementFactory?.CreateConditions() ?? new Conditions();
                Confirmation(_me);
            }

        private void AddCalculationButton_Click(object sender, EventArgs e)
        {
                _me = _statementFactory?.CreateCalculation() ?? new Calculation();
                Confirmation(_me);
            }

        private void AddImputConsoleButton_Click(object sender, EventArgs e)
        {
                _me = _statementFactory?.CreateInputConsole() ?? new InputConsole();
                Confirmation(_me);
            }

        private void AddLoopButton_Click(object sender, EventArgs e)
            {
                _me = _statementFactory?.CreateLoop() ?? new Loop();
                Confirmation(_me);
            }

        private void ListDefine_Click(object sender, EventArgs e)
            {
                _me = _statementFactory?.CreateListDefine() ?? new ListDefine();
                Confirmation(_me);
            }

        private void ArrayDefineButton_Click(object sender, EventArgs e)
            {
                _me = _statementFactory?.CreateArrayDefine() ?? new ArrayDefine();
                Confirmation(_me);
            }

        private void AddBreakButton_Click(object sender, EventArgs e)
            {
                _me = _statementFactory?.CreateBreakControl() ?? new BreakControl();
                Confirmation(_me);
            }

        private void Confirmation(StatementBase addName)
        {
                _targetStatementBlock?.InsertContlols(addName);
                this.Close();
            }

        private void AddControlDialog_Load(object sender, EventArgs e)
        {
                if (_dialogType == 0)
                {
                    AddCaseButton.Visible = true;
                    panel1.Visible = false;
                    AddBreakButton.Visible = false;
                }
                else if (_dialogType == 1)
                {
                    AddCaseButton.Visible = false;
                    panel1.Visible = true;
                    AddBreakButton.Visible = false;
                }
                else if (_dialogType == 2)
                {
                    AddCaseButton.Visible = false;
                    panel1.Visible = true;
                    AddBreakButton.Visible = true;
                }
            }

        private void AddCaseButton_Click(object sender, EventArgs e)
        {
                _me = _statementFactory?.CreateCaseControl() ?? new CaseControl();
                Confirmation(_me);
            }

        private void AddReturnMold_Click(object sender, EventArgs e)
        {
                _me = _statementFactory?.CreateReturnMold() ?? new ReturnMold();
                Confirmation(_me);
            }

        private void AddAssignmentButton_Click(object sender, EventArgs e)
        {
                _me = _statementFactory?.CreateAssignment() ?? new Assignment();
                Confirmation(_me);
            }

        private void Button1_Click(object sender, EventArgs e)
        {
                _me = _statementFactory?.CreateAddMethod() ?? new AddMethod();
                Confirmation(_me);
            }
    }
}
