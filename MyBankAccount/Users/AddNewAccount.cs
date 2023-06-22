using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using MyBankAccount.Bank;
using MyBankAccount.Sql;

namespace MyBankAccount.Users
{
    public class AddNewAccount : Customer
    {

        public AddNewAccount(string username)
        {

            UserName = username;
            GetId(UserName);
        }


        public void AddAccount(int Id)
        {
            string sql = $@"insert into accounts (CustId, Balance) values (" + $"'{Id}', 0)";
            try
            {

                OpenConnection();


                using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }

                CloseConnection();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        public void GetId(in string username)
        {
            SqlConn sqlconn = new SqlConn();
            string query = @"select Id from customers where UserName = '" + username + "'";
            try
            {
                sqlconn.OpenConnection();
                using SqlCommand command = new SqlCommand(query, sqlconn._sqlConnection)
                {
                    CommandType = CommandType.Text
                };
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    int Id = (int)dataReader["Id"];
                    AddAccount(Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

           
        }

        

    }

 
}
