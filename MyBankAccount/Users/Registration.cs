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
    public class Registration : Customer
    {
        

        
        private string  Password { get; set; }
        

        public void RegisterNewAccount(string firstName, string lastName, string phone, string email, string userName, string pass, string typeOfCust)
        {
             

            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            EMail = email;
            UserName = userName;
            Password = pass;
            TypeOfCustomer = typeOfCust;
            
            

            string sql = $@"insert into Customers (FirstName, LastName, Phone, Email, TypeOfCust, UserName, Password, RegisterDate) values " + $"('{FirstName}', '{LastName}', '{Phone}', '{EMail}', '{TypeOfCustomer}', '{UserName}', '{Password}', '{DateOfRegistration}' )";
            try
            {

                OpenConnection();
                
                
                using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }

                AddNewAccount AddAccount = new AddNewAccount(UserName);

                CloseConnection();


                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            
        }

    }
}
