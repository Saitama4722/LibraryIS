using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Windows.Forms;
using LibraryIS.Database;
using LibraryIS.Models;

namespace LibraryIS.Repositories
{
    public class ReaderRepository
    {
        public bool RegisterReader(Models.Reader reader)
        {
            if (reader == null) return false;
            if (string.IsNullOrWhiteSpace(reader.FullName)) return false;
            if (string.IsNullOrWhiteSpace(reader.CardNumber)) return false;

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    using (var check = new SQLiteCommand(
                        "SELECT COUNT(*) FROM Readers WHERE CardNumber=@c;", connection))
                    {
                        check.Parameters.AddWithValue("@c", reader.CardNumber);
                        long cnt = (long)check.ExecuteScalar();
                        if (cnt > 0)
                        {
                            return false;
                        }
                    }

                    string sql = @"INSERT INTO Readers (FullName, BirthDate, CardNumber, Phone)
                                   VALUES (@n, @b, @c, @p);";
                    using (var cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@n", reader.FullName);
                        cmd.Parameters.AddWithValue("@b", reader.BirthDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
                        cmd.Parameters.AddWithValue("@c", reader.CardNumber);
                        cmd.Parameters.AddWithValue("@p", reader.Phone ?? string.Empty);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при регистрации читателя: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public Models.Reader GetReaderByCard(string cardNumber)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    using (var cmd = new SQLiteCommand("SELECT * FROM Readers WHERE CardNumber=@c;", connection))
                    {
                        cmd.Parameters.AddWithValue("@c", cardNumber);
                        using (var rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                return MapReader(rd);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при поиске читателя: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public bool EditReader(Models.Reader reader)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    string sql = @"UPDATE Readers SET FullName=@n, BirthDate=@b, CardNumber=@c, Phone=@p
                                   WHERE Id=@id;";
                    using (var cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@n", reader.FullName);
                        cmd.Parameters.AddWithValue("@b", reader.BirthDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
                        cmd.Parameters.AddWithValue("@c", reader.CardNumber);
                        cmd.Parameters.AddWithValue("@p", reader.Phone ?? string.Empty);
                        cmd.Parameters.AddWithValue("@id", reader.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при изменении читателя: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<Models.Reader> GetAllReaders()
        {
            var result = new List<Models.Reader>();
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    using (var cmd = new SQLiteCommand("SELECT * FROM Readers ORDER BY FullName;", connection))
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            result.Add(MapReader(rd));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении списка читателей: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        public bool HasOverdueLoans(int readerId)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    string sql = @"SELECT COUNT(*) FROM LoanRecords
                                   WHERE ReaderId=@id AND ReturnDate IS NULL AND DueDate < @now;";
                    using (var cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", readerId);
                        cmd.Parameters.AddWithValue("@now", DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
                        long cnt = (long)cmd.ExecuteScalar();
                        return cnt > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при проверке просроченных выдач: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private Models.Reader MapReader(SQLiteDataReader rd)
        {
            DateTime birth;
            string bs = rd["BirthDate"] == DBNull.Value ? null : rd["BirthDate"].ToString();
            if (!DateTime.TryParse(bs, out birth)) birth = DateTime.Now;

            return new Models.Reader
            {
                Id = Convert.ToInt32(rd["Id"]),
                FullName = rd["FullName"].ToString(),
                BirthDate = birth,
                CardNumber = rd["CardNumber"].ToString(),
                Phone = rd["Phone"].ToString()
            };
        }
    }
}
