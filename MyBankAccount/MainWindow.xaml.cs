using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyBankAccount.Bank;
using MyBankAccount.Users;

namespace MyBankAccount
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ConnectionString;
        public SqlDataAdapter adapter;
        BankAcc bankAcc = new BankAcc();
        Registration registr = new Registration();
        Authorization authorization = new Authorization();
        
        private SqlConnection _sqlConnection = null;


        public enum TypeOfCustomer
        {
            Individual, Company
        }
        public MainWindow()
        {
            InitializeComponent();
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            
        }

        public void SetContentFromAccount()
        {
            MainWin.Content = bankAcc.Content;
        }

        public void SetContentFromRegistrationForm()
        {
            RegisterForm regForm = new RegisterForm();
            MainWin.Content = regForm.Content;
        }



        private void Login_Click(object sender, RoutedEventArgs e)
        {
            
            authorization.AuthorizeToAccount(ConnectionString, UserName.Text, Password.Text);
            if(authorization.OpenWindow = true)
            {
                SetContentFromAccount();
            }
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            SetContentFromRegistrationForm();
        }
    }
}
