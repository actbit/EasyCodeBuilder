using System.Collections.Generic;
using EasyCodeBuilder.Core.Interfaces;

namespace EasyCodeBuilder.Infrastructure.Services
{
    /// <summary>
    /// 型情報提供サービスの実装
    /// </summary>
    public class TypeService : ITypeService
    {
        private readonly List<string> _typeList = new List<string>
        {
            "int(-2, 147, 483, 648～2, 147, 483, 647の整数)",
            "string　(文字列)",
            "char　(一文字のみの文字)",
            "double　(小数を含む数)",
            "byte　(0～255の整数)",
            "bool　(正しい(true)と正しくない(false)のみ)"
        };

        private readonly Dictionary<string, int> _typeIndexMap = new Dictionary<string, int>
        {
            { "int", 0 },
            { "string", 1 },
            { "char", 2 },
            { "double", 3 },
            { "byte", 4 },
            { "bool", 5 }
        };

        public List<string> GetTypeList()
        {
            return new List<string>(_typeList);
        }

        public string GetTypeName(int index)
        {
            if (index < 0 || index >= _typeList.Count)
            {
                return null;
            }

            switch (index)
            {
                case 0: return "int";
                case 1: return "string";
                case 2: return "char";
                case 3: return "double";
                case 4: return "byte";
                case 5: return "bool";
                default: return null;
            }
        }

        public int GetTypeIndex(string typeName)
        {
            if (_typeIndexMap.TryGetValue(typeName, out int index))
            {
                return index;
            }
            return -1;
        }
    }
}
