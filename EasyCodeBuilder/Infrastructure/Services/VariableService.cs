using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EasyCodeBuilder.Contlols.Blocks;
using EasyCodeBuilder.Contlols.Items;
using EasyCodeBuilder.Core.Interfaces;

namespace EasyCodeBuilder.Infrastructure.Services
{
    /// <summary>
    /// 変数管理サービスの実装
    /// </summary>
    public class VariableService : IVariableService
    {
        private readonly List<string> _sessionVariables = new List<string>();

        public List<string> GetVariableList(object control, int typeFilter)
        {
            var vList = new List<string>();

            if (!(control is Control myControl))
            {
                return vList;
            }

            Control myParent = myControl.Parent;
            if (!(myParent is StatementBlock myStatementBlock))
            {
                return vList;
            }

            var orderControls = myStatementBlock.GetOrderControls();

            for (int i = 0; i < orderControls.Count && orderControls[i] != myControl; i++)
            {
                var currentControl = orderControls[i];

                if (currentControl is VariableDefine variableDefine)
                {
                    if (ShouldIncludeVariable(variableDefine, typeFilter))
                    {
                        if (!string.IsNullOrWhiteSpace(variableDefine.textBox1.Text) ||
                            !string.IsNullOrEmpty(variableDefine.comboBox1.Text))
                        {
                            vList.Add(variableDefine.textBox1.Text);
                        }
                    }
                }
                else if (currentControl is ArrayDefine arrayDefine)
                {
                    if (ShouldIncludeArray(arrayDefine, typeFilter))
                    {
                        if (!string.IsNullOrWhiteSpace(arrayDefine.textBox1.Text) &&
                            !string.IsNullOrEmpty(arrayDefine.arrayType.Text) &&
                            !string.IsNullOrWhiteSpace(arrayDefine.textBox2.Text)
                            && int.TryParse(arrayDefine.textBox2.Text, out int arraySize))
                        {
                            for (int j = 0; j < arraySize; j++)
                            {
                                vList.Add(arrayDefine.textBox1.Text + "[" + j + "]");
                            }
                        }
                    }
                }
            }

            // 親のスコープも再帰的に検索
            if (myParent.Parent is StatementBase)
            {
                vList.AddRange(GetVariableList(myParent.Parent, typeFilter));
            }

            return vList;
        }

        private bool ShouldIncludeVariable(VariableDefine variable, int typeFilter)
        {
            int selectedIndex = variable.comboBox1.SelectedIndex;

            switch (typeFilter)
            {
                case 0: // 全て
                    return true;
                case 1: // 数値型 (int, double, byte)
                    return selectedIndex == 0 || selectedIndex == 3 || selectedIndex == 4;
                case 2: // 文字列型
                    return selectedIndex == 1;
                case 3: // 数値型と文字列型 (int, string, double, byte)
                    return selectedIndex == 0 || selectedIndex == 1 || selectedIndex == 3 || selectedIndex == 4;
                case 4: // bool型
                    return selectedIndex == 5;
                case 5: // int型のみ
                case 10:
                    return selectedIndex == 0;
                case 11: // string型のみ
                    return selectedIndex == 1;
                case 12: // char型のみ
                    return selectedIndex == 2;
                case 13: // double型のみ
                    return selectedIndex == 3;
                case 14: // byte型のみ
                    return selectedIndex == 4;
                case 15: // bool型のみ
                    return selectedIndex == 5;
                default:
                    return true;
            }
        }

        private bool ShouldIncludeArray(ArrayDefine array, int typeFilter)
        {
            int selectedIndex = array.arrayType.SelectedIndex;

            switch (typeFilter)
            {
                case 0: // 全て
                    return true;
                case 1: // 数値型 (int, double, byte)
                    return selectedIndex == 0 || selectedIndex == 3 || selectedIndex == 4;
                case 2: // 文字列型
                    return selectedIndex == 1;
                case 3: // 数値型と文字列型
                    return selectedIndex == 0 || selectedIndex == 1 || selectedIndex == 3 || selectedIndex == 4;
                case 4: // bool型
                    return selectedIndex == 5;
                case 5: // int型のみ
                case 10:
                    return selectedIndex == 0;
                case 11: // string型のみ
                    return selectedIndex == 1;
                case 12: // char型のみ
                    return selectedIndex == 2;
                case 13: // double型のみ
                    return selectedIndex == 3;
                case 14: // byte型のみ
                    return selectedIndex == 4;
                case 15: // bool型のみ
                    return selectedIndex == 5;
                default:
                    return true;
            }
        }

        public Dictionary<string, string> GetVariableTypes(object control)
        {
            var variableType = new Dictionary<string, string>();

            if (!(control is Control myControl))
            {
                return variableType;
            }

            Control myParent = myControl.Parent;
            if (!(myParent is StatementBlock myStatementBlock))
            {
                return variableType;
            }

            var orderControls = myStatementBlock.GetOrderControls();

            for (int i = 0; i < orderControls.Count && orderControls[i] != myControl; i++)
            {
                var currentControl = orderControls[i];

                if (currentControl is VariableDefine variableDefine)
                {
                    if (!string.IsNullOrWhiteSpace(variableDefine.textBox1.Text) ||
                        !string.IsNullOrEmpty(variableDefine.comboBox1.Text))
                    {
                        variableType.Add(variableDefine.textBox1.Text, variableDefine.itemType);
                    }
                }
                else if (currentControl is ArrayDefine arrayDefine)
                {
                    if (!string.IsNullOrWhiteSpace(arrayDefine.textBox1.Text) &&
                        !string.IsNullOrEmpty(arrayDefine.arrayType.Text) &&
                        !string.IsNullOrWhiteSpace(arrayDefine.textBox2.Text) &&
                        int.TryParse(arrayDefine.textBox2.Text, out int arraySize))
                    {
                        for (int j = 0; j < arraySize; j++)
                        {
                            variableType.Add(arrayDefine.textBox1.Text + "[" + j + "]", arrayDefine.itemType);
                        }
                    }
                }
            }

            // 親のスコープも再帰的に検索
            if (myParent.Parent is StatementBase)
            {
                foreach (var keyVal in GetVariableTypes(myParent.Parent))
                {
                    variableType.Add(keyVal.Key, keyVal.Value);
                }
            }

            return variableType;
        }

        public List<string> GetUsedVariables(object control)
        {
            var usedVariables = new List<string>();

            if (!(control is Control myControl))
            {
                return usedVariables;
            }

            Control myParent = myControl.Parent;
            if (!(myParent is StatementBlock myStatementBlock))
            {
                return usedVariables;
            }

            var orderControls = myStatementBlock.GetOrderControls();

            for (int i = 0; i < orderControls.Count && orderControls[i] != myControl; i++)
            {
                var currentControl = orderControls[i];

                if (currentControl is VariableDefine variableDefine)
                {
                    if (variableDefine.checkBox1.Checked)
                    {
                        usedVariables.Add(variableDefine.textBox1.Text);
                    }
                }
                else if (currentControl is Assignment assignment)
                {
                    if (assignment.comboBox1.SelectedIndex != -1)
                    {
                        usedVariables.Add(assignment.comboBox1.Text);
                    }
                }
                else if (currentControl is ReturnMold returnMold)
                {
                    if (returnMold.comboBox2.SelectedIndex != -1)
                    {
                        usedVariables.Add(returnMold.comboBox2.Text);
                        if (returnMold.checkBox1.Checked && returnMold.comboBox3.SelectedIndex != -1)
                        {
                            usedVariables.Add(returnMold.comboBox3.Text);
                        }
                    }
                }
                else if (currentControl is Calculation calculation)
                {
                    if (calculation.comboBox1.SelectedIndex != -1)
                    {
                        usedVariables.Add(calculation.comboBox1.Text);
                    }
                }
                else if (currentControl is InputConsole inputConsole)
                {
                    if (inputConsole.comboBox1.SelectedIndex != -1)
                    {
                        usedVariables.Add(inputConsole.comboBox1.Text);
                    }
                }
            }

            // 親のスコープも再帰的に検索
            if (myParent.Parent is StatementBase)
            {
                usedVariables.AddRange(GetUsedVariables(myParent.Parent));
            }

            return usedVariables;
        }

        public void ClearSessionVariables()
        {
            _sessionVariables.Clear();
        }

        public void AddSessionVariable(string name)
        {
            if (!_sessionVariables.Contains(name))
            {
                _sessionVariables.Add(name);
            }
        }

        public bool ContainsSessionVariable(string name)
        {
            return _sessionVariables.Contains(name);
        }
    }
}
