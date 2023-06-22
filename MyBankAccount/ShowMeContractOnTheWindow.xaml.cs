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
using MyBankAccount.BankOperations;
using MyBankAccount.Bank;
using MyBankAccount.Users;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace MyBankAccount
{
    /// <summary>
    /// Логика взаимодействия для ShowContracts.xaml
    /// </summary>
    public partial class ShowMeContractOnTheWindow : Window
    {
        
        Customer customer = new Customer();
        ShowContract showContract = new ShowContract();
        public ShowMeContractOnTheWindow(int id, string contractName, string typeOfCustomer) 
        {
            InitializeComponent();
            customer.Id = id;
            customer.TitleOfContract = contractName;
            customer.TypeOfCustomer = typeOfCustomer;
            ShowContractOnWin();
            
        }

        public ShowMeContractOnTheWindow() { }

        public void ShowContractOnWin()
        {
            interest.Content = "Interest: " + showContract.ShowInterestOfDeposite(customer.Id, customer.TitleOfContract, customer.TypeOfCustomer).ToString("0.##") + "$";
            Contract.Content = "Contract: " + showContract.TitleOfContract;
            begincontract.Content = "Date of begin contract:";
            BeginDate.Content = showContract.ContractBeginDate.ToShortDateString();
            interestrate.Content = "Interest Rate: " + showContract.InterestRate + "%";
            total.Content = "Total:";
            Total.Content = Convert.ToDecimal(showContract.Ballance + showContract.ShowInterestOfDeposite(customer.Id, customer.TitleOfContract, customer.TypeOfCustomer)).ToString("0.##") + "$";
            AccountWidthr.Content = showContract.AccountNumber.ToString("#### #### #### ####");
            AccountDepos.Content = showContract.AccountNumber.ToString("#### #### #### ####");
            WithdrowMoney.Text = Total.Content.ToString().Trim('$');

            ContractOperations();

        }

        private void WithrowingMoney_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (WithdrowMoney.Text != string.Empty)
                {
                   if (Convert.ToDecimal(WithdrowMoney.Text) > 0 && BalanceFromContracts() >= Convert.ToDecimal(WithdrowMoney.Text))
                    {
                        
                       Withdrawing witrowing = new Withdrawing();
                       witrowing.SetWitdrowingToBalance(showContract.AccId, showContract.Id, Convert.ToDecimal(WithdrowMoney.Text), showContract.TitleOfContract.ToString());
                       WithdrowMoney.Clear();
                       Update();
                       



                    }
                   if(BalanceFromContracts() < Convert.ToDecimal(WithdrowMoney.Text))
                    {
                        MessageBox.Show("The number is lees than Your balance");
                    }
                   
                    else
                    {
                        MessageBox.Show("Number is equal or less than 0!");
                    }
                }
                else
                {
                    MessageBox.Show("String is empty");
                }
            }


            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + " Enter the number in decimal format.");
            }
         
        }

        private void DepositeMoney_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DepositingMoney.Text != string.Empty)
                {
                    if (Convert.ToDecimal(DepositingMoney.Text) > 0 && BalanceFromAccount() >= Convert.ToDecimal(DepositingMoney.Text))
                    {
                        Depositing depositing = new Depositing();
                        depositing.DepositMoneyToContracts(showContract.AccId, showContract.Id, Convert.ToDecimal(DepositingMoney.Text), showContract.TitleOfContract.ToString());
                        DepositingMoney.Clear();
                        Update();
                    }
                    if (BalanceFromAccount() < Convert.ToDecimal(DepositingMoney.Text))
                    {
                        MessageBox.Show("The number is lees than Your balance");
                    }
                    else
                    {
                        MessageBox.Show("Number is equal or less than 0!");
                    }
                }
                else
                {
                    MessageBox.Show("String is empty");
                }

                if (Convert.ToDecimal(DepositingMoney.Text) != Convert.ToDecimal(string.Format("##.##")))
                {
                    MessageBox.Show(" Enter the number in decimal format.!!!!!!!!!!!!");
                }

            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message + " Enter the number in decimal format.");
            }
        }

        void Update()
        {
            string query = @"select Balance from Contracts where id = $" + showContract.Id + "";
            try
            {
                customer.OpenConnection();
                using SqlCommand command = new SqlCommand(query, customer._sqlConnection)
                {
                    CommandType = CommandType.Text
                };
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
               
                while (dataReader.Read()) 
                {
                    Total.Content = dataReader["Balance"] + "$";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        public decimal BalanceFromAccount()
        {
            string query = @"select Balance from Accounts where id = $" + showContract.AccId + "";
            try
            {
                customer.OpenConnection();
                using SqlCommand command = new SqlCommand(query, customer._sqlConnection)
                {
                    CommandType = CommandType.Text
                };
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    customer.Ballance = Convert.ToDecimal(dataReader["Balance"]);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return customer.Ballance;

        }

        public decimal BalanceFromContracts()
        {
            string query = @"select Balance from Contracts where id = $" + showContract.Id + "";
            try
            {
                customer.OpenConnection();
                using SqlCommand command = new SqlCommand(query, customer._sqlConnection)
                {
                    CommandType = CommandType.Text
                };
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    customer.Ballance = Convert.ToDecimal(dataReader["Balance"]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return customer.Ballance;
        }

        void ContractOperations()
        {
            try
            {
                
                if (BalanceFromAccount() <=0)
                {

                    DepositingMoney.Text = "0";
                    DepositingMoney.IsEnabled = false;
                    

                }
                if (BalanceFromContracts() <=0)
                {
                    WithdrowMoney.Text = "0";
                    WithdrowMoney.IsEnabled = false;

                }
                if (BalanceFromAccount() > 0)
                {
                    DepositingMoney.Text = BalanceFromAccount().ToString();

                }

                if (BalanceFromContracts() >0)
                {
                    WithdrowMoney.Text = BalanceFromContracts().ToString();
                }

                Withdraw.SelectedItem = showContract.AccId;
                Depoz.SelectedItem = showContract.AccId;

            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

            
        }

        private void Withdraw_PreviewTeztInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void Depositing_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
    }
}
