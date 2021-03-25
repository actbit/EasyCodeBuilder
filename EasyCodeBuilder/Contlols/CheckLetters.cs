using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace EasyCodeBuilder
{
    class CheckLetters
    {

        public static void CheckNumbers(string TxetType,bool type)
        {
            int number1;
            if (TxetType == "")
            {
                return;
            }

            if (int.TryParse(TxetType, out number1))
            {

            }
            else
            {
                Form1.MessageBoxValue("入力が不正です",type);
                
            }
        }
        /// <summary>
        /// 名前をチェックする
        /// </summary>
        /// <param name="TextName">名前</param>
        /// <param name="type">True:エラー、False:警告</param>
        public static void CheckName(string TextName,bool type)
        {
            if (TextName == "")
            {
                return;
            }
            bool TrueOrFalse = Regex.IsMatch(TextName, "^[0-9]");
            if (TrueOrFalse == false)
            {
                TrueOrFalse = true;
                for (int i = 0; i < TextName.Length; i++)
                {
                    if (TextName[i]!='i')
                    {
                        TrueOrFalse = false;
                    }
                }
            }
            if (TrueOrFalse == true)
            {
                Form1.MessageBoxValue("初めの文字が数、又はループで使われるの文字になっています。",type);
            }
            if (String.IsNullOrWhiteSpace(TextName) == true)
            {
                Form1.MessageBoxValue("文字が入力されていないかスペースのみになっています。",type);
            }
        }
        public static void CheckValue(string type, string Value, bool Type2)
        {
            switch (type)
            {

                case "int":
                    int a;
                    if (int.TryParse(Value, out a))
                    {

                    }
                    else
                    {
                        Form1.MessageBoxValue("入力が不正です",Type2);
                    }
                    break;
                case "double":
                    double a2;
                    if (double.TryParse(Value, out a2))
                    {

                    }
                    else
                    {
                        Form1.MessageBoxValue("入力が不正です",Type2);
                    }
                    break;
                case "string":
                    break;
                case "bool":
                    if (Value.Length >= 5)
                    {
                        if (Value == "true" || Value == "false")
                        {

                        }
                        else
                        {
                            Form1.MessageBoxValue("入力が不正です", Type2);
                        }
                    }

                    break;
                case "char":
                    bool aa = Regex.IsMatch(Value, "[0-1a-zA-Z]?");
                    if (aa == false)
                    {
                        Form1.MessageBoxValue("入力が不正、又は対応していません",Type2);
                    }
                    break;
                case "byte":
                    byte aiii;
                    if(byte.TryParse(Value,out aiii))
                    {

                    }
                    else
                    {
                        Form1.MessageBoxValue("入力が不正です",Type2);
                    }
                    break;
            }
            if (String.IsNullOrWhiteSpace(Value)&&Type2)
            {
                Form1.MessageBoxValue("文字が入力されていないかスペースのみになっています。",Type2);

                
            }
        }
        /// <summary>
        ///定数が変数に入るかを確認する 
        /// </summary>
        /// <param name="name">変数名</param>
        /// <param name="name2">定数</param>
        /// <param name="TypeDictionary">変数のDictionary</param>
        /// <param name="type">True:エラー False:警告</param>
        public static void CheckVariables(string name, string name2, Dictionary<string, string> TypeDictionary,bool type)
        {
                    switch (TypeDictionary[name])
                    {

                        case "int":
                            int num;
                            if (int.TryParse(name2, out num) == false)
                                Form1.MessageBoxValue("値が型にあっていません",type);
                            break;
                        case "double":
                    double num1;
                            if (double.TryParse(name2, out num1) == false)
                                Form1.MessageBoxValue("値が型にあっていません",type);
                            break;
                        case "byte":
                    byte num2;
                            if (byte.TryParse(name2, out num2) == false)
                                Form1.MessageBoxValue("値が型にあっていません",type);
                            break;
                        case "bool":
                            if (name2.Length >= 5||type==true)
                            {
                                if (name2 == "true" || name2 == "false")
                                {

                                }
                                else
                                {
                                    Form1.MessageBoxValue("この型はtrueかfalseのみ対応しています", type);
                                }
                            }
                                
                            break;
                        case "char":
                    char num3;
                            if (char.TryParse(name2, out num3) == false)
                                Form1.MessageBoxValue("値が型にあっていません", type);
                            break;
                    }

        }
        /// <summary>
        /// 変数と変数を確認
        /// </summary>
        /// <param name="name">変数1</param>
        /// <param name="name1">変数2</param>
        /// <param name="TypeDictionary">変数のDictionary</param>
        /// <param name="type">True:エラー False:警告</param>
        public static void CheckVariablesAndVariables(string name,string name1, Dictionary<string, string> TypeDictionary,bool type)
        {
            if (TypeDictionary.ContainsKey(name) && TypeDictionary.ContainsKey(name1))
            {
                if (TypeDictionary[name] != TypeDictionary[name1])
                {
                    Form1.MessageBoxValue("型が異なります", type);
                }
            }
            else
            {
                Form1.MessageBoxValue("現在使われていない変数です",type);
            }
        }

    }
}
