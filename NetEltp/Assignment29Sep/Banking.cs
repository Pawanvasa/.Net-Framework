using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment29Sep
{
    public class Banking
    {
        public void CreateAccount(Account account)
        { 
            Random random = new Random();
            account.AccountNumber=random.Next(100000,999999);
            account.NetBalence = account.OpeningBalence;
            BankingOperations.UserInfo.Add(account);
            //Console.WriteLine("Account Created Successfully");
        }
    }
}
