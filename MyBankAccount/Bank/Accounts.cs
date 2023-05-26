using System;
using System.Collections.Generic;
using System.Text;

namespace MyBankAccount.Bank
{
    public abstract class Accounts:Customer
    {
        
        //public string Customer { get; set; }
        //public string AccountType => $"{this.GetType().Name} Account";

        //public abstract decimal Overdraft { get; protected set; }

        //public decimal Opening { get; protected set; }
        //public decimal Fees { get; protected set; }


        public int NumberOfMonth { get; set; }
        
        //public decimal Depositing { get; protected set; }
        public decimal Ballance { get; set; }
        public decimal InterestRate { get; set; } = 4m;
        public decimal Interest { get; protected set; }
        
        public DateTime ContractBeginDate { get; set; }
        


        private static readonly Random _random = new Random();

        
        public int AccountNumber { get; protected set; } = _random.Next(1000000000, 2000000000);

        public abstract decimal CalculateInterest();
        public abstract decimal AccruedInterest();

        

    }
}
