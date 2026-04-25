using System;
using System.Data.SQLite;
using LibraryIS.Database;

namespace LibraryIS.Tests.Helpers
{
    public class TestDatabase : IDisposable
    {
        private SQLiteConnection _keepAlive;
        public string ConnectionString { get; }

        public TestDatabase()
        {
            string dbName = "testdb_" + Guid.NewGuid().ToString("N");
            ConnectionString =
                "FullUri=file:" + dbName + "?mode=memory&cache=shared;Version=3;";

            _keepAlive = new SQLiteConnection(ConnectionString);
            _keepAlive.Open();

            DatabaseHelper.SetConnectionString(ConnectionString);

            using (var initConn = DatabaseHelper.GetConnection())
            {
                DatabaseHelper.CreateSchema(initConn);
            }
        }

        public void Dispose()
        {
            if (_keepAlive != null)
            {
                _keepAlive.Close();
                _keepAlive.Dispose();
                _keepAlive = null;
            }
            DatabaseHelper.SetConnectionString(null);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
