using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using WpfApp1.modeles;

namespace WpfApp1.wrappers
{
    //TODO les champs de types listes et elles ne sont pas dans la bdd
    internal class WrapChantier
    {
        SqliteConnection sqlite_conn = new SqliteConnection("Data Source=GPB_BDD.bd");

        public WrapChantier()
        {
        }

        public void createChantier(Chantier chantier)
        {
            sqlite_conn.Open();
            SqliteCommand sqlCommand = sqlite_conn.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO chantier VALUES ('"+chantier._Id+"','"+chantier._Adresse+"','"+chantier._NomChantier+"','"+chantier._Commentaire+"')";
            Console.WriteLine(sqlCommand.CommandText);
            SqliteDataReader rdr = sqlCommand.ExecuteReader();
            //sqlCommand.CommandText = "INSERT INTO chantier VALUES ('0','9 rue julien chavoutier', 'maison36', 'il existe pas');";
        }
        // A noter quand on recup les données avec GetInt32() alors que c'est un string la fonction return 0; 
        // et pareil our GetString()
        public Chantier readChantier(int id)
        {
            sqlite_conn.Open();
            SqliteCommand sqlCommand = sqlite_conn.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM chantier WHERE id_chantier="+id;
            SqliteDataReader rdr = sqlCommand.ExecuteReader();
            return convertDataToObject(rdr);
        }
        public void updateChantier(Chantier chantier)
        {
            sqlite_conn.Open();
            SqliteCommand sqlCommand = sqlite_conn.CreateCommand();
            var args = new Dictionary<string, object>
            {
                {"@id", chantier._Id},
                {"@adresse", chantier._Adresse },
                {"@nom", chantier._NomChantier },
                {"@com", chantier._Commentaire }
            };

            sqlCommand.CommandText = "UPDATE chantier SET adresse = @adresse, nom_chantier = @nom, chantier_com = @com WHERE Id = @id";
            sqlCommand.ExecuteNonQuery();
        }
        public void deleteChantier(Chantier chantier)
        {
            sqlite_conn.Open();
            SqliteCommand sqlCommand = sqlite_conn.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM chantier WHERE id_chantier=" + chantier._Id;
            sqlCommand.ExecuteNonQuery();

        }
       public List<Chantier> searchChantierByName(string name)
       {
            sqlite_conn.Open();
            SqliteCommand sqlCommand = sqlite_conn.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM chantier WHERE nom_chantier=" + name;
            List<Chantier> listChantier = new List<Chantier>();
            SqliteDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Chantier ch = convertDataToObject(reader);
                ch.jToString();
                listChantier.Add(ch);
                Console.WriteLine($@"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetString(3)}");
            }
            return listChantier;
       }

        public List<Chantier> getAllChantier()
        {
            List<Chantier> listChantier = new List<Chantier>();
            sqlite_conn.Open();
            SqliteCommand sqlCommand = sqlite_conn.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM chantier";
            SqliteDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Chantier ch = convertDataToObject(reader);
                ch.jToString();
                Console.WriteLine(ch.jToString());
                listChantier.Add(ch);    
                Console.WriteLine($@"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetString(3)}");
            }
            return listChantier;
        }
        //je sais que j&e peux use le constructeur mais je pref comme ca
        private Chantier convertDataToObject(SqliteDataReader reader)
        {
            Chantier chantier = new Chantier();
            chantier._Id = reader.GetInt32(0);
            chantier._Adresse = reader.GetString(1);
            chantier._NomChantier = reader.GetString(2);
            chantier._Commentaire = reader.GetString(3);
            return chantier;
        }
        
        private void logChantierfromReader(SqliteDataReader reader)
        {
            while (reader.Read())
            {
                Console.WriteLine($@"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetString(3)}");
            }
        }
        
    }
}
