using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyCodeBuilder
{
    class Type
    {

        public static List<String> TypeList()
        {
            List<String> TypeAddList = new List<String>();
            TypeAddList.Add("int(-2, 147, 483, 648～2, 147, 483, 647の整数)");
            TypeAddList.Add("string　(文字列)");
            TypeAddList.Add("char　(一文字のみの文字)");
            TypeAddList.Add("double　(小数を含む数)");
            TypeAddList.Add("byte　(0～255の整数)");
            TypeAddList.Add("bool　(正しい(true)と正しくない(false)のみ)");
            return TypeAddList;
        }

    }
}
