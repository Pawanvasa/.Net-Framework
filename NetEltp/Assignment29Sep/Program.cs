using Assignment29Sep;

Banking bank = new();
Account account = new();
BankTransactions bankTransactions = new();
int choice=0;
do
{
    Console.WriteLine("1. Create Account In bank");
    Console.WriteLine("2. Perform Withdraw or Diposite");
    Console.WriteLine("3. Stop Execution");
    try {
        choice = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    switch (choice)
    {
        case 1:
            Console.WriteLine("Enter AccountName");
            string name1 = Console.ReadLine();
            Console.WriteLine("Enter Opening Balence");
            int openingBalence1 = Convert.ToInt32(Console.ReadLine());
            account = new Account()
            {
                AccountName = name1,
                OpeningBalence = openingBalence1
            };
            bank.CreateAccount(account);
            break;
        case 2:
            foreach (var records in BankingOperations.UserInfo)
            {
                Task task1 = Task.Factory.StartNew(() => {
                    bankTransactions.Diposite(records);
                    Console.WriteLine($"Performing Deposite on {records.AccountName} Account");
                    Thread.Sleep(200);
                    Console.WriteLine($"Transaction type = {records.TransactionType} Transaction Amount = {records.TransactionAmount} NetBalence = {records.NetBalence} Account Name = {records.AccountName} ");
                    Console.WriteLine();
                });
                Task task2 = Task.Factory.StartNew(() => {
                    bankTransactions.WithDrawal(records);
                   // Console.WriteLine($"Performing Withdraw on {records.AccountName} Account");
                    Console.WriteLine($"Transaction type = {records.TransactionType} Transaction Amount = {records.TransactionAmount} NetBalence = {records.NetBalence} Account Name = {records.AccountName} ");
                    Console.WriteLine();
                });
                Task.WaitAll(task1, task2);
            }
            break;
        case 3:
            foreach (var record in BankingOperations.UserInfo)
            {
                Console.WriteLine(record.AccountName + " " + record.NetBalence);
            }
            break;
    }
} while (choice!=3);