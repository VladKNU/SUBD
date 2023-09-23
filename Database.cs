using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBD
{
    public class Database
    {
        public string Name { get; set; }
        public List<Table> Tables { get; set; } = new List<Table>();

        public Database(string _name) => Name = _name;
    }
}
