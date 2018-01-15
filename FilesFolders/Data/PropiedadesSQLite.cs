using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace FilesFolders.Data
{
    class PropiedadesSQLite
    {
        public string ConnectionString { get; set; }
        public SQLiteConnection Connection { get; set; }

    }
}
