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
    public partial class MethodVariable : UserControl
    {
        public MethodVariable()
        {
            InitializeComponent();
        }

        private void MethodVariable_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(Type.TypeList().ToArray());
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            AddMethod AM = (AddMethod)this.Parent.Parent;
            AM.DelButton(this);
        }
    }
}
