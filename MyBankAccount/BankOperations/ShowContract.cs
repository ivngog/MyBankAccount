using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Windows;
using MyBankAccount.Bank;
using MyBankAccount.Sql;

namespace MyBankAccount.BankOperations
{
    public class ShowContract : Customer
    {
       
       
        public decimal ShowInterestOfDeposite(int Id, string contractName, string typeOfCustomer)
        {
            AccId = Id;
            TypeOfCustomer = typeOfCustomer;
            TitleOfContract = contractName;
            string query = @$"select id, BeginContract, EndContract, InterestRate, Balance, Description from dbo.Contracts where AccId = " + AccId + " and Description = '" + TitleOfContract + "'";
            try
            {
                OpenConnection();
                using SqlCommand command = new SqlCommand(query, _sqlConnection)
                {
                    CommandType = CommandType.Text
                };
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    
                    Ballance = (decimal)dataReader["Balance"];
                    InterestRate = (decimal)dataReader["InterestRate"];
                    ContractBeginDate = (DateTime)dataReader["BeginContract"];
                    ContractEndDate = (DateTime)dataReader["EndContract"];
                    
                    int days = (ContractEndDate - ContractBeginDate).Days;
                    CountOfMonth = (int)(days / 30.415);
                    TitleOfContract = (string)dataReader["Description"];
                    AccountNumber = AccId;
                    this.Id = (int)dataReader["id"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            switch (TitleOfContract)
            {
                case "Deposite":
                    Deposite deposite = new Deposite();
                    InterestOfContract = deposite.AccuredInterest(Ballance, InterestRate, CountOfMonth, TypeOfCustomer);
                    UpdateInterest(this.Id, InterestOfContract);
                    break;
                case "Loan":
                    Loan loan = new Loan();
                    InterestOfContract = loan.AccuredInterest(Ballance, InterestRate, CountOfMonth, TypeOfCustomer);
                    
                    UpdateInterest(this.Id, InterestOfContract);
                    break;
                case "Mortgage":
                    Mortgage mortgage = new Mortgage();
                    InterestOfContract = mortgage.AccuredInterest(Ballance, InterestRate, CountOfMonth, TypeOfCustomer);
                    
                    UpdateInterest(this.Id, InterestOfContract);
                    break;
                default:
                    break;
            }

            return InterestOfContract;
        }

        private void UpdateInterest(int id, decimal interest)
        {
            
            try
            {
                string query = $@"update contracts set interest = " + $"{interest}" + ", Total = Balance + Interest, EndContract = " + $"'{DateTime.Now}'" + " where id = " + $"{id}";
                
                OpenConnection();
                using (SqlCommand command = new SqlCommand(query, _sqlConnection))
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    CloseConnection();
                }
            }
            catch
            {

            }
        }
        







    }
}
