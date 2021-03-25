using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EasyCodeBuilder
{
    
    [XmlRoot("ProgramDefine")]
    public class ProgramDefine
    {
        [XmlElement(ElementName = "Block")]
        public Block Block = new Block();

    }
    public class Block
    {
        public List<Statement> Statement = new List<Statement>();
    }


    [XmlInclude(typeof(XmlArray))]
    [XmlInclude(typeof(XmlImputC))]
    [XmlInclude(typeof(XmlVariable))]
    [XmlInclude(typeof(XmlCondition))]
    [XmlInclude(typeof(XmlOutputC))]
    [XmlInclude(typeof(XmlCase))]
    [XmlInclude(typeof(XmlLoop))]
    [XmlInclude(typeof(XmlBreak))]
    [XmlInclude(typeof(XmlCalculation))]
    [XmlInclude(typeof(XmlMold))]
    [XmlInclude(typeof(XmlAssignment))]
    public class Statement
    {

    }
    public class XmlVariable : Statement
    {
        [XmlElement(ElementName = "Type")]
        public int Type;
        [XmlElement(ElementName = "Name")]
        public String Name;
        [XmlElement(ElementName = "Substitute")]
        public bool Substitute;
        [XmlElement(ElementName = "Value")]
        public String Value;

    }
    public class XmlCondition : Statement
    {
        [XmlElement(ElementName = "ConditionType")]
        public int ConditionType;

        [XmlElement(ElementName = "Value1")]
        public string Value1;

        [XmlElement(ElementName = "Operator")]
        public int Opreater;

        [XmlElement(ElementName = "Constant")]
        public bool Constant;

        [XmlElement(ElementName = "UseElse")]
        public bool UseElse;

        [XmlElement(ElementName = "Value2")]
        public string Value2;

        [XmlElement(ElementName = "Block1")]
        public Block Block1 = new Block();

        [XmlElement(ElementName = "Block2")]
        public Block Block2 = new Block();
    }
    public class XmlImputC : Statement
    {
        [XmlElement(ElementName = "Variable")]
        public string Variable;
    }
    public class XmlArray : Statement
    {
        [XmlElement(ElementName = "Type")]
        public int Type;
        [XmlElement(ElementName = "Name")]
        public string Name;
        [XmlElement(ElementName = "ArrayNumber")]
        public string ArrayNumber;
    }
    public class XmlOutputC : Statement
    {
        public List<XmlAddOutput> Objects = new List<XmlAddOutput>();
    }
    public class XmlAddOutput
    {
        [XmlElement(ElementName = "Value")]
        public string Value;
        [XmlElement(ElementName = "IsVariable")]
        public bool Isvariable;

    }
    public class XmlCase : Statement
    {
        [XmlElement(ElementName = "Condition")]
        public string Condition;
        [XmlElement(ElementName = "Block")]
        public Block Block;
    }
    public class XmlLoop : Statement
    {
        [XmlElement(ElementName = "LoopType")]
        public int LoopType;
        [XmlElement(ElementName = "WhileValue1")]
        public string WhileValue;
        [XmlElement(ElementName = "WhileOperator")]
        public int WhileOperator;
        [XmlElement(ElementName = "WhileValue2")]
        public string WhileValue2;
        [XmlElement(ElementName = "ForNumber")]
        public string ForNumber;
        [XmlElement(ElementName = "Constant")]
        public bool Constant;
        [XmlElement(ElementName = "Infinite")]
        public bool Infintite;
        [XmlElement(ElementName = "Block")]
        public Block Block = new Block();
    }
    public class XmlBreak : Statement
    {

    }

    public class XmlCalculation : Statement
    {
        [XmlElement(ElementName = "Variable")]
        public string Variable;
        [XmlElement(ElementName = "Variable2")]
        public string Variable2;
        [XmlElement(ElementName = "Variable3")]
        public string Variable3;
        [XmlElement(ElementName = "Type")]
        public int Type;
        [XmlElement(ElementName = "constant1")]
        public bool constant1;
        [XmlElement(ElementName = "constant2")]
        public bool constant2;
    }

    public class XmlMold : Statement
    {
        [XmlElement(ElementName = "InVariable")]
        public string InVariable;
        [XmlElement(ElementName = "OutVariable")]
        public string OutVariable;
        [XmlElement(ElementName = "BoolVariable")]
        public string BooolVariable;
        [XmlElement(ElementName = "BoolOnOf")]
        public bool BoolOnOf;
    }
    public class XmlAssignment : Statement
    {
        [XmlElement(ElementName = "Variable1")]
        public string Variable1;
        [XmlElement(ElementName = "Variable2")]
        public string Variable2;
        [XmlElement(ElementName = "TypeXml")]
        public int TypeXml;
        [XmlElement(ElementName = "Constant")]
        public bool Constant;
    }
}
