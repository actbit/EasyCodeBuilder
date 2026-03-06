using EasyCodeBuilder.Application.Interfaces;
using EasyCodeBuilder.Contlols.Items;

namespace EasyCodeBuilder.Infrastructure.Services
{
    /// <summary>
    /// ステートメントコントロール生成ファクトリーの実装
    /// </summary>
    public class StatementFactory : IStatementFactory
    {
        public VariableDefine CreateVariableDefine()
        {
            return new VariableDefine();
        }

        public OutputConsole CreateOutputConsole()
        {
            return new OutputConsole();
        }

        public InputConsole CreateInputConsole()
        {
            return new InputConsole();
        }

        public Conditions CreateConditions()
        {
            return new Conditions();
        }

        public Loop CreateLoop()
        {
            return new Loop();
        }

        public Calculation CreateCalculation()
        {
            return new Calculation();
        }

        public ArrayDefine CreateArrayDefine()
        {
            return new ArrayDefine();
        }

        public ListDefine CreateListDefine()
        {
            return new ListDefine();
        }

        public BreakControl CreateBreakControl()
        {
            return new BreakControl();
        }

        public CaseControl CreateCaseControl()
        {
            return new CaseControl();
        }

        public ReturnMold CreateReturnMold()
        {
            return new ReturnMold();
        }

        public Assignment CreateAssignment()
        {
            return new Assignment();
        }

        public AddMethod CreateAddMethod()
        {
            return new AddMethod();
        }
    }
}
