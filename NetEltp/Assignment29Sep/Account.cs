using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment29Sep
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public string ?AccountName { get; set; }
        public int OpeningBalence { get; set; }
        public string ?TransactionType { get; set; }
        public int TransactionAmount { get; set; }
        public int NetBalence { get; set; }
    }
}
