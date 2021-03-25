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
    public partial class MainMethod : StatementBase
    {
        int distanceY;
        int distanceX;
        public MainMethod()
        {
            InitializeComponent();
        }

        private void MainMethod_Load(object sender, EventArgs e)
        {
            distanceY = this.Height - (this.statementBlock1.Top + this.statementBlock1.Height);
            distanceX = this.Width - (this.statementBlock1.Left + this.statementBlock1.Width);
        }
        public override void Sorting()
        {
            this.Height = this.statementBlock1.Top + this.statementBlock1.Height + distanceY;
            this.Width = this.statementBlock1.Left + this.statementBlock1.Width + distanceX;

            if (this.Parent is StatementBlock)
            {
                ((StatementBlock)this.Parent).Sorting();
            }
        }
    }
}
