using System;
using System.Collections.Generic;
using System.Text;

namespace MyBankAccount.Bank
{
    class Loan : Accounts
    {
        public decimal Deposits { get; protected set; }
        public string TypeOfAccount { get; set; }
        public override decimal CalculateInterest()
        {


            if ((NumberOfMonth >= 3 && TypeOfCustomer == "Individual") || (NumberOfMonth >= 2 && TypeOfCustomer == "Company"))
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
