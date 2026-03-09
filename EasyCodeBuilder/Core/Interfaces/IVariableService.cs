using System.Collections.Generic;

namespace EasyCodeBuilder.Core.Interfaces
{
    /// <summary>
    /// 変数管理サービスのインターフェース
    /// </summary>
    public interface IVariableService
    {
        /// <summary>
        /// 現在のスコープで使用可能な変数名のリストを取得します
        /// </summary>
        /// <param name="control">基準となるコントロール</param>
        /// <param name="typeFilter">型フィルター (0:全て, 1:数値型, 2:文字列型, etc.)</param>
        /// <returns>変数名のリスト</returns>
        List<string> GetVariableList(object control, int typeFilter);

        /// <summary>
        /// 変数名とその型のマッピングを取得します
        /// </summary>
        /// <param name="control">基準となるコントロール</param>
        /// <returns>変数名と型のディクショナリ</returns>
        Dictionary<string, string> GetVariableTypes(object control);

        /// <summary>
        /// 使用されている変数のリストを取得します
        /// </summary>
        /// <param name="control">基準となるコントロール</param>
        /// <returns>使用されている変数名のリスト</returns>
        List<string> GetUsedVariables(object control);

        /// <summary>
        /// 現在のコード生成セッションで使用されている変数名をクリアします
        /// </summary>
        void ClearSessionVariables();

        /// <summary>
        /// セッション変数に名前を追加します
        /// </summary>
        /// <param name="name">変数名</param>
        void AddSessionVariable(string name);

        /// <summary>
        /// セッション変数に名前が含まれるか確認します
        /// </summary>
        /// <param name="name">変数名</param>
        /// <returns>含まれる場合true</returns>
        bool ContainsSessionVariable(string name);
    }
}
