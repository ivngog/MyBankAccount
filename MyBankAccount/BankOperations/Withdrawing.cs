using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using MyBankAccount.Bank;

namespace MyBankAccount.BankOperations
{
    public class Withdrawing : Customer
    {
        public void SetWitdrowingToBalance(int accountId, int contractId, decimal withdrawal, string titleOfAccount)
        {
            TitleOfContract = titleOfAccount;
            if (TitleOfContract == "Deposite")
            {
                try
                {
                    Withdrawal = withdrawal;
                    AccId = accountId;
                    this.Id = contractId;
                    string query = @"update Accounts set Balance = Balance + " + $"{Withdrawal}" + " where id = " + $"{AccId}";

                    OpenConnection();
                    using (SqlCommand command = new SqlCommand(query, _sqlConnection))
                    {
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }

                    CloseConnection();

                    WithdrawFromContract(this.Id, Withdrawal);
                }
                catch
                {

                }

            }

            else
            {
                MessageBox.Show("Withdrawing is not allowed for this account.");
            }
        }

        public void WithdrawFromContract(int id, decimal withdrawal)
        {
            this.Id = id;
            Withdrawal = withdrawal;
            string query = @"update Contracts set Balance = (Total - " + $"{Withdrawal}), BeginContract = "+$"'{ContractBeginDate}'"+ ", Total = Balance where id = " + $"{Id}";
           
            try
            {
                OpenConnection();
                using (SqlCommand command = new SqlCommand(query, _sqlConnection))
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }

                CloseConnection();
                MessageBox.Show("Successfull");
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
