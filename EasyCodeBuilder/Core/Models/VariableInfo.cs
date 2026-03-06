namespace EasyCodeBuilder.Core.Models
{
    /// <summary>
    /// 変数情報を表すクラス
    /// </summary>
    public class VariableInfo
    {
        /// <summary>
        /// 変数名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 変数の型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 初期値
        /// </summary>
        public string InitialValue { get; set; }

        /// <summary>
        /// 初期化するかどうか
        /// </summary>
        public bool HasInitialValue { get; set; }
    }
}
