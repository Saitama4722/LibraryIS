using System;
using System.Data.SQLite;
using System.IO;

namespace LibraryIS.Database
{
    public static class DatabaseHelper
    {
        private static readonly string DbFileName = "library.db";

        public static string ConnectionString
        {
            get
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbFileName);
                return "Data Source=" + path + ";Version=3;";
            }
        }

        public static SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public static void InitializeDatabase()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbFileName);
            if (!File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
            }

            using (var connection = GetConnection())
            {
                string createBooks = @"
                    CREATE TABLE IF NOT EXISTS Books (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Author TEXT NOT NULL,
                        Genre TEXT,
                        Year INTEGER,
                        ISBN TEXT,
                        TotalCopies INTEGER NOT NULL DEFAULT 1,
                        AvailableCopies INTEGER NOT NULL DEFAULT 1
                    );";

                string createReaders = @"
                    CREATE TABLE IF NOT EXISTS Readers (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FullName TEXT NOT NULL,
                        BirthDate TEXT,
                        CardNumber TEXT NOT NULL UNIQUE,
                        Phone TEXT
                    );";

                string createLoans = @"
                    CREATE TABLE IF NOT EXISTS LoanRecords (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        BookId INTEGER NOT NULL,
                        ReaderId INTEGER NOT NULL,
                        LoanDate TEXT NOT NULL,
                        DueDate TEXT NOT NULL,
                        ReturnDate TEXT,
                        FOREIGN KEY (BookId) REFERENCES Books(Id),
                        FOREIGN KEY (ReaderId) REFERENCES Readers(Id)
                    );";

                string createUsers = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Login TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL,
                        Role TEXT NOT NULL DEFAULT 'admin'
                    );";

                ExecuteNonQuery(connection, createBooks);
                ExecuteNonQuery(connection, createReaders);
                ExecuteNonQuery(connection, createLoans);
                ExecuteNonQuery(connection, createUsers);

                using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Users;", connection))
                {
                    long count = (long)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        using (var insert = new SQLiteCommand(
                            "INSERT INTO Users (Login, Password, Role) VALUES (@l, @p, 'admin');", connection))
                        {
                            insert.Parameters.AddWithValue("@l", "admin");
                            insert.Parameters.AddWithValue("@p", "admin123");
                            insert.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private static void ExecuteNonQuery(SQLiteConnection connection, string sql)
        {
            using (var cmd = new SQLiteCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
