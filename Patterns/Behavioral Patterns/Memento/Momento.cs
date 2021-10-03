using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral_Patterns.Memento
{
    public class Memento
    {
        public int Balance;

        public Memento(int amount)
        {
            Balance = amount;
        }
    }

    public class BankAccount
    {
        public int Balance;

        public BankAccount(int amount)
        {
            Balance = amount;
        }

        public Memento Deposit(int amount)
        {
            Balance += amount;
            return new Memento(Balance);
        }

        public void Restore(Memento memento)
        {
            Balance = memento.Balance;
        }

        public override string ToString()
        {
            return $"{nameof(Balance)}: {Balance}";
        }
    }
}
