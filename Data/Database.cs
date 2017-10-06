using System;
using System.Data.SqlClient;

namespace Data
{
    public class Database : IDisposable
    {
        private static Database _database;
        static object _lock = new object();

        private Database() { }

        public static Database Instance
        {
            get
            {
                if (_database == null)
                {
                    lock (_lock)
                    {
                        if (_database == null)
                            _database = new Database();
                    }
                }
                return _database;
            }
        }

        public SqlConnection Connection
        {
            get { return _sqlConnection; }
        }

        SqlConnection _sqlConnection = null;
        
        
        public void Initialise(string connectionString)
        {
            lock (_lock)
            {
                if (!string.IsNullOrEmpty(connectionString))
                {
                    _sqlConnection = new SqlConnection(connectionString);
                }
            }            
        }

        bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
          
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                if (_sqlConnection != null)
                {
                    _sqlConnection.Close();
                }
            }
                        
            _disposed = true;
        }
    }
}