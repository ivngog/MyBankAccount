using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Windows;
using MyBankAccount.Bank;
namespace MyBankAccount.BankOperations
{
    public class OpenContract:Customer
    {
        public void InsertIntoContracts(string interestrate, string balance, int AccountId, string description)
        {
            CultureInfo culture = new CultureInfo("en-US");
            //to correct convert to decimal format 0.01 the parametries of windows must be set region: America(usa) 
            InterestRate = Convert.ToDecimal(interestrate.Trim(), culture);
            Ballance = Convert.ToDecimal(balance.Trim(), culture);
            TitleOfContract = description;
            AccId = AccountId;
            try
            {
                string sql = $@"Insert into Contracts (BeginContract,InterestRate, Balance, AccId, Description) values " + $"('{ContractBeginDate}', {InterestRate}, {Ballance}, {AccId}, '{TitleOfContract }')";
                OpenConnection();
                using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    CloseConnection();
                    MessageBox.Show("Congratulation!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error!");
            }
        }

    }
}
