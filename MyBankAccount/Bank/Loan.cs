using System;
using System.Collections.Generic;
using System.Text;

namespace MyBankAccount.Bank
{
    public class Loan : Accounts
    {
        //public decimal Deposits { get; protected set; }
        //public string TypeOfAccount { get; set; }
        public override decimal CalculateInterest(decimal balance, decimal interestrate, int countOfMounth, string typeofCustomer)
        {
            Ballance = balance;
            InterestRate = interestrate;
            CountOfMonth = countOfMounth;
            TypeOfCustomer = typeofCustomer;
            

            if ((CountOfMonth >= 3 && TypeOfCustomer == "Individual") || (CountOfMonth >= 2 && TypeOfCustomer == "Company"))
            {
                Interest = InterestRate * CountOfMonth;
            }
            return Interest;
        }

        public override decimal AccuredInterest(decimal balance, decimal interestrate, int countOfMounth, string typeofcustomer)
        {
            return (CalculateInterest(balance, interestrate, countOfMounth, typeofcustomer) * balance) / 100;
        }
    }
}
