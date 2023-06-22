using System;
using System.Collections.Generic;
using System.Text;

namespace MyBankAccount.Bank
{
    public class Deposite : Accounts
    {
        

        public override decimal CalculateInterest(decimal balance, decimal interestrate, int countOfMounth, string typeofcustomer)
        {
            Ballance = balance;
            InterestRate = interestrate;
            CountOfMonth = countOfMounth;
            //Deposit accounts have no interest rate if their balance is positive and less than 1000
            if (Ballance > 0 && Ballance < 1000)
            {
                Interest = 0;
            }
            else
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
