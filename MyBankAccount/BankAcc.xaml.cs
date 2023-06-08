using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MyBankAccount.Bank;
using MyBankAccount.Users;
using MyBankAccount.Sql;
using System.Data;

namespace MyBankAccount
{
    /// <summary>
    /// Логика взаимодействия для BankAcc.xaml
    /// </summary>
    public partial class BankAcc : Window
    {
        protected string Username { get; set; }
        protected int AccountId { get; set; }
        public BankAcc(string username)
        {
            InitializeComponent();
            GetUser(username);
            
        }
        

        public void GetUser(string username)
        {
            SqlConn sqlconn = new SqlConn();
            string query = @"select FirstName, LastName, Phone, Email, TypeOfCust, RegisterDate, Accounts.Balance, Accounts.Id  from Customers, Accounts  where Customers.UserName = '" + username + "' and Accounts.CustId = Customers.Id";
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
                    Deposite deposite = new Deposite();
                    deposite.FirstName = (string)dataReader["FirstName"];
                    deposite.LastName = (string)dataReader["LastName"];
                    deposite.Phone = (string)dataReader["Phone"];
                    deposite.EMail = (string)dataReader["Email"];
                    deposite.TypeOfCustomer = (string)dataReader["TypeOfCust"];
                    deposite.DateOfRegistration = Convert.ToDateTime(dataReader["RegisterDate"]);
                    Customer customer = new Customer();
                    customer.Ballance = (decimal)dataReader["Balance"];
                    CustName.Text = deposite.FirstName + " " + deposite.LastName;
                    UserPhone.Text = deposite.Phone;
                    Email.Text = deposite.EMail;
                    TypeOfCust.Text = deposite.TypeOfCustomer;
                    DateOfReg.Text = Convert.ToString(deposite.DateOfRegistration);
                    Balance.Text = Convert.ToString(customer.Ballance) + " $";
                    AccountId = (int)dataReader["Id"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }


        }

        private void AddContract_click(object sender, RoutedEventArgs e)
        {
            
            AddContract addcontract = new AddContract(AccountId);
            addcontract.Show();

        }
    }
}
