using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SUBD
{
    public class Row
    {
        public List<string> Values { get; } = new List<string>();

        public Row(List<string> _values) => Values = _values;

        public string this[int i]
        {
            get => Values[i];
            set => Values[i] = value;
        }
    }
}
