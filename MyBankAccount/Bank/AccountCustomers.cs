using System;
using System.Collections.Generic;
using System.Text;
using MyBankAccount.Sql;

namespace MyBankAccount.Bank
{
    public partial class Customer : SqlConn
    {
        
        //public string AccountType => $"{this.GetType().Name} Account";

        //public abstract decimal Overdraft { get; protected set; }
        //public decimal Depositing { get; protected set; }//public decimal Opening { get; protected set; }
        //public decimal Fees { get; protected set; }
        

        public int Id { get; set; }
        public int AccId { get; set; }
        public decimal InterestOfContract { get; set; }
        public int CountOfMonth { get; set; }
        public decimal Ballance { get; set; }
        public decimal InterestRate { get; set; }
        public decimal Interest { get; protected set; }
        public DateTime ContractBeginDate { get; set; } = DateTime.Now;
        public DateTime ContractEndDate { get; set; }
        public decimal Withdrawal { get; protected set; }
        //public string Description { get; set; }
        public string TitleOfContract { get; set; }
        public decimal Depositing { get; set; }

        private static readonly Random _random = new Random();

        //= _random.Next(0000000000, 1000000000);
        public Int64 BankAccount { get; set; }
        public Int64 AccountNumber {
            get { return BankAccount; }
            set {  BankAccount = 1000000000000000 + value; }
        }

    }
}
