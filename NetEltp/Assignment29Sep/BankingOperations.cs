using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment29Sep
{
    public class BankingOperations
    {
        public static ConcurrentBag<Account> UserInfo { get; set; } = new ConcurrentBag<Account>();
    }
}
