using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBD
{
    public class StringIntervalColumn : Column
    {
        public override string Type { get; } = "STRING INTERVAL";
        public StringIntervalColumn(string name) : base(name) { }

        public override bool Validate(string value)
        {
            string[] parts = value.Split(',');

            if (parts.Length != 2)
            {
                return false;
            }

            string start = parts[0].Trim();
            string end = parts[1].Trim();

            return string.Compare(start, end) < 0;
        }

    }
}
