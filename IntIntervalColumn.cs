using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBD
{
    public class IntIntervalColumn : Column
    {
        public new string Type { get; } = "INT INTERVAL";
        public IntIntervalColumn(string name) : base(name) { }

        public override bool Validate(string value)
        {
            string[] buf = value.Replace(" ", "").Split(',');

            return buf.Length == 2 && int.TryParse(buf[0], out int a) &&
              int.TryParse(buf[1], out int b) && a < b;
        }
    }
}
