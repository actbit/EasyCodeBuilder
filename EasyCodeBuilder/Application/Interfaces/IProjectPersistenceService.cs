using EasyCodeBuilder;

namespace EasyCodeBuilder.Application.Interfaces
{
    /// <summary>
    /// プロジェクト永続化サービスのインターフェース
    /// </summary>
    public interface IProjectPersistenceService
    {
        /// <summary>
        /// プロジェクトをXMLファイルに保存します
        /// </summary>
        /// <param name="filePath">保存先パス</param>
        /// <param name="programDefine">プログラム定義</param>
        void SaveProject(string filePath, ProgramDefine programDefine);

        /// <summary>
        /// XMLファイルからプロジェクトを読み込みます
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <returns>プログラム定義</returns>
        ProgramDefine LoadProject(string filePath);

        /// <summary>
        /// プロジェクトをXML文字列に変換します
        /// </summary>
        /// <param name="programDefine">プログラム定義</param>
        /// <returns>XML文字列</returns>
        string ToXmlString(ProgramDefine programDefine);
    }
}
