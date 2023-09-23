using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBD
{
    public class CharColumn : Column
    {
        public new string Type { get; } = "CHAR";
        public CharColumn(string name) : base(name) { }

        public override bool Validate(string value) => char.TryParse(value, out _);
    }
}
