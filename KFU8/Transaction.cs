using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFU8
{
    public class Transaction
    {
        DateTime transaction_time { get; set; }

        readonly decimal amount;

        public Transaction(decimal amount)
        {
            transaction_time = DateTime.Now;
            this.amount = amount;
        }

        public string Print()
        {
            return ($"{transaction_time} совершена транзакция на {amount} рублей , для просмотра деталей обратитесь в поддержку");
        }
    }
}

