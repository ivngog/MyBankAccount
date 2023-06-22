using System;
using System.Collections.Generic;
using System.Text;

namespace MyBankAccount.Bank
{
    public abstract partial class Accounts : Customer
    {
        public abstract decimal CalculateInterest(decimal balance, decimal interestrate, int countOfMounth, string typeofcustomer);
        public abstract decimal AccuredInterest(decimal balance, decimal interestrate, int countOfMounth, string typeofcustomer);

    }
}
