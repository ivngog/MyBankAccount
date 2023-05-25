using System;
using System.Collections.Generic;
using System.Text;

namespace MyBankAccount.Bank
{
    class Mortgage : Accounts
    {
        public decimal Deposits { get; protected set; }
        public override decimal CalculateInterest()
        {
            if (NumberOfMonth < 12 && TypeOfCustomer == "Company")
            {
                Interest = (InterestRate * NumberOfMonth) / 2;
            }
            if (NumberOfMonth > 12 && TypeOfCustomer == "Company")
            {
                Interest = InterestRate * NumberOfMonth;
            }
            else if (NumberOfMonth > 6 && TypeOfCustomer == "Individual")
            {
                Interest = InterestRate * NumberOfMonth;
            }
            return Interest;
        }
        //Mortgage accounts have ½ the interest rate during the
        //first 12 months for companies and no interest rate during
        //the first 6 months for individuals. 
        public override decimal AccruedInterest()
        {
            return (CalculateInterest() * Ballance) / 100;

        }
    }
}
