using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment29Sep
{
    public class BankTransactions
    {
        public  Account Diposite(Account account)
        { 
            Random random = new Random();
            int maxValue = account.NetBalence;
            int dipositeAmount = random.Next(0, maxValue);
            account.NetBalence = account.NetBalence + dipositeAmount;
            account.TransactionType = "Credit";
            account.TransactionAmount=dipositeAmount;
            return account;
        }
        public  Account WithDrawal(Account account)
        {
            Random rand = new Random();
            int withdrawAmount = rand.Next(0, account.NetBalence);
            account.NetBalence = account.NetBalence - withdrawAmount;
            account.TransactionType = "Debit";
            account.TransactionAmount=withdrawAmount;
            return account;

        }
    }
}
