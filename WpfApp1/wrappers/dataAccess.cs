﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;


namespace WpfApp1.wrapper
{
    public class DataAccess
    {

        public DataAccess()
        {

        }

        public void test()
        {
            SqliteConnection sqlite_conn = new SqliteConnection("Data Source=GPB_BDD.bd");
            sqlite_conn.Open();
            var sqlCommand = sqlite_conn.CreateCommand();
            //sqlCommand.CommandText = "CREATE TABLE chantier ( id_chantier INTEGER NOT NULL, adresse TEXT, nom_chantier TEXT, chantier_com TEXT, PRIMARY KEY(id_chantier AUTOINCREMENT) )";
            //sqlCommand.CommandText = "CREATE TABLE compagnon ( id_conpagnon INTEGER NOT NULL, name TEXT, telephone INTEGER, cout_horaire NUMERIC, date_time TEXT, compagnon_com TEXT, PRIMARY KEY(id_conpagnon AUTOINCREMENT) )";
            //sqlCommand.CommandText = "CREATE TABLE devis ( id_devis INTEGER NOT NULL, temps_prevu TEXT, cour_prevu NUMERIC, devis_com TEXT, PRIMARY KEY(id_devis AUTOINCREMENT) )";
            //sqlCommand.CommandText = "CREATE TABLE facture ( id_facture INTEGER NOT NULL, temps_effectif TEXT, cout_effectif NUMERIC, facture_com TEXT, PRIMARY KEY(id_facture AUTOINCREMENT) )";
            sqlCommand.CommandText = "select * from chantier";
            //sqlCommand.CommandText = "INSERT INTO chantier VALUES ('0','9 rue julien chavoutier', 'maison36', 'il existe pas');";

            var rdr = sqlCommand.ExecuteReader();
            
            while (rdr.Read())
            {
                Console.WriteLine($@"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetInt32(2)} {rdr.GetInt32(3)}");
            }
        }


    }
}