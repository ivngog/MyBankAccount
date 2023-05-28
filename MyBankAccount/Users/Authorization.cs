using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Windows;


namespace MyBankAccount.Users
{
    class Authorization:Registration
    {
        private SqlConnection _sqlConnection = null;
        public bool OpenWindow { get; set; }
        
        public void AuthorizeToAccount(string ConnectionString, string userName, string password)
        {
            string query = @$"select UserName, Password from Customers where UserName = '" + userName + "' and password = '" + password + "'";
            _sqlConnection = new SqlConnection(ConnectionString);

            if (userName != string.Empty && password != string.Empty)
            {
                try
                {
                    _sqlConnection.Open();


                    using SqlCommand command = new SqlCommand(query, _sqlConnection)
                    {
                        CommandType = CommandType.Text
                    };
                    SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    int count = 0;
                    while (dataReader.Read()) { count += 1; }
                    if (count == 1)
                    {
                        OpenWindow = true;
                    }
                    else if (count > 0)
                    {
                        MessageBox.Show("Dublicate login and password!");
                    }
                    else
                    {
                        MessageBox.Show("Wrong login or password!");
                    }
                    


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error", ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Empty");
            }
        }

    }
}
