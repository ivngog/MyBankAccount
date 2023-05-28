using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using MyBankAccount.Bank;

namespace MyBankAccount.Users
{
    public class Registration:Customer
    {
        public DateTime RegisterDate { get; set; }

        private string UserName { get; set; }
        private string Password { get; set; }
        private SqlConnection _sqlConnection = null;

        public void RegisterNewAccount(string connectionString, string firstName, string lastName, string phone, string email, string userName, string pass, string typeOfCust)
        {
            _sqlConnection = new SqlConnection(connectionString);

            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            EMail = email;
            UserName = userName;
            Password = pass;
            TypeOfCustomer = typeOfCust;
            Convert.ToString(RegisterDate = DateTime.Now);
            

            string sql = $@"insert into Customers (FirstName, LastName, Phone, Email, TypeOfCust, UserName, Password, RegisterDate) values " + $"('{FirstName}', '{LastName}', '{Phone}', '{EMail}', '{TypeOfCustomer}', '{UserName}', '{Password}', '{RegisterDate}' )";
            try
            {
                _sqlConnection.Open();

                using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }

                _sqlConnection.Close();


                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            
        }

    }
}
