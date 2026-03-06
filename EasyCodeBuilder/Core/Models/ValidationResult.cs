namespace EasyCodeBuilder.Core.Models
{
    /// <summary>
    /// 検証結果を表すクラス
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// 検証が成功したかどうか
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// エラーメッセージ (成功時はnull)
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 成功結果を作成します
        /// </summary>
        public static ValidationResult Success() => new ValidationResult { IsValid = true };

        /// <summary>
        /// 失敗結果を作成します
        /// </summary>
        /// <param name="errorMessage">エラーメッセージ</param>
        public static ValidationResult Failure(string errorMessage) => new ValidationResult
        {
            IsValid = false,
            ErrorMessage = errorMessage
        };
    }
}
