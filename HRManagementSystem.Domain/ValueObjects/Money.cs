using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Domain.ValueObjects
{
    public class Money
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; } = "EGP";

        private Money() { }

        public Money(decimal amount, string currency = "EGP")
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative.");

            Amount = amount;
            Currency = currency;
        }

        public Money Add(Money other)
        {
            if (Currency != other.Currency)
                throw new InvalidOperationException("Currencies must match.");

            return new Money(Amount + other.Amount, Currency);
        }

        public Money Subtract(Money other)
        {
            if (Currency != other.Currency)
                throw new InvalidOperationException("Currencies must match.");

            if (Amount < other.Amount)
                throw new InvalidOperationException("Resulting amount cannot be negative.");

            return new Money(Amount - other.Amount, Currency);
        }


        public override string ToString() => $"{Amount} {Currency}";
    }
}
