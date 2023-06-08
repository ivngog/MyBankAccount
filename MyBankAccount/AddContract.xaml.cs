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
using System.Globalization;

namespace MyBankAccount
{
    /// <summary>
    /// Логика взаимодействия для AddContract.xaml
    /// </summary>
    public partial class AddContract : Window
    {
        protected int AccId { get; set; }
        public AddContract(int accid)
        {
            
            InitializeComponent();
            AccId = accid;
        }

        private void AddContract_Click(object sender, RoutedEventArgs e)
        {
            InsertIntoContracts(AccId);
            /*CultureInfo culture = new CultureInfo("en-US");
            NumberFormatInfo nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };

            Customer cust = new Customer();
            cust.InterestRate = Convert.ToDecimal("22.22", culture);
            cust.Ballance = Convert.ToDecimal("33.44", culture);
            Lable.Content = Convert.ToDecimal("22.22", nfi) + " " + Convert.ToDecimal ("33.44", nfi);*/
        }

        protected void InsertIntoContracts(int AccountId)
        {
            CultureInfo culture = new CultureInfo("en-US");
            Customer cust = new Customer();
            cust.InterestRate = Convert.ToDecimal(InterestRate.Text.Trim(), culture);
            cust.Ballance = Convert.ToDecimal(Balance.Text.Trim(), culture);
            cust.Description = Description.SelectedItem.ToString();
            string sql = $@"Insert into Contracts (BeginContract, EndContract, InterestRate, Balance, AccId, Description) values " + $"('{cust.ContractBeginDate}', 'null', {cust.InterestRate}, {cust.Ballance}, {AccountId}, '{cust.Description}')";
            try
            {
                cust.OpenConnection();
                using (SqlCommand command = new SqlCommand(sql, cust._sqlConnection))
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    cust.CloseConnection();
                    MessageBox.Show("Congratulation!");

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error!");
            }
            

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
    }
}
