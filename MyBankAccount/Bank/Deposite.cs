using System;
using System.Collections.Generic;
using System.Text;

namespace MyBankAccount.Bank
{
    public class Deposite : Accounts
    {
        public decimal Withdrawals { get; protected set; }

        public override decimal CalculateInterest()
        {

            //Deposit accounts have no interest rate if their balance is positive and less than 1000
            if (Ballance > 0 && Ballance < 1000)
            {
                Interest = 0;
            }
            else
            {
                Interest = InterestRate * NumberOfMonth;
            }
            return Interest;
        }

        public override decimal AccruedInterest()
        {
            return (CalculateInterest() * Ballance) / 100;
        }
    }
}
