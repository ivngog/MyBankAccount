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

namespace MyBankAccount
{
    /// <summary>
    /// Логика взаимодействия для BankAcc.xaml
    /// </summary>
    public partial class BankAcc : Window
    {
        public BankAcc()
        {
            InitializeComponent();

            Deposite acc = new Deposite();
            acc.Ballance = 2450;
            acc.FirstName = "Ivan";
            acc.LastName = "Gogoi";
            acc.InterestRate = 0.01m;
            acc.TypeOfCustomer = "Individual";
            acc.NumberOfMonth = 5;
            //typeOfCustomer individual = typeOfCustomer.Individual;

            //MessageBox.Show(Convert.ToString(individual), "OK");



            AccBallance.Text = Convert.ToString(acc.Ballance + " USD");
            AccNumber.Text = Convert.ToString(acc.AccountNumber);
            CustName.Text = acc.FirstName + " " + acc.LastName;
            interestRate.Text = Convert.ToString(acc.InterestRate + " %");
            accuredInterest.Text = Convert.ToString(acc.AccruedInterest() + " $");
        }
    }
}
