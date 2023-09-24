using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBD
{
    public class StringColumn : Column
    {
        public override string Type { get; } = "STRING";
        public StringColumn(string name) : base(name) { }

        public override bool Validate(string value) => true;
    }
}
