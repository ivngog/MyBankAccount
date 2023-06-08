using System;
using System.Collections.Generic;
using System.Text;
using MyBankAccount.Sql;

namespace MyBankAccount.Bank
{
    

    public partial class Customer : SqlConn
    {
        public string UserName { get; set; }
        public string TypeOfCustomer { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }
        public string EMail { get; set; }
        public DateTime DateOfRegistration { get; set; } = DateTime.Now;
    }
}
