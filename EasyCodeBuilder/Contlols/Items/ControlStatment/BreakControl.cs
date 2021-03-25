using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyCodeBuilder
{
    public partial class BreakControl : StatementBase
    {
        public BreakControl()
        {
            InitializeComponent();
        }
        public override string CodeOutput(int level)
        {
            string levelString = new string('\t', level);
            return levelString + "break";
        }
        public override Statement CreateProgramDefine()
        {
            XmlBreak Break = new XmlBreak();
            return Break;
        }
    }
}
