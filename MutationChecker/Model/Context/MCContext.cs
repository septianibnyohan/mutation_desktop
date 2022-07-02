using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutationChecker.Model.Context
{
    class MCContext
    {
        static SQLiteConnection CreateConnection()
        {
            string cs = @"URI=file:C:\Users\Jano\Documents\test.db";

            SQLiteConnection sqlite_conn;
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
    }
}
