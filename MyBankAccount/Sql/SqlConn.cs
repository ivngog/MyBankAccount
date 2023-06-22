using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MyBankAccount.Sql
{
    public class SqlConn : IDisposable
    {
        //public string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public SqlDataAdapter adapter;

        private readonly string _connectionString;
        public SqlConnection _sqlConnection = null;
        bool _disposed = false;

        public SqlConn() : this(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=F:\Portfolio\MyBankAccount\MyBankAccount\Bank.mdf;Integrated Security = True")
        {

        }

        public SqlConn(string connectionString) => _connectionString = connectionString;

        public void OpenConnection()
        {
            _sqlConnection = new SqlConnection
            {
                ConnectionString = _connectionString
            };
            _sqlConnection.Open();
        }
        public  void CloseConnection()
        {
            if(_sqlConnection?.State != ConnectionState.Closed)
            {
                _sqlConnection.Close();
            }
        }
        

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if(disposing)
            {
                _sqlConnection.Dispose();
            }
            _disposed = true;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}
