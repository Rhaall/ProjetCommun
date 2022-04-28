﻿using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.modèles;

namespace WpfApp1.wrappers
{
    internal class WrapCompagnon
    {

        SqliteConnection sqlite_conn = new SqliteConnection("Data Source=GPB_BDD.bd");

        public void createCompagnon(Compagnon compagnon)
        {
            sqlite_conn.Open();
            SqliteCommand sqlCommand = sqlite_conn.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO compagnon VALUES ('" + compagnon._Id + "','" + compagnon._Name + "','" + compagnon._Telephone + "','" + compagnon._CoutHoraire + "','" + compagnon._DateEmbauche.ToString() + "','" + compagnon._Commentaire+"')";
            Console.WriteLine(sqlCommand.CommandText);
            SqliteDataReader rdr = sqlCommand.ExecuteReader();
        }
        // A noter quand on recup les données avec GetInt32() alors que c'est un string la fonction return 0; 
        // et pareil our GetString()
        public Compagnon readCompagnon(int id)
        {
            sqlite_conn.Open();
            SqliteCommand sqlCommand = sqlite_conn.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM compagnon WHERE id_compagnon=" + id;
            SqliteDataReader rdr = sqlCommand.ExecuteReader();
            return convertDataToObject(rdr);
        }
        public void updateCompagnon(Compagnon compagnon)
        {
            sqlite_conn.Open();
            SqliteCommand sqlCommand = sqlite_conn.CreateCommand();
            var args = new Dictionary<string, object>
            {
                {"@id", compagnon._Id},
                {"@name", compagnon._Name},
                {"@tel", compagnon._Telephone},
                {"@ch", compagnon._CoutHoraire},
                {"@DE", compagnon._DateEmbauche},
                {"@com", compagnon._Commentaire }
            };

            sqlCommand.CommandText = "UPDATE compagnon SET name = @name, telephone = @tel, cout_horaire = @ch , date_embauche = @DE, compagnon_com = @com WHERE Id = @id";
            sqlCommand.ExecuteNonQuery();
        }
        public void deleteCompagnon(Compagnon compagnon)
        {
            sqlite_conn.Open();
            SqliteCommand sqlCommand = sqlite_conn.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM compagnon WHERE id_compagnon=" + compagnon._Id;
            sqlCommand.ExecuteNonQuery();

        }
        //je sais que je peux use le constructeur mais je pref comme ca
        private Compagnon convertDataToObject(SqliteDataReader reader)
        {
            Compagnon compagnon = new Compagnon();
            compagnon._Id = reader.GetInt32(0);
            compagnon._Name = reader.GetString(1);
            compagnon._Telephone = reader.GetString(2);
            compagnon._CoutHoraire = reader.GetInt32(3);
            compagnon._DateEmbauche = reader.GetString(4);
            compagnon._Commentaire = reader.GetString(5);
            return compagnon;
        }

        private void logCompagnonfromBDD(SqliteDataReader reader)
        {
            while (reader.Read())
            {
                Console.WriteLine($@"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetString(3)}");
            }
        }
    }
}