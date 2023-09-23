using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBD
{
    public class Table
    {
        public string Name { get; set; }
        public List<Row> Rows { get; set; } = new List<Row>();
        public List<Column> Columns { get; set; } = new List<Column>();

        public Table(string _name) => Name = _name;
    }
}
