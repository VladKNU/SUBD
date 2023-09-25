using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBD
{
    public class HtmlFileColumn : Column
    {
        public override string Type { get; } = "HTML FILE";
        public HtmlFileColumn(string name) : base(name) { }

        public override bool Validate(string value) => value.ToLower().EndsWith(".html") && File.Exists(value);
    }
}
