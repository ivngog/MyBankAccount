using System;
using System.Collections.Generic;
using System.Text;
using MyBankAccount.Sql;

namespace MyBankAccount.Bank
{
    public partial class Customer : SqlConn
    {
        //public string Customer { get; set; }
        //public string AccountType => $"{this.GetType().Name} Account";

        //public abstract decimal Overdraft { get; protected set; }

        //public decimal Opening { get; protected set; }
        //public decimal Fees { get; protected set; }
        public int NumberOfMonth { get; set; }
        //public decimal Depositing { get; protected set; }
        public decimal Ballance { get; set; }
        public decimal InterestRate { get; set; }
        public decimal Interest { get; protected set; }
        public DateTime ContractBeginDate { get; set; } = DateTime.Now;
        public DateTime DateOfOpenAcc { get; set; } = DateTime.Now;
        public string Description { get; set; }
        private static readonly Random _random = new Random();
        public int AccountNumber { get; protected set; } = _random.Next(0000000000, 1000000000);

    }
}
