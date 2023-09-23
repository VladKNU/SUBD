using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBD
{
    public class RealColumn : Column
    {
        public new string Type { get; } = "REAL";
        public RealColumn(string name) : base(name) { }

        public override bool Validate(string value) => double.TryParse(value, out _);
    }
}
