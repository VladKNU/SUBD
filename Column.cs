using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBD
{
    public abstract class Column
    {
        public string Name { get; set; }
        public abstract string Type { get; }

        public Column(string _name) => Name = _name;

        public abstract bool Validate(string value);
    }
}
