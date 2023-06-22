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
        
        
        Authorization authorization = new Authorization();

        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        public void SetContentFromAccount(string username)
        {
            BankAcc bankAcc = new BankAcc(username);
            MainWin.Content = bankAcc.Content;
        }

        public void SetContentFromRegistrationForm()
        {
            RegisterForm regForm = new RegisterForm();
            MainWin.Content = regForm.Content;
        }



        private void Login_Click(object sender, RoutedEventArgs e)
        {
            
            authorization.AuthorizeToAccount(UsrName.Text, Pswrd.Text);
            if(authorization.OpenWindow == true)
            {
                SetContentFromAccount(authorization.Username);
            }
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            SetContentFromRegistrationForm();
        }
    }
}
