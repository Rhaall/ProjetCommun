using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using WpfApp1.modeles;

namespace WpfApp1.wrappers
{
    internal class WrapChantier
    {
        SqliteConnection sqlite_conn = new SqliteConnection("Data Source=GPB_BDD.bd");
            
        public void createChantier(Chantier chantier)
        {
            sqlite_conn.Open();
            var sqlCommand = sqlite_conn.CreateCommand();
            //sqlCommand.CommandText = "INSERT INTO chantier VALUES ("+chantier.Id+"",'9 rue julien chavoutier', 'maison36', 'il existe pas'";
        }
    }
}
