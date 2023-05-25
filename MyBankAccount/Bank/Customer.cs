using System;
using System.Collections.Generic;
using System.Text;

namespace MyBankAccount.Bank
{
    

    public class Customer
    {
        
        public string TypeOfCustomer { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }
        public string EMail { get; set; }

        private string Login { get; set; }
        private string Password { get; set; }

        public void RegisterNewCustomer()
        {
            MainWindow mainWindow = new MainWindow();
            RegisterForm regForm = new RegisterForm();
            FirstName = regForm.fName.Text;
            LastName = regForm.lName.Text;
            Phone = regForm.Phone.Text;
            EMail = regForm.EMail.Text;
            Login = regForm.UserLogin.Text;
            Password = regForm.UserPassword.Text;
            TypeOfCustomer = regForm.TypeOfCustomer.Text;

            string sql = "insert into Customers (FirstName, LastName, Phone, Email, TypeOfCust, UserName, Password) values (FirstName, LastName, Phone, Email, Login, Password, TypeOfCustomers)";
        }
        

    }
}
