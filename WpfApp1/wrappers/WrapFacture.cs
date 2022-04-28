using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.modèles;

namespace WpfApp1.wrappers
{
    internal class WrapFacture
    {
        SqliteConnection sqlite_conn = new SqliteConnection("Data Source=GPB_BDD.bd");

        public void createFacture(Facture facture)
        {
            sqlite_conn.Open();
            SqliteCommand sqlCommand = sqlite_conn.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO facture VALUES ('" + facture._Id + "','" + facture._TempsEffectif+ "','" + facture._CoutEffectif + "','" + facture._Commentaire + "')";
            Console.WriteLine(sqlCommand.CommandText);
            SqliteDataReader rdr = sqlCommand.ExecuteReader();
        }
        // A noter quand on recup les données avec GetInt32() alors que c'est un string la fonction return 0; 
        // et pareil our GetString()
        public Facture readFacture(int id)
        {
            sqlite_conn.Open();
            SqliteCommand sqlCommand = sqlite_conn.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM facture WHERE facture=" + id;
            SqliteDataReader rdr = sqlCommand.ExecuteReader();
            return convertDataToObject(rdr);
        }
        public void updateFacture(Facture facture)
        {
            sqlite_conn.Open();
            SqliteCommand sqlCommand = sqlite_conn.CreateCommand();
            var args = new Dictionary<string, object>
            {
                {"@id", facture._Id},
                {"@tempsEffectif", facture._TempsEffectif},
                {"@coutEffectif", facture._CoutEffectif},
                {"@com", facture._Commentaire }
            };

            sqlCommand.CommandText = "UPDATE facture SET temps_effectif = @tempsEffectif, cout_effectif = @coutEffectif, facture_com = @com WHERE Id = @id";
            sqlCommand.ExecuteNonQuery();
        }
        public void deleteFacture(Facture facture)
        {
            sqlite_conn.Open();
            SqliteCommand sqlCommand = sqlite_conn.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM facture WHERE id_facture=" + facture._Id;
            sqlCommand.ExecuteNonQuery();

        }
        //je sais que je peux use le constructeur mais je pref comme ca
        private Facture convertDataToObject(SqliteDataReader reader)
        {
            Facture facture= new Facture();
            facture._Id = reader.GetInt32(0);
            facture._TempsEffectif = reader.GetInt32(1);
            facture._CoutEffectif= reader.GetInt32(2);
            facture._Commentaire = reader.GetString(3);
            return facture;
        }

        private void logFacturefromBDD(SqliteDataReader reader)
        {
            while (reader.Read())
            {
                Console.WriteLine($@"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetString(3)}");
            }
        }
    }
}
