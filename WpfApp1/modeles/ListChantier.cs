using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.modeles
{

    internal class ListChantier
    {
        SqliteConnection sqlite_conn = new SqliteConnection("Data Source=GPB_BDD.bd");

        List<Chantier> listChantier = new List<Chantier>();

        public ListChantier()
        {
        }

        
        public void AddChantier(Chantier chantier)
        {
            listChantier.Add(chantier);
        }
        public List<Chantier> getAllChantier()
        {
            sqlite_conn.Open();
            SqliteCommand sqlCommand = sqlite_conn.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM chantier";
            SqliteDataReader rdr = sqlCommand.ExecuteReader();
            List<Chantier> listChantier = new List<Chantier>();
            return listChantier;
        }
    }
}
