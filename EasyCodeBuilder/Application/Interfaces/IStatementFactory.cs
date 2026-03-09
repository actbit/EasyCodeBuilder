using EasyCodeBuilder.Contlols.Items;

namespace EasyCodeBuilder.Application.Interfaces
{
    /// <summary>
    /// ステートメントコントロール生成ファクトリーのインターフェース
    /// </summary>
    public interface IStatementFactory
    {
        /// <summary>
        /// 変数定義コントロールを作成します
        /// </summary>
        VariableDefine CreateVariableDefine();

        /// <summary>
        /// 出力コンソールコントロールを作成します
        /// </summary>
        OutputConsole CreateOutputConsole();

        /// <summary>
        /// 入力コンソールコントロールを作成します
        /// </summary>
        InputConsole CreateInputConsole();

        /// <summary>
        /// 条件分岐コントロールを作成します
        /// </summary>
        Conditions CreateConditions();

        /// <summary>
        /// ループコントロールを作成します
        /// </summary>
        Loop CreateLoop();

        /// <summary>
        /// 計算コントロールを作成します
        /// </summary>
        Calculation CreateCalculation();

        /// <summary>
        /// 配列定義コントロールを作成します
        /// </summary>
        ArrayDefine CreateArrayDefine();

        /// <summary>
        /// リスト定義コントロールを作成します
        /// </summary>
        ListDefine CreateListDefine();

        /// <summary>
        /// breakコントロールを作成します
        /// </summary>
        BreakControl CreateBreakControl();

        /// <summary>
        /// caseコントロールを作成します
        /// </summary>
        CaseControl CreateCaseControl();

        /// <summary>
        /// 戻り値コントロールを作成します
        /// </summary>
        ReturnMold CreateReturnMold();

        /// <summary>
        /// 代入コントロールを作成します
        /// </summary>
        Assignment CreateAssignment();

        /// <summary>
        /// メソッド定義コントロールを作成します
        /// </summary>
        AddMethod CreateAddMethod();
    }
}
