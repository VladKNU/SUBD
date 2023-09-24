using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBD
{
    public class IntColumn : Column
    {
        public override string Type { get; } = "INT";
        public IntColumn(string name) : base(name) { }

        public override bool Validate(string value) => int.TryParse(value, out _);
    }
}
