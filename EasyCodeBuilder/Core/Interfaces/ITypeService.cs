using System.Collections.Generic;

namespace EasyCodeBuilder.Core.Interfaces
{
    /// <summary>
    /// 型情報提供サービスのインターフェース
    /// </summary>
    public interface ITypeService
    {
        /// <summary>
        /// サポートされる型のリストを取得します
        /// </summary>
        /// <returns>型の説明リスト</returns>
        List<string> GetTypeList();

        /// <summary>
        /// インデックスから型名を取得します
        /// </summary>
        /// <param name="index">型のインデックス</param>
        /// <returns>型名</returns>
        string GetTypeName(int index);

        /// <summary>
        /// 型名からインデックスを取得します
        /// </summary>
        /// <param name="typeName">型名</param>
        /// <returns>インデックス (見つからない場合は-1)</returns>
        int GetTypeIndex(string typeName);
    }
}
