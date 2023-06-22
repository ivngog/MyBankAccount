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
using MyBankAccount.BankOperations;
using System.Linq;

namespace MyBankAccount
{
    /// <summary>
    /// Логика взаимодействия для BankAcc.xaml
    /// </summary>
    public partial class BankAcc : Window
    {



        protected static string Username { get; set; }
        protected int AccountId { get; set; }
        
        Customer customer = new Customer();
        public BankAcc(string username)
        {
            
            InitializeComponent();
            Username = username;

            GetUser(Username);
            ShowContractList showContractList = new ShowContractList();
            
            List<string> item = showContractList.ShowMeListOfContracts(GetUserId());
            ShowContract.Background = Brushes.LightGreen;
            try
            {
                MenuItem item1 = new MenuItem();
                item1.Header = item[0];
                item1.Name = item[0];
                item1.Click += ShowDeposite_Click; 
                ShowContract.Items.Add(item1);

                MenuItem item2 = new MenuItem();
                item2.Header = item[1];
                item2.Name = item[1];
                item2.Click += ShowLoan_Click;
                ShowContract.Items.Add(item2);

                MenuItem item3 = new MenuItem();
                item3.Header = item[2];
                item3.Name = item[2];
                item3.Click += ShowMortgage_Click;
                ShowContract.Items.Add(item3);
            }
            catch(Exception)
            {
                
            }
            
        }

        public BankAcc() { }
        
        

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
                    customer.FirstName = (string)dataReader["FirstName"];
                    customer.LastName = (string)dataReader["LastName"];
                    customer.Phone = (string)dataReader["Phone"];
                    customer.EMail = (string)dataReader["Email"];
                    customer.TypeOfCustomer = (string)dataReader["TypeOfCust"];
                    customer.DateOfRegistration = Convert.ToDateTime(dataReader["RegisterDate"]);
                    
                    customer.Ballance = (decimal)dataReader["Balance"];
                    CustName.Text = customer.FirstName + " " + customer.LastName;
                    UserPhone.Text = customer.Phone;
                    Email.Text = customer.EMail;
                    TypeOfCust.Text = customer.TypeOfCustomer;
                    DateOfReg.Text = Convert.ToString(customer.DateOfRegistration);
                    Balance.Text = Convert.ToString(customer.Ballance) + " $";
                    AccountId = (int)dataReader["Id"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public int GetUserId()
        {
            return AccountId;
        }


        //Get Balance From Accounts
        decimal ReturnBalance()
        {
            SqlConn sqlconn = new SqlConn();
            string query = @"select Balance from Accounts where Id = "+ GetUserId() +"";
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
                    
                    customer.Ballance = (decimal)dataReader["Balance"];
                   
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return customer.Ballance;
        }


        private void AddContract_click(object sender, RoutedEventArgs e)
        {
            
            AddContract addcontract = new AddContract(AccountId);
            addcontract.Show();

        }

        private void ShowDeposite_Click(object sender, RoutedEventArgs e)
        {
            string dep = "Deposite";
            ShowMeContractOnTheWindow showDep = new ShowMeContractOnTheWindow(AccountId, dep, customer.TypeOfCustomer);
            
            //ContentControl name Contracts opens ShowDep window.
            Contracts.Content = showDep.Content;
        }

        private void ShowLoan_Click(object sender, RoutedEventArgs e)
        {
            string dep = "Loan";
            ShowMeContractOnTheWindow showDep = new ShowMeContractOnTheWindow(AccountId, dep, customer.TypeOfCustomer);

            //ContentControl name Contracts opens ShowDep window.
            Contracts.Content = showDep.Content;
        }

        private void ShowMortgage_Click(object sender, RoutedEventArgs e)
        {
            string dep = "Mortgage";
            ShowMeContractOnTheWindow showDep = new ShowMeContractOnTheWindow(AccountId, dep, customer.TypeOfCustomer);

            //ContentControl name Contracts opens ShowDep window.
            Contracts.Content = showDep.Content;
        }
        

        private void f5_Click(object sender, RoutedEventArgs e)
        {
            Balance.Text = Convert.ToString(ReturnBalance()) + " $";
        }
    }
}
