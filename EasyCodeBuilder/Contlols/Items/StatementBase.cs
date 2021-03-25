using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyCodeBuilder
{
    public partial class StatementBase : UserControl
    {
        public StatementBase()
        {
            InitializeComponent();
        }

        private void StatementBase_Load(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ((StatementBlock)this.Parent).RemoveStatement(this);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ((StatementBlock)this.Parent).UpStatement(this);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ((StatementBlock)this.Parent).DownStatement(this);
        }
        public virtual void Sorting()
        {
        }
        public virtual String CodeOutput(int level)
        {
            return "\r\n";
        }
        public virtual Statement CreateProgramDefine()
        {
            return null;
        }
        public virtual void ControlSetup(Statement name)
        {

        }
        public virtual void ChangeName(string Aftername,string Beforename,bool type)
        {
            
        }


    }
}
