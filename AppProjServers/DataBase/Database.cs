using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProjServers.DataBase
{
    public class Database
    {
        private static Database instance = null;
        private static readonly object padlock = new object();
        private SQLiteConnection dbConnection = null;

        public static Database Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Database();
                    }
                }

                return instance;
            }
        }

        public bool ConnectToDb()
        {
            bool _exists = File.Exists("mydb.sqlite");
            if (dbConnection == null)
            {

                if (!File.Exists("mydb.sqlite"))
                {
                    SQLiteConnection.CreateFile("mydb.sqlite");
                }

                dbConnection = new SQLiteConnection("DataSource=mydb.sqliteVersion=3;");
                dbConnection.Open();

                if (!_exists)
                {
                    Console.WriteLine("Nu Exista!");
                    initDb();
                }

                return true;
            }

            return false;
        }

        public bool DisconnectFromDb()
        {
            if (dbConnection != null)
            {
                dbConnection.Close();
                dbConnection.Dispose();
                dbConnection = null;
                return true;
            }
            return false;
        }

        private void initDb()
        {
            string _init = "CREATE TABLE IF NOT EXISTS Users(id INTEGER PRIMARY KEY" +
                            " AUTOINCREMENT, firstName TEXT, lastName TEXT, username TEXT, password TEXT)";
            SQLiteCommand init = new SQLiteCommand(_init, dbConnection);

            try
            {
                init.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Unable to create table!\n");
                Console.Error.WriteLine(ex);
            }
        }

        public bool AddUser(string firstName, string lastName, string username, string password)
        {
            string _insert = "INSERT INTO Users(firstName, lastName, username, password) VALUES('" +
                            $"{firstName}', '{lastName}', '{username}', '{password}')";

            SQLiteCommand insert = new SQLiteCommand(_insert, dbConnection);
            try
            {
                insert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Unable to insert into table!\n");
                Console.Error.WriteLine(ex);
                return false;
            }
            return true;
        }

        public bool AuthenticateUser(string username, string password)
        {
            string _auth = $"SELECT * FROM Users WHERE (username = '{username}' AND password = '{password}')";

            SQLiteCommand auth = new SQLiteCommand(_auth, dbConnection);
            SQLiteDataReader reader;

            try
            {
                reader = auth.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Unable to query 'AuthenticateUser' from table!\n");
                Console.Error.WriteLine(ex);
                return false;
            }


            if (reader.Read()) return true;
            return false;
        }
    }
}
