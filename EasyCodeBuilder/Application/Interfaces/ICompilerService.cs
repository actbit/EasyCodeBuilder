using System;
using System.CodeDom.Compiler;

namespace EasyCodeBuilder.Application.Interfaces
{
    /// <summary>
    /// コンパイラサービスのインターフェース
    /// </summary>
    public interface ICompilerService
    {
        /// <summary>
        /// コンパイル完了時に発生するイベント
        /// </summary>
        event EventHandler<CompileResult> CompileCompleted;

        /// <summary>
        /// ソースコードを実行可能ファイルにコンパイルします
        /// </summary>
        /// <param name="sourceCode">ソースコード</param>
        /// <param name="outputPath">出力先パス</param>
        /// <returns>コンパイル結果</returns>
        CompileResult Compile(string sourceCode, string outputPath);

        /// <summary>
        /// コンパイルして一時ファイルとして実行します
        /// </summary>
        /// <param name="sourceCode">ソースコード</param>
        /// <returns>コンパイル結果</returns>
        CompileResult CompileAndRun(string sourceCode);

        /// <summary>
        /// 実行中のプロセスを終了します
        /// </summary>
        void TerminateRunningProcess();
    }

    /// <summary>
    /// コンパイル結果
    /// </summary>
    public class CompileResult : EventArgs
    {
        /// <summary>
        /// 成功したかどうか
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// エラーメッセージ
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 生成された実行ファイルのパス
        /// </summary>
        public string OutputPath { get; set; }

        /// <summary>
        /// コンパイルエラーのリスト
        /// </summary>
        public CompilerErrorCollection Errors { get; set; }
    }
}
