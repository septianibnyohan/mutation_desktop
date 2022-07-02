using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MutationChecker.Model.Context
{
    public class MCContext
    {
        static SQLiteConnection sqlite_conn;
        public static SQLiteConnection GetConnection()
        {
            //string cs = @"URI=file:C:\Users\Jano\Documents\test.db";
            string cs = Properties.Settings.Default.SqliteConnectionString;

           ;
            // Create a new database connection:
            //sqlite_conn = new SQLiteConnection("Data Source= database.db; Version=3; New=True; Compress = True; ");
            sqlite_conn = new SQLiteConnection(cs);

            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }

        public static void CloseConnection()
        {
            sqlite_conn.Close();
            sqlite_conn.Dispose();
        }

        public static void InsertData(string query)
        {
            SQLiteConnection conn = GetConnection();

            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = query;
            sqlite_cmd.ExecuteNonQuery();

            conn.Close();
            conn.Dispose();
        }

        public static SQLiteDataReader ReadData(string query)
        {
            SQLiteConnection conn = GetConnection();

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = query;

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            //while (sqlite_datareader.Read())
            //{
            //    string myreader = sqlite_datareader.GetString(0);
            //    Console.WriteLine(myreader);
            //}
            //conn.Close();

            return sqlite_datareader;
        }
    }
}
