using System;
using System.Collections.Generic;
using System.Text;

namespace MyBankAccount.Bank
{
    public class Mortgage : Accounts
    {
        public decimal Deposits { get; protected set; }
        public override decimal CalculateInterest(decimal balance, decimal interestrate, int countOfMounth, string typeofcustomer)
        {
            Ballance = balance;
            InterestRate = interestrate;
            CountOfMonth = countOfMounth;
            TypeOfCustomer = typeofcustomer;
            if (CountOfMonth < 12 && TypeOfCustomer == "Company")
            {
                Interest = (InterestRate * CountOfMonth) / 2;
            }
            if (CountOfMonth > 12 && TypeOfCustomer == "Company")
            {
                Interest = InterestRate * CountOfMonth;
            }
            else if (CountOfMonth > 6 && TypeOfCustomer == "Individual")
            {
                Interest = InterestRate * CountOfMonth;
            }
            return Interest;
        }
        //Mortgage accounts have ½ the interest rate during the
        //first 12 months for companies and no interest rate during
        //the first 6 months for individuals. 
        public override decimal AccuredInterest(decimal balance, decimal interestrate, int countOfMounth, string typeofcustomer)
        {
            return (CalculateInterest(balance, interestrate, countOfMounth, typeofcustomer) * balance) / 100;
        }
    }
}
