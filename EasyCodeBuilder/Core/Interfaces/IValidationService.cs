using System.Collections.Generic;
using EasyCodeBuilder.Core.Models;

namespace EasyCodeBuilder.Core.Interfaces
{
    /// <summary>
    /// 入力値検証サービスのインターフェース
    /// </summary>
    public interface IValidationService
    {
        /// <summary>
        /// 数値の妥当性を検証します
        /// </summary>
        /// <param name="value">検証する値</param>
        /// <param name="isError">true: エラー, false: 警告</param>
        /// <returns>検証結果</returns>
        ValidationResult CheckNumber(string value, bool isError);

        /// <summary>
        /// 変数名の妥当性を検証します
        /// </summary>
        /// <param name="name">変数名</param>
        /// <param name="isError">true: エラー, false: 警告</param>
        /// <returns>検証結果</returns>
        ValidationResult CheckName(string name, bool isError);

        /// <summary>
        /// 型に応じた値の妥当性を検証します
        /// </summary>
        /// <param name="type">型名</param>
        /// <param name="value">値</param>
        /// <param name="isError">true: エラー, false: 警告</param>
        /// <returns>検証結果</returns>
        ValidationResult CheckValue(string type, string value, bool isError);

        /// <summary>
        /// 変数への代入可能性を検証します
        /// </summary>
        /// <param name="variableName">変数名</param>
        /// <param name="value">代入する値</param>
        /// <param name="typeDictionary">変数の型情報</param>
        /// <param name="isError">true: エラー, false: 警告</param>
        /// <returns>検証結果</returns>
        ValidationResult CheckVariableAssignment(string variableName, string value, Dictionary<string, string> typeDictionary, bool isError);

        /// <summary>
        /// 変数同士の型互換性を検証します
        /// </summary>
        /// <param name="variableName1">変数名1</param>
        /// <param name="variableName2">変数名2</param>
        /// <param name="typeDictionary">変数の型情報</param>
        /// <param name="isError">true: エラー, false: 警告</param>
        /// <returns>検証結果</returns>
        ValidationResult CheckVariableCompatibility(string variableName1, string variableName2, Dictionary<string, string> typeDictionary, bool isError);
    }
}
