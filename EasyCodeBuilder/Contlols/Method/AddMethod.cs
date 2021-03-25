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
    public partial class AddMethod : StatementBase
    {
        int distanceY;
        int distanceX;
        int IndexNumber = 0;
        List<MethodVariable> MVList = new List<MethodVariable>();
        public AddMethod()
        {
            InitializeComponent();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            MethodVariable MV = new MethodVariable();
            MV.Name = "MV" + IndexNumber.ToString();
            this.panel1.Controls.Add(MV);
            MVList.Add(MV);
            SortingMv();
        }

        public void DelButton(MethodVariable MV)
        {
            //int X;
            //int Y;
            //StatementBlock SB = (StatementBlock)this.Parent;
            //X = SB.AutoScrollPosition.X;
            //Y = SB.AutoScrollPosition.Y;
            panel1.Controls.Remove(MV);
            MVList.Remove(MV);
            SortingMv();
            //SB.AutoScrollPosition = new Point(X, Y);

        }
        private void SortingMv()
        {
            for(int i = 0; i < MVList.Count; i++)
            {
                MethodVariable mv = MVList[i];
                mv.Location = new Point(AutoScrollPosition.X,AutoScrollPosition.Y + 40 * i);
            }
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

        private void AddMethod_Load(object sender, EventArgs e)
        {
            distanceY = this.Height - (this.statementBlock1.Top + this.statementBlock1.Height);
            distanceX = this.Width - (this.statementBlock1.Left + this.statementBlock1.Width);
        }
    }
}
