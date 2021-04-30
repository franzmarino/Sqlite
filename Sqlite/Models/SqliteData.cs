using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;

namespace Sqlite.Models
{
    public class SqliteData
    {
        private const  string DBName = "/database.sqlite";
        private static bool IsDbRecentlyCreated = false;

        public static void Up()
        {
            // Crea la base de datos y registra usuario solo una vez
            if (!File.Exists(Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + DBName)))
            {
                SQLiteConnection.CreateFile(AppDomain.CurrentDomain.BaseDirectory + DBName);
                IsDbRecentlyCreated = true;
            }

            using (var ctx = GetInstance())
            {
                if (IsDbRecentlyCreated)
                {

                    var query = @"CREATE TABLE IF NOT EXISTS Cliente (
                                        Ruc VARCHAR(11) PRIMARY KEY ,
                                        Firma text,
                                        Logo text 
                                        );";

                    using (var command = new SQLiteCommand(query, ctx))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static SQLiteConnection GetInstance()
        {
            var db = new SQLiteConnection(
                string.Format("Data Source={0};Version=3;", AppDomain.CurrentDomain.BaseDirectory + DBName)
            );

            db.Open();

            return db;
        }
    }
}