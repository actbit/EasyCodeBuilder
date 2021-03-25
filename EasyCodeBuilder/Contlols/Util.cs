using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyCodeBuilder
{
    class Util
    {

        public static List<String> GetVariableList(Control MyControl, int Type)
        {
            List<string> vList = new List<string>();
            Control MyParent = MyControl.Parent;
            StatementBlock MystatementBlock = (StatementBlock)MyParent;
            List<StatementBase> OrderControls = new List<StatementBase>();
            OrderControls = MystatementBlock.GetOrderControls();
            if (Type == 0)
            {
                for (int i = 0; OrderControls[i] != MyControl; i++)
                {
                    if (OrderControls[i].GetType().Equals(typeof(VariableDefine)))
                    {
                        VariableDefine variableDefineName = (VariableDefine)OrderControls[i];
                        if (string.IsNullOrWhiteSpace(variableDefineName.textBox1.Text) == false || string.IsNullOrEmpty(variableDefineName.comboBox1.Text) == false)
                        {
                            vList.Add(variableDefineName.textBox1.Text);
                        }
                            

                    }
                    else if (OrderControls[i].GetType().Equals(typeof(ArrayDefine)))
                    {
                        ArrayDefine arrayDefineName = (ArrayDefine)OrderControls[i];
                        if (string.IsNullOrWhiteSpace(arrayDefineName.textBox1.Text) == false && string.IsNullOrEmpty(arrayDefineName.arrayType.Text) == false && string.IsNullOrWhiteSpace(arrayDefineName.textBox2.Text) == false)
                        {
                            for (int j = 0; j < int.Parse(arrayDefineName.textBox2.Text); j++)
                            {
                                vList.Add(arrayDefineName.textBox1.Text + "[" + j + "]");
                            }
                        }
 
                    }

                }

            }
            if (Type == 1)
            {

                for (int i = 0; OrderControls[i] != MyControl; i++)
                {

                    if (OrderControls[i].GetType().Equals(typeof(VariableDefine)))
                    {

                        VariableDefine variableDefineName = (VariableDefine)OrderControls[i];
                        if (variableDefineName.comboBox1.SelectedIndex == 0 || variableDefineName.comboBox1.SelectedIndex == 3 || variableDefineName.comboBox1.SelectedIndex == 4)
                        {
                            if (string.IsNullOrWhiteSpace(variableDefineName.textBox1.Text) == false || string.IsNullOrEmpty(variableDefineName.comboBox1.Text) == false)
                            {
                                vList.Add(variableDefineName.textBox1.Text);
                            }

                        }


                    }
                    else if (OrderControls[i].GetType().Equals(typeof(ArrayDefine)))
                    {
                        ArrayDefine arrayDefineName = (ArrayDefine)OrderControls[i];
                        if (arrayDefineName.arrayType.SelectedIndex == 0 || arrayDefineName.arrayType.SelectedIndex == 3 || arrayDefineName.arrayType.SelectedIndex == 4)
                        {
                            if (string.IsNullOrWhiteSpace(arrayDefineName.textBox1.Text) == false && string.IsNullOrEmpty(arrayDefineName.arrayType.Text) == false && string.IsNullOrWhiteSpace(arrayDefineName.textBox2.Text) == false)
                            {
                                for (int j = 0; j < int.Parse(arrayDefineName.textBox2.Text); j++)
                                {
                                    vList.Add(arrayDefineName.textBox1.Text + "[" + j + "]");
                                }
                            }

                        }

                    }

                }

            }
            if (Type == 2)
            {
                for (int i = 0; OrderControls[i] != MyControl; i++)
                {
                    
                    if (OrderControls[i].GetType().Equals(typeof(VariableDefine)))
                    {
                        
                        VariableDefine variableDefineName = (VariableDefine)OrderControls[i];
                        if (variableDefineName.comboBox1.SelectedIndex == 1)
                        {
                            if (string.IsNullOrWhiteSpace(variableDefineName.textBox1.Text) == false || string.IsNullOrEmpty(variableDefineName.comboBox1.Text) == false)
                            {
                                vList.Add(variableDefineName.textBox1.Text);
                            }
                                
                        }


                    }
                    else if (OrderControls[i].GetType().Equals(typeof(ArrayDefine)))
                    {
                        ArrayDefine arrayDefineName = (ArrayDefine)OrderControls[i];
                        if (arrayDefineName.arrayType.SelectedIndex == 1)
                        {
                            if (string.IsNullOrWhiteSpace(arrayDefineName.textBox1.Text) == false && string.IsNullOrEmpty(arrayDefineName.arrayType.Text) == false && string.IsNullOrWhiteSpace(arrayDefineName.textBox2.Text) == false)
                            {
                                for (int j = 0; j < int.Parse(arrayDefineName.textBox2.Text); j++)
                                {
                                    vList.Add(arrayDefineName.textBox1.Text + "[" + j + "]");
                                }
                            }
   
                        }

                    }

                }
            }
            if (Type == 3)
            {

                for (int i = 0; OrderControls[i] != MyControl; i++)
                {

                    if (OrderControls[i].GetType().Equals(typeof(VariableDefine)))
                    {

                        VariableDefine variableDefineName = (VariableDefine)OrderControls[i];
                        if (variableDefineName.comboBox1.SelectedIndex == 0 || variableDefineName.comboBox1.SelectedIndex == 1|| variableDefineName.comboBox1.SelectedIndex == 3 || variableDefineName.comboBox1.SelectedIndex == 4)
                        {
                            if (string.IsNullOrWhiteSpace(variableDefineName.textBox1.Text) == false || string.IsNullOrEmpty(variableDefineName.comboBox1.Text) == false)
                            {
                                vList.Add(variableDefineName.textBox1.Text);
                            }

                        }


                    }
                    else if (OrderControls[i].GetType().Equals(typeof(ArrayDefine)))
                    {
                        ArrayDefine arrayDefineName = (ArrayDefine)OrderControls[i];
                        if (arrayDefineName.arrayType.SelectedIndex == 0 || arrayDefineName.arrayType.SelectedIndex == 1 || arrayDefineName.arrayType.SelectedIndex == 3 || arrayDefineName.arrayType.SelectedIndex == 4)
                        {
                            if (string.IsNullOrWhiteSpace(arrayDefineName.textBox1.Text) == false && string.IsNullOrEmpty(arrayDefineName.arrayType.Text) == false && string.IsNullOrWhiteSpace(arrayDefineName.textBox2.Text) == false)
                            {
                                for (int j = 0; j < int.Parse(arrayDefineName.textBox2.Text); j++)
                                {
                                    vList.Add(arrayDefineName.textBox1.Text + "[" + j + "]");
                                }
                            }

                        }

                    }

                }

            }
            if (Type == 4)
            {

                for (int i = 0; OrderControls[i] != MyControl; i++)
                {

                    if (OrderControls[i].GetType().Equals(typeof(VariableDefine)))
                    {

                        VariableDefine variableDefineName = (VariableDefine)OrderControls[i];
                        if (variableDefineName.comboBox1.SelectedIndex == 5 )
                        {
                            if (string.IsNullOrWhiteSpace(variableDefineName.textBox1.Text) == false || string.IsNullOrEmpty(variableDefineName.comboBox1.Text) == false)
                            {
                                vList.Add(variableDefineName.textBox1.Text);
                            }

                        }


                    }
                    else if (OrderControls[i].GetType().Equals(typeof(ArrayDefine)))
                    {
                        ArrayDefine arrayDefineName = (ArrayDefine)OrderControls[i];
                        if (arrayDefineName.arrayType.SelectedIndex == 5)
                        {
                            if (string.IsNullOrWhiteSpace(arrayDefineName.textBox1.Text) == false && string.IsNullOrEmpty(arrayDefineName.arrayType.Text) == false && string.IsNullOrWhiteSpace(arrayDefineName.textBox2.Text) == false)
                            {
                                for (int j = 0; j < int.Parse(arrayDefineName.textBox2.Text); j++)
                                {
                                    vList.Add(arrayDefineName.textBox1.Text + "[" + j + "]");
                                }
                            }

                        }

                    }

                }

            }
            if (Type == 5)
            {

                for (int i = 0; OrderControls[i] != MyControl; i++)
                {

                    if (OrderControls[i].GetType().Equals(typeof(VariableDefine)))
                    {

                        VariableDefine variableDefineName = (VariableDefine)OrderControls[i];
                        if (variableDefineName.comboBox1.SelectedIndex == 0)
                        {
                            if (string.IsNullOrWhiteSpace(variableDefineName.textBox1.Text) == false || string.IsNullOrEmpty(variableDefineName.comboBox1.Text) == false)
                            {
                                vList.Add(variableDefineName.textBox1.Text);
                            }

                        }


                    }
                    else if (OrderControls[i].GetType().Equals(typeof(ArrayDefine)))
                    {
                        ArrayDefine arrayDefineName = (ArrayDefine)OrderControls[i];
                        if (arrayDefineName.arrayType.SelectedIndex == 0)
                        {
                            if (string.IsNullOrWhiteSpace(arrayDefineName.textBox1.Text) == false && string.IsNullOrEmpty(arrayDefineName.arrayType.Text) == false && string.IsNullOrWhiteSpace(arrayDefineName.textBox2.Text) == false)
                            {
                                for (int j = 0; j < int.Parse(arrayDefineName.textBox2.Text); j++)
                                {
                                    vList.Add(arrayDefineName.textBox1.Text + "[" + j + "]");
                                }
                            }

                        }

                    }

                }

            }
            if (Type == 10)
            {

                for (int i = 0; OrderControls[i] != MyControl; i++)
                {

                    if (OrderControls[i].GetType().Equals(typeof(VariableDefine)))
                    {

                        VariableDefine variableDefineName = (VariableDefine)OrderControls[i];
                        if (variableDefineName.comboBox1.SelectedIndex == 0)
                        {
                            if (string.IsNullOrWhiteSpace(variableDefineName.textBox1.Text) == false || string.IsNullOrEmpty(variableDefineName.comboBox1.Text) == false)
                            {
                                vList.Add(variableDefineName.textBox1.Text);
                            }

                        }


                    }
                    else if (OrderControls[i].GetType().Equals(typeof(ArrayDefine)))
                    {
                        ArrayDefine arrayDefineName = (ArrayDefine)OrderControls[i];
                        if (arrayDefineName.arrayType.SelectedIndex == 0)
                        {
                            if (string.IsNullOrWhiteSpace(arrayDefineName.textBox1.Text) == false && string.IsNullOrEmpty(arrayDefineName.arrayType.Text) == false && string.IsNullOrWhiteSpace(arrayDefineName.textBox2.Text) == false)
                            {
                                for (int j = 0; j < int.Parse(arrayDefineName.textBox2.Text); j++)
                                {
                                    vList.Add(arrayDefineName.textBox1.Text + "[" + j + "]");
                                }
                            }

                        }

                    }

                }

            }
            if (Type == 11)
            {

                for (int i = 0; OrderControls[i] != MyControl; i++)
                {

                    if (OrderControls[i].GetType().Equals(typeof(VariableDefine)))
                    {

                        VariableDefine variableDefineName = (VariableDefine)OrderControls[i];
                        if (variableDefineName.comboBox1.SelectedIndex == 1)
                        {
                            if (string.IsNullOrWhiteSpace(variableDefineName.textBox1.Text) == false || string.IsNullOrEmpty(variableDefineName.comboBox1.Text) == false)
                            {
                                vList.Add(variableDefineName.textBox1.Text);
                            }

                        }


                    }
                    else if (OrderControls[i].GetType().Equals(typeof(ArrayDefine)))
                    {
                        ArrayDefine arrayDefineName = (ArrayDefine)OrderControls[i];
                        if (arrayDefineName.arrayType.SelectedIndex == 1)
                        {
                            if (string.IsNullOrWhiteSpace(arrayDefineName.textBox1.Text) == false && string.IsNullOrEmpty(arrayDefineName.arrayType.Text) == false && string.IsNullOrWhiteSpace(arrayDefineName.textBox2.Text) == false)
                            {
                                for (int j = 0; j < int.Parse(arrayDefineName.textBox2.Text); j++)
                                {
                                    vList.Add(arrayDefineName.textBox1.Text + "[" + j + "]");
                                }
                            }

                        }

                    }

                }

            }
            if (Type == 12)
            {

                for (int i = 0; OrderControls[i] != MyControl; i++)
                {

                    if (OrderControls[i].GetType().Equals(typeof(VariableDefine)))
                    {

                        VariableDefine variableDefineName = (VariableDefine)OrderControls[i];
                        if (variableDefineName.comboBox1.SelectedIndex == 2)
                        {
                            if (string.IsNullOrWhiteSpace(variableDefineName.textBox1.Text) == false || string.IsNullOrEmpty(variableDefineName.comboBox1.Text) == false)
                            {
                                vList.Add(variableDefineName.textBox1.Text);
                            }

                        }


                    }
                    else if (OrderControls[i].GetType().Equals(typeof(ArrayDefine)))
                    {
                        ArrayDefine arrayDefineName = (ArrayDefine)OrderControls[i];
                        if (arrayDefineName.arrayType.SelectedIndex == 2)
                        {
                            if (string.IsNullOrWhiteSpace(arrayDefineName.textBox1.Text) == false && string.IsNullOrEmpty(arrayDefineName.arrayType.Text) == false && string.IsNullOrWhiteSpace(arrayDefineName.textBox2.Text) == false)
                            {
                                for (int j = 0; j < int.Parse(arrayDefineName.textBox2.Text); j++)
                                {
                                    vList.Add(arrayDefineName.textBox1.Text + "[" + j + "]");
                                }
                            }

                        }

                    }

                }

            }
            if (Type == 13)
            {

                for (int i = 0; OrderControls[i] != MyControl; i++)
                {

                    if (OrderControls[i].GetType().Equals(typeof(VariableDefine)))
                    {

                        VariableDefine variableDefineName = (VariableDefine)OrderControls[i];
                        if (variableDefineName.comboBox1.SelectedIndex == 3)
                        {
                            if (string.IsNullOrWhiteSpace(variableDefineName.textBox1.Text) == false || string.IsNullOrEmpty(variableDefineName.comboBox1.Text) == false)
                            {
                                vList.Add(variableDefineName.textBox1.Text);
                            }

                        }


                    }
                    else if (OrderControls[i].GetType().Equals(typeof(ArrayDefine)))
                    {
                        ArrayDefine arrayDefineName = (ArrayDefine)OrderControls[i];
                        if (arrayDefineName.arrayType.SelectedIndex == 3)
                        {
                            if (string.IsNullOrWhiteSpace(arrayDefineName.textBox1.Text) == false && string.IsNullOrEmpty(arrayDefineName.arrayType.Text) == false && string.IsNullOrWhiteSpace(arrayDefineName.textBox2.Text) == false)
                            {
                                for (int j = 0; j < int.Parse(arrayDefineName.textBox2.Text); j++)
                                {
                                    vList.Add(arrayDefineName.textBox1.Text + "[" + j + "]");
                                }
                            }

                        }

                    }

                }

            }
            if (Type == 14)
            {

                for (int i = 0; OrderControls[i] != MyControl; i++)
                {

                    if (OrderControls[i].GetType().Equals(typeof(VariableDefine)))
                    {

                        VariableDefine variableDefineName = (VariableDefine)OrderControls[i];
                        if (variableDefineName.comboBox1.SelectedIndex == 4)
                        {
                            if (string.IsNullOrWhiteSpace(variableDefineName.textBox1.Text) == false || string.IsNullOrEmpty(variableDefineName.comboBox1.Text) == false)
                            {
                                vList.Add(variableDefineName.textBox1.Text);
                            }

                        }


                    }
                    else if (OrderControls[i].GetType().Equals(typeof(ArrayDefine)))
                    {
                        ArrayDefine arrayDefineName = (ArrayDefine)OrderControls[i];
                        if (arrayDefineName.arrayType.SelectedIndex == 4)
                        {
                            if (string.IsNullOrWhiteSpace(arrayDefineName.textBox1.Text) == false && string.IsNullOrEmpty(arrayDefineName.arrayType.Text) == false && string.IsNullOrWhiteSpace(arrayDefineName.textBox2.Text) == false)
                            {
                                for (int j = 0; j < int.Parse(arrayDefineName.textBox2.Text); j++)
                                {
                                    vList.Add(arrayDefineName.textBox1.Text + "[" + j + "]");
                                }
                            }

                        }

                    }

                }
                if (Type == 15)
                {

                    for (int i = 0; OrderControls[i] != MyControl; i++)
                    {

                        if (OrderControls[i].GetType().Equals(typeof(VariableDefine)))
                        {

                            VariableDefine variableDefineName = (VariableDefine)OrderControls[i];
                            if (variableDefineName.comboBox1.SelectedIndex == 5)
                            {
                                if (string.IsNullOrWhiteSpace(variableDefineName.textBox1.Text) == false || string.IsNullOrEmpty(variableDefineName.comboBox1.Text) == false)
                                {
                                    vList.Add(variableDefineName.textBox1.Text);
                                }

                            }


                        }
                        else if (OrderControls[i].GetType().Equals(typeof(ArrayDefine)))
                        {
                            ArrayDefine arrayDefineName = (ArrayDefine)OrderControls[i];
                            if (arrayDefineName.arrayType.SelectedIndex == 5)
                            {
                                if (string.IsNullOrWhiteSpace(arrayDefineName.textBox1.Text) == false && string.IsNullOrEmpty(arrayDefineName.arrayType.Text) == false && string.IsNullOrWhiteSpace(arrayDefineName.textBox2.Text) == false)
                                {
                                    for (int j = 0; j < int.Parse(arrayDefineName.textBox2.Text); j++)
                                    {
                                        vList.Add(arrayDefineName.textBox1.Text + "[" + j + "]");
                                    }
                                }

                            }

                        }

                    }

                }

            }

            if (MyParent.Parent is StatementBase)
            {

                vList.AddRange(GetVariableList(MyParent.Parent, Type));
            }

            return vList;
        }
        /// <summary>
        /// 変数の型を調べます
        /// </summary>
        /// <param name="MyControl"></param>
        /// <returns></returns>
        public static Dictionary<string,string> GetVariableType(Control MyControl)
        {
            Dictionary<string, string> VariableType = new Dictionary<string, string>();
            Control MyParent = MyControl.Parent;
            StatementBlock MystatementBlock = (StatementBlock)MyParent;
            List<StatementBase> OrderControls = new List<StatementBase>();
            OrderControls = MystatementBlock.GetOrderControls();
            for (int i = 0; OrderControls[i] != MyControl; i++)
            {
                if (OrderControls[i].GetType().Equals(typeof(VariableDefine)))
                {
                    
                    VariableDefine variableDefineName = (VariableDefine)OrderControls[i];
                    if (string.IsNullOrWhiteSpace(variableDefineName.textBox1.Text) == false || string.IsNullOrEmpty(variableDefineName.comboBox1.Text) == false)
                    {
                        VariableType.Add(variableDefineName.textBox1.Text,variableDefineName.itemType);
                    }


                }
                else if (OrderControls[i].GetType().Equals(typeof(ArrayDefine)))
                {
                    ArrayDefine arrayDefineName = (ArrayDefine)OrderControls[i];
                    if (string.IsNullOrWhiteSpace(arrayDefineName.textBox1.Text) == false && string.IsNullOrEmpty(arrayDefineName.arrayType.Text) == false&&string.IsNullOrWhiteSpace(arrayDefineName.textBox2.Text)==false)
                    {
                        for (int j = 0; j < int.Parse(arrayDefineName.textBox2.Text); j++)
                        {
                            VariableType.Add(arrayDefineName.textBox1.Text + "[" + j + "]",arrayDefineName.itemType);
                        }    
                    }

                }


            }

            if (MyParent.Parent is StatementBase)
            {
                foreach (KeyValuePair<String, String> keyVal in GetVariableType(MyParent.Parent))
                {
                    VariableType.Add(keyVal.Key, keyVal.Value);
                }


            }
            return VariableType;
        }
        public static List<string> VariableConfirmation(Control My)
        {
            List<string> VariableConfirmationList = new List<string>();
            Control MyParent = My.Parent;
            StatementBlock MystatementBlock = (StatementBlock)MyParent;
            List<StatementBase> OrderControls = new List<StatementBase>();
            OrderControls = MystatementBlock.GetOrderControls();
            for (int i = 0; OrderControls[i] != My; i++)
            {
                if (OrderControls[i].GetType().Equals(typeof(VariableDefine)))
                {
                    VariableDefine variableDefineName = (VariableDefine)OrderControls[i];
                    if (variableDefineName.checkBox1.Checked)
                    {
                        if (variableDefineName.comboBox1.SelectedIndex != 1)
                        {
                            if (string.IsNullOrWhiteSpace(variableDefineName.textBox1.Text) == false || string.IsNullOrEmpty(variableDefineName.comboBox1.Text) == false)
                            {
                                VariableConfirmationList.Add(variableDefineName.textBox1.Text);
                            }
                        }
                        else
                        {
                            VariableConfirmationList.Add(variableDefineName.textBox1.Text);
                        }

                    }
                }
                else if (OrderControls[i].GetType().Equals(typeof(Assignment)))
                {
                    Assignment AssignmentName = (Assignment)OrderControls[i];
                    if (AssignmentName.comboBox1.SelectedIndex!=-1)
                    {
                        VariableConfirmationList.Add(AssignmentName.comboBox1.Text);
                    }

                }
                else if (OrderControls[i].GetType().Equals(typeof(ReturnMold)))
                {
                    ReturnMold ReturnMoldName = (ReturnMold)OrderControls[i];
                    if (ReturnMoldName.comboBox2.SelectedIndex!=-1)
                    {
                        VariableConfirmationList.Add(ReturnMoldName.comboBox2.Text);
                        if (ReturnMoldName.checkBox1.Checked)
                        {
                            if (ReturnMoldName.comboBox3.SelectedIndex==-1)
                            {
                                VariableConfirmationList.Add(ReturnMoldName.comboBox3.Text);
                            }
                        }
                    }

                }
                else if (OrderControls[i].GetType().Equals(typeof(Calculation)))
                {
                    Calculation CalculationName = (Calculation)OrderControls[i];
                    if (CalculationName.comboBox1.SelectedIndex!=-1)
                    {
                        VariableConfirmationList.Add(CalculationName.comboBox1.Text);
                    }
                }
                else if (OrderControls[i].GetType().Equals(typeof(InputConsole)))
                {
                    InputConsole ImputConsoleName = (InputConsole)OrderControls[i];
                    if (ImputConsoleName.comboBox1.SelectedIndex != -1)
                    {
                        VariableConfirmationList.Add(ImputConsoleName.comboBox1.Text);
                    }
                }


                
            }
            if (MyParent.Parent is StatementBase)
            {
                StatementBase GParent = (StatementBase)MyParent.Parent;
                VariableConfirmationList.AddRange(VariableConfirmation(MyParent.Parent));
            }
            return VariableConfirmationList;
        }

    }
}