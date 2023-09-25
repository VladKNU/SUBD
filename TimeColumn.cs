using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBD
{
    public class TimeColumn : Column
    {
        public override string Type { get; } = "TIME";
        public TimeColumn(string name) : base(name) { }

        public override bool Validate(string input)
        {
            TimeSpan dummyOutput;
            return TimeSpan.TryParse(input, out dummyOutput);
        }
    }
}
