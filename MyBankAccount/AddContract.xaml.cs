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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyBankAccount.Sql;
using MyBankAccount.Bank;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using MyBankAccount.BankOperations;

namespace MyBankAccount
{
    /// <summary>
    /// Логика взаимодействия для AddContract.xaml
    /// </summary>
    public partial class AddContract : Window
    {
        protected int AccId { get; set; }
        OpenContract openContract = new OpenContract();
        public AddContract(int accid)
        {
            
            InitializeComponent();
            AccId = accid;
        }

        private void AddContract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                openContract.InsertIntoContracts(InterestRate.Text, Balance.Text, AccId, Description.SelectedItem.ToString());
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
