using System;
namespace KFU8
{
    public enum AccountType
    {
        Current,
        Savings
    }



    public class Bank
    {
        protected static uint id_counter = 1;
        protected uint id;
        protected decimal Balance;
        protected AccountType accountType;
        protected Queue<Transaction> transactions = new Queue<Transaction>();
        protected bool flag_dispose = false;


        public void CreateUniqeID()
        {
            id_counter++;
        }

        public Bank()
        {
            CreateUniqeID();
            id = id_counter;
        }
        public Bank(AccountType accountType)
        {
            CreateUniqeID();
            id = id_counter;
            this.accountType = accountType;
        }

        public Bank(decimal Balance)
        {
            CreateUniqeID();
            id = id_counter;
            this.Balance = Balance;
        }

        public Bank(AccountType accountType , decimal Balance)
        {
            CreateUniqeID();
            id = id_counter;
            this.accountType = accountType;
            this.Balance = Balance;
        }



        public void WithDraw(decimal amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Не достаточно средств для снятия введенной суммы :(");
            }
            else
            {
                Transaction transaction = new Transaction(amount);
                transactions.Enqueue(transaction);
                Balance -= amount;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount > 10)
            {
                Transaction transaction = new Transaction(amount);
                transactions.Enqueue(transaction);
                Balance += amount;
            }
            else
            {
                Console.WriteLine("Можно переводить только от 10 рублей\n");
            }
        }

        public void Transfer(Bank account, decimal amount, Bank account1)
        {
            if (amount > account.Balance)
            {
                Console.WriteLine("Не достаточно средств для перевода введенной суммы :(");
            }
            else
            {
                Transaction transaction = new Transaction(amount);
                transactions.Enqueue(transaction);
                account.Balance -= amount;
                account1.Balance += amount;
                Console.WriteLine($"Совершен перевод {amount} рублей на счет {account1.id}, ваш баланс {account.Balance}, если перевод совершили не вы или возникла ошибка, обратитесь в поддержку по номеру горячей линии +79375975337");
            }


        }
        public void GetBalance()
        {
            Console.WriteLine($"Ваш баланс - {Balance}");
        }

        public void Dispose()
        {
            if (!flag_dispose)
            {
                foreach(Transaction trans in transactions)
                {
                    File.WriteAllText("transactions.txt", trans.Print());
                }
                transactions.Clear();
                flag_dispose = true;

                GC.SuppressFinalize(this);
            }
        }

        public override string ToString()
        {
            return $"AccountNumber - {id}, Balance - {Balance}, AccountType - {accountType}";
        }
    }
}

