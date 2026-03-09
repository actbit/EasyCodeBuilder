using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using EasyCodeBuilder.Application.Interfaces;
using EasyCodeBuilder.Core.Interfaces;
using EasyCodeBuilder.Core.Models;

namespace EasyCodeBuilder.Infrastructure.Services
{
    /// <summary>
    /// 入力値検証サービスの実装
    /// </summary>
    public class ValidationService : IValidationService
    {
        private readonly IMessageBoxService _messageBoxService;

        public ValidationService(IMessageBoxService messageBoxService)
        {
            _messageBoxService = messageBoxService;
        }

        public ValidationResult CheckNumber(string value, bool isError)
        {
            if (string.IsNullOrEmpty(value))
            {
                return ValidationResult.Success();
            }

            if (int.TryParse(value, out _))
            {
                return ValidationResult.Success();
            }

            var message = "入力が不正です";
            _messageBoxService.ShowValidationError(message, isError);
            return ValidationResult.Failure(message);
        }

        public ValidationResult CheckName(string name, bool isError)
        {
            if (string.IsNullOrEmpty(name))
            {
                return ValidationResult.Success();
            }

            // 数字で始まる名前をチェック
            if (Regex.IsMatch(name, "^[0-9]"))
            {
                var message = "初めの文字が数、又はループで使われるの文字になっています。";
                _messageBoxService.ShowValidationError(message, isError);
                return ValidationResult.Failure(message);
            }

            // 全て'i'かチェック（ループ変数として予約）
            bool allSameChar = true;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] != 'i')
                {
                    allSameChar = false;
                    break;
                }
            }

            if (allSameChar)
            {
                var message = "初めの文字が数、又はループで使われるの文字になっています。";
                _messageBoxService.ShowValidationError(message, isError);
                return ValidationResult.Failure(message);
            }

            // 空白のみチェック
            if (string.IsNullOrWhiteSpace(name))
            {
                var message = "文字が入力されていないかスペースのみになっています。";
                _messageBoxService.ShowValidationError(message, isError);
                return ValidationResult.Failure(message);
            }

            return ValidationResult.Success();
        }

        public ValidationResult CheckValue(string type, string value, bool isError)
        {
            if (string.IsNullOrWhiteSpace(value) && isError)
            {
                var message = "文字が入力されていないかスペースのみになっています。";
                _messageBoxService.ShowValidationError(message, isError);
                return ValidationResult.Failure(message);
            }

            switch (type)
            {
                case "int":
                    if (!int.TryParse(value, out _))
                    {
                        var message = "入力が不正です";
                        _messageBoxService.ShowValidationError(message, isError);
                        return ValidationResult.Failure(message);
                    }
                    break;

                case "double":
                    if (!double.TryParse(value, out _))
                    {
                        var message = "入力が不正です";
                        _messageBoxService.ShowValidationError(message, isError);
                        return ValidationResult.Failure(message);
                    }
                    break;

                case "string":
                    // 文字列は常に有効
                    break;

                case "bool":
                    if (value != "true" && value != "false")
                    {
                        var message = "入力が不正です";
                        _messageBoxService.ShowValidationError(message, isError);
                        return ValidationResult.Failure(message);
                    }
                    break;

                case "char":
                    if (!Regex.IsMatch(value, "[0-1a-zA-Z]?"))
                    {
                        var message = "入力が不正、又は対応していません";
                        _messageBoxService.ShowValidationError(message, isError);
                        return ValidationResult.Failure(message);
                    }
                    break;

                case "byte":
                    if (!byte.TryParse(value, out _))
                    {
                        var message = "入力が不正です";
                        _messageBoxService.ShowValidationError(message, isError);
                        return ValidationResult.Failure(message);
                    }
                    break;
            }

            return ValidationResult.Success();
        }

        public ValidationResult CheckVariableAssignment(string variableName, string value, Dictionary<string, string> typeDictionary, bool isError)
        {
            if (!typeDictionary.ContainsKey(variableName))
            {
                var message = "変数が見つかりません";
                _messageBoxService.ShowValidationError(message, isError);
                return ValidationResult.Failure(message);
            }

            var variableType = typeDictionary[variableName];
            bool isValid = true;
            string errorMessage = "値が型にあっていません";

            switch (variableType)
            {
                case "int":
                    isValid = int.TryParse(value, out _);
                    break;
                case "double":
                    isValid = double.TryParse(value, out _);
                    break;
                case "byte":
                    isValid = byte.TryParse(value, out _);
                    break;
                case "bool":
                    if (value != "true" && value != "false")
                    {
                        errorMessage = "この型はtrueかfalseのみ対応しています";
                        isValid = false;
                    }
                    break;
                case "char":
                    isValid = char.TryParse(value, out _);
                    break;
            }

            if (!isValid)
            {
                _messageBoxService.ShowValidationError(errorMessage, isError);
                return ValidationResult.Failure(errorMessage);
            }

            return ValidationResult.Success();
        }

        public ValidationResult CheckVariableCompatibility(string variableName1, string variableName2, Dictionary<string, string> typeDictionary, bool isError)
        {
            if (!typeDictionary.ContainsKey(variableName1) || !typeDictionary.ContainsKey(variableName2))
            {
                var message = "現在使われていない変数です";
                _messageBoxService.ShowValidationError(message, isError);
                return ValidationResult.Failure(message);
            }

            if (typeDictionary[variableName1] != typeDictionary[variableName2])
            {
                var message = "型が異なります";
                _messageBoxService.ShowValidationError(message, isError);
                return ValidationResult.Failure(message);
            }

            return ValidationResult.Success();
        }
    }
}
