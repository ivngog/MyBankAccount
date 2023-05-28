using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MyBankAccount.Bank;
using MyBankAccount.Users;

namespace MyBankAccount
{
    /// <summary>
    /// Логика взаимодействия для RegisterForm.xaml
    /// </summary>
    public partial class RegisterForm : Window
    {
        
        
        
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainW = new MainWindow();
            string con = mainW.ConnectionString;

            if (fName.Text != "" && lName.Text != "" && Phone.Text != "" && EMail.Text != "" && TypeOfCustomer.Text != "" && UserLogin.Text != "" && UserPassword.Text != "")
            {
                Registration reg = new Registration();
                reg.RegisterNewAccount(con, fName.Text, lName.Text, Phone.Text, EMail.Text, UserLogin.Text, UserPassword.Text, TypeOfCustomer.Text);

                MessageBox.Show("You are done!!!", "Ok");
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
        }
    }
}
