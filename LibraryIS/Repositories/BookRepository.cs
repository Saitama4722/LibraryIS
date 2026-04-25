using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using LibraryIS.Database;
using LibraryIS.Models;

namespace LibraryIS.Repositories
{
    public class BookRepository
    {
        public bool AddBook(Book book)
        {
            if (book == null) return false;
            if (string.IsNullOrWhiteSpace(book.Title)) return false;
            if (book.TotalCopies <= 0) return false;

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    string sql = @"INSERT INTO Books (Title, Author, Genre, Year, ISBN, TotalCopies, AvailableCopies)
                                   VALUES (@t, @a, @g, @y, @i, @tc, @ac);";
                    using (var cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@t", book.Title);
                        cmd.Parameters.AddWithValue("@a", book.Author);
                        cmd.Parameters.AddWithValue("@g", book.Genre ?? string.Empty);
                        cmd.Parameters.AddWithValue("@y", book.Year);
                        cmd.Parameters.AddWithValue("@i", book.ISBN ?? string.Empty);
                        cmd.Parameters.AddWithValue("@tc", book.TotalCopies);
                        cmd.Parameters.AddWithValue("@ac", book.AvailableCopies);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении книги: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<Book> FindBook(string field, string value)
        {
            var result = new List<Book>();
            try
            {
                string column;
                switch (field)
                {
                    case "Название": column = "Title"; break;
                    case "Автор": column = "Author"; break;
                    case "Жанр": column = "Genre"; break;
                    default: column = "Title"; break;
                }

                using (var connection = DatabaseHelper.GetConnection())
                {
                    string sql = "SELECT * FROM Books WHERE " + column + " LIKE @v;";
                    using (var cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@v", "%" + value + "%");
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(MapBook(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при поиске книг: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public bool EditBook(Book book)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    string sql = @"UPDATE Books SET Title=@t, Author=@a, Genre=@g, Year=@y, ISBN=@i,
                                   TotalCopies=@tc, AvailableCopies=@ac WHERE Id=@id;";
                    using (var cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@t", book.Title);
                        cmd.Parameters.AddWithValue("@a", book.Author);
                        cmd.Parameters.AddWithValue("@g", book.Genre ?? string.Empty);
                        cmd.Parameters.AddWithValue("@y", book.Year);
                        cmd.Parameters.AddWithValue("@i", book.ISBN ?? string.Empty);
                        cmd.Parameters.AddWithValue("@tc", book.TotalCopies);
                        cmd.Parameters.AddWithValue("@ac", book.AvailableCopies);
                        cmd.Parameters.AddWithValue("@id", book.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при изменении книги: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool DeleteBook(int id)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    using (var cmd = new SQLiteCommand("DELETE FROM Books WHERE Id=@id;", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении книги: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateAvailableCopies(int id, int availableCopies)
        {
            if (availableCopies < 0) return false;
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    using (var cmd = new SQLiteCommand("UPDATE Books SET AvailableCopies=@ac WHERE Id=@id;", connection))
                    {
                        cmd.Parameters.AddWithValue("@ac", availableCopies);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении доступных экземпляров: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<Book> GetAllBooks()
        {
            var result = new List<Book>();
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    using (var cmd = new SQLiteCommand("SELECT * FROM Books ORDER BY Title;", connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(MapBook(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении списка книг: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        private Book MapBook(SQLiteDataReader reader)
        {
            return new Book
            {
                Id = Convert.ToInt32(reader["Id"]),
                Title = reader["Title"].ToString(),
                Author = reader["Author"].ToString(),
                Genre = reader["Genre"].ToString(),
                Year = reader["Year"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Year"]),
                ISBN = reader["ISBN"].ToString(),
                TotalCopies = Convert.ToInt32(reader["TotalCopies"]),
                AvailableCopies = Convert.ToInt32(reader["AvailableCopies"])
            };
        }
    }
}
