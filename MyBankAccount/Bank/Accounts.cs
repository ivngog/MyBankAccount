using System;
using System.Collections.Generic;
using System.Text;

namespace MyBankAccount.Bank
{
    public abstract partial class Accounts : Customer
    {
        

        public abstract decimal CalculateInterest();
        public abstract decimal AccruedInterest();

    }
}
