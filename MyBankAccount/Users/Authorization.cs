using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Windows;


namespace MyBankAccount.Users
{
    public class Authorization : Registration
    {

        public bool OpenWindow;
        public string Username;
        
        
        public void AuthorizeToAccount(string userName, string password)
        {
            string query = @$"select UserName, Password from Customers where UserName = '" + userName + "' and password = '" + password + "'";
            

            if (userName != string.Empty && password != string.Empty)
            {
                try
                {
                    

                    OpenConnection();
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
                        Username = userName;
                        

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
                    MessageBox.Show(ex.Message,"Error");
                }

            }
            else
            {
                MessageBox.Show("Empty");
            }
        }


    }
}
