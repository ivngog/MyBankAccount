using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using MyBankAccount.Bank;

namespace MyBankAccount.BankOperations
{
    class Depositing : Customer
    {
        public void DepositMoneyToContracts(int accountId, int contractId, decimal depositing, string titleOfAccount)
        {
            try
            {
                AccId = accountId;
                this.Id = contractId;
                Depositing = depositing;
                TitleOfContract = titleOfAccount;
                string query = @"update contracts set Balance = Balance + " + $"{Depositing}" + " where id = " + $"{this.Id}";

                OpenConnection();
                using (SqlCommand command = new SqlCommand(query, _sqlConnection))
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }

                CloseConnection();

                UpdateBalanceAccount(AccId, Depositing);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateBalanceAccount(int id, decimal deposite)
        {
            try
            {
                AccId = id;
                Depositing = deposite;
                string query = @"update accounts set Balance = Balance - " + $"{Depositing}" + " where id = " + $"{AccId}";

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
