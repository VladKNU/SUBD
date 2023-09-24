using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBD
{
    public class TextFileColumn : Column
    {
        public override string Type { get; } = "TEXT FILE";
        public TextFileColumn(string name) : base(name) { }

        public override bool Validate(string value) => value.ToLower().EndsWith(".txt") && File.Exists(value);
    }
}
