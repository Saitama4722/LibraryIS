using System;
using System.Data.SQLite;
using System.Globalization;
using System.IO;

namespace LibraryIS.Database
{
    public static class DatabaseHelper
    {
        private static readonly string DbFileName = "library.db";

        private static string _connectionStringOverride;

        public static string ConnectionString
        {
            get
            {
                if (!string.IsNullOrEmpty(_connectionStringOverride))
                    return _connectionStringOverride;

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbFileName);
                return "Data Source=" + path + ";Version=3;";
            }
        }

        public static void SetConnectionString(string connectionString)
        {
            _connectionStringOverride = connectionString;
        }

        public static SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public static void CreateSchema(SQLiteConnection connection)
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

            using (var c = new SQLiteCommand(createBooks, connection)) c.ExecuteNonQuery();
            using (var c = new SQLiteCommand(createReaders, connection)) c.ExecuteNonQuery();
            using (var c = new SQLiteCommand(createLoans, connection)) c.ExecuteNonQuery();
            using (var c = new SQLiteCommand(createUsers, connection)) c.ExecuteNonQuery();
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

                SeedBooks(connection);
                SeedReaders(connection);
                SeedLoans(connection);
            }
        }

        private static void SeedBooks(SQLiteConnection connection)
        {
            using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Books;", connection))
            {
                if ((long)cmd.ExecuteScalar() > 0) return;
            }

            var books = new[]
            {
                new { T = "Война и мир",                     A = "Лев Толстой",            G = "Классическая литература", Y = 1869, I = "978-5-17-090107-3", C = 3 },
                new { T = "Преступление и наказание",        A = "Фёдор Достоевский",      G = "Классическая литература", Y = 1866, I = "978-5-04-099716-2", C = 2 },
                new { T = "Мастер и Маргарита",              A = "Михаил Булгаков",        G = "Классическая литература", Y = 1967, I = "978-5-17-088479-6", C = 3 },
                new { T = "Евгений Онегин",                  A = "Александр Пушкин",       G = "Поэзия",                  Y = 1833, I = "978-5-389-07799-1", C = 2 },
                new { T = "Отцы и дети",                     A = "Иван Тургенев",          G = "Классическая литература", Y = 1862, I = "978-5-17-082413-6", C = 1 },
                new { T = "Краткая история времени",         A = "Стивен Хокинг",          G = "Наука",                   Y = 1988, I = "978-5-17-080109-0", C = 2 },
                new { T = "Происхождение видов",             A = "Чарльз Дарвин",          G = "Наука",                   Y = 1859, I = "978-5-17-073013-0", C = 1 },
                new { T = "Краткая история человечества",    A = "Юваль Ной Харари",       G = "История",                 Y = 2011, I = "978-5-906947-12-3", C = 3 },
                new { T = "История государства Российского", A = "Николай Карамзин",       G = "История",                 Y = 1818, I = "978-5-699-23045-2", C = 1 },
                new { T = "CLR via C#",                      A = "Джеффри Рихтер",         G = "Программирование",        Y = 2012, I = "978-5-496-00433-6", C = 2 },
                new { T = "Чистый код",                      A = "Роберт Мартин",          G = "Программирование",        Y = 2008, I = "978-5-4461-0960-0", C = 3 },
                new { T = "Совершенный код",                 A = "Стив Макконнелл",        G = "Программирование",        Y = 2004, I = "978-5-7502-0064-1", C = 2 },
                new { T = "Алгоритмы. Построение и анализ",  A = "Томас Кормен",           G = "Программирование",        Y = 2009, I = "978-5-8459-2016-9", C = 1 },
                new { T = "Так говорил Заратустра",          A = "Фридрих Ницше",          G = "Философия",               Y = 1885, I = "978-5-389-04188-6", C = 2 },
                new { T = "Государство",                     A = "Платон",                 G = "Философия",               Y = -380, I = "978-5-17-085566-6", C = 2 },
                new { T = "Критика чистого разума",          A = "Иммануил Кант",          G = "Философия",               Y = 1781, I = "978-5-699-72906-8", C = 1 }
            };

            string sql = @"INSERT INTO Books (Title, Author, Genre, Year, ISBN, TotalCopies, AvailableCopies)
                           VALUES (@t, @a, @g, @y, @i, @c, @c);";
            foreach (var b in books)
            {
                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@t", b.T);
                    cmd.Parameters.AddWithValue("@a", b.A);
                    cmd.Parameters.AddWithValue("@g", b.G);
                    cmd.Parameters.AddWithValue("@y", b.Y);
                    cmd.Parameters.AddWithValue("@i", b.I);
                    cmd.Parameters.AddWithValue("@c", b.C);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void SeedReaders(SQLiteConnection connection)
        {
            using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM Readers;", connection))
            {
                if ((long)cmd.ExecuteScalar() > 0) return;
            }

            var readers = new[]
            {
                new { N = "Иванов Иван Иванович",         B = "1985-03-12", C = "БЧ-00001", P = "+7 (915) 123-45-67" },
                new { N = "Петрова Анна Сергеевна",       B = "1992-07-25", C = "БЧ-00002", P = "+7 (916) 234-56-78" },
                new { N = "Смирнов Алексей Викторович",   B = "1978-11-04", C = "БЧ-00003", P = "+7 (903) 345-67-89" },
                new { N = "Кузнецова Мария Дмитриевна",   B = "2001-02-18", C = "БЧ-00004", P = "+7 (925) 456-78-90" },
                new { N = "Соколов Дмитрий Андреевич",    B = "1995-09-30", C = "БЧ-00005", P = "+7 (926) 567-89-01" },
                new { N = "Попова Екатерина Олеговна",    B = "1988-05-14", C = "БЧ-00006", P = "+7 (905) 678-90-12" },
                new { N = "Васильев Михаил Павлович",     B = "1973-12-22", C = "БЧ-00007", P = "+7 (917) 789-01-23" },
                new { N = "Новикова Ольга Николаевна",    B = "1999-04-08", C = "БЧ-00008", P = "+7 (909) 890-12-34" },
                new { N = "Фёдоров Сергей Александрович", B = "1982-08-17", C = "БЧ-00009", P = "+7 (911) 901-23-45" },
                new { N = "Морозова Татьяна Игоревна",    B = "2003-06-29", C = "БЧ-00010", P = "+7 (962) 012-34-56" }
            };

            string sql = @"INSERT INTO Readers (FullName, BirthDate, CardNumber, Phone)
                           VALUES (@n, @b, @c, @p);";
            foreach (var r in readers)
            {
                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@n", r.N);
                    cmd.Parameters.AddWithValue("@b", r.B);
                    cmd.Parameters.AddWithValue("@c", r.C);
                    cmd.Parameters.AddWithValue("@p", r.P);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void SeedLoans(SQLiteConnection connection)
        {
            using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM LoanRecords;", connection))
            {
                if ((long)cmd.ExecuteScalar() > 0) return;
            }

            string fmt = "yyyy-MM-dd";
            var today = DateTime.Now.Date;

            var loans = new[]
            {
                new { BookId = 1, ReaderId = 1, Loan = today.AddDays(-7),  Due = today.AddDays(7),   Ret = (DateTime?)null },
                new { BookId = 3, ReaderId = 2, Loan = today.AddDays(-10), Due = today.AddDays(4),   Ret = (DateTime?)null },
                new { BookId = 6, ReaderId = 3, Loan = today.AddDays(-30), Due = today.AddDays(-16), Ret = (DateTime?)today.AddDays(-15) },
                new { BookId = 11, ReaderId = 5, Loan = today.AddDays(-45), Due = today.AddDays(-31), Ret = (DateTime?)today.AddDays(-28) },
                new { BookId = 8, ReaderId = 4, Loan = today.AddDays(-40), Due = today.AddDays(-26), Ret = (DateTime?)null },
                new { BookId = 14, ReaderId = 7, Loan = today.AddDays(-25), Due = today.AddDays(-11), Ret = (DateTime?)null }
            };

            string sql = @"INSERT INTO LoanRecords (BookId, ReaderId, LoanDate, DueDate, ReturnDate)
                           VALUES (@b, @r, @ld, @dd, @rd);";
            foreach (var l in loans)
            {
                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@b", l.BookId);
                    cmd.Parameters.AddWithValue("@r", l.ReaderId);
                    cmd.Parameters.AddWithValue("@ld", l.Loan.ToString(fmt, CultureInfo.InvariantCulture));
                    cmd.Parameters.AddWithValue("@dd", l.Due.ToString(fmt, CultureInfo.InvariantCulture));
                    if (l.Ret.HasValue)
                        cmd.Parameters.AddWithValue("@rd", l.Ret.Value.ToString(fmt, CultureInfo.InvariantCulture));
                    else
                        cmd.Parameters.AddWithValue("@rd", DBNull.Value);
                    cmd.ExecuteNonQuery();
                }

                if (!l.Ret.HasValue)
                {
                    using (var upd = new SQLiteCommand(
                        "UPDATE Books SET AvailableCopies = MAX(0, AvailableCopies - 1) WHERE Id = @id;", connection))
                    {
                        upd.Parameters.AddWithValue("@id", l.BookId);
                        upd.ExecuteNonQuery();
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
