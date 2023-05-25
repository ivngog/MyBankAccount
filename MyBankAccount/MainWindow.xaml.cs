using System;
using System.Collections.Generic;
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

namespace MyBankAccount
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        BankAcc bankAcc = new BankAcc();


        public enum TypeOfCustomer
        {
            Individual, Company
        }
        public MainWindow()
        {
            InitializeComponent();

            
            
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
            SetContentFromAccount();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            SetContentFromRegistrationForm();
        }
    }
}
