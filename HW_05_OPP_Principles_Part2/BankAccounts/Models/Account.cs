namespace BankAccounts.Models
{
    using System;
    using BankAccounts.Interfaces;
    using System.Text;
    using System.Linq;
    public abstract class Account : IAccount, IDepositable
    {
        private decimal interestRate;
        private DateTime openDate;

        public Account(ICustomer owner, decimal balance, decimal interestRate)
        {
            this.Owner = owner;
            this.Balance = balance;
            this.InterestRate = interestRate;
            this.openDate = DateTime.Now;
        }

        //public int AccountID { get; set; }
        public ICustomer Owner { get; private set; }



        public decimal Balance
        {
            get;
            set;
        }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Interest rate should be >= 0!");
                }
                this.interestRate = value;
            }
        }

        public virtual decimal CalculateInterest(int months)
        {
            if (months < 0)
            {
                throw new ArgumentException("months", "We cannot calculate interest if the number of nonths is negativ!");
            }
            return this.InterestRate * months;
        }

        public void DepositMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("amount", "Deposit amount cannot be less than zero!");
            }
            this.Balance += amount;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append("\nACCOUNT:\n");
            output.AppendFormat("--> owner: {0}\n", this.Owner.Name);
            output.AppendFormat("--> owner type: {0}\n", this.Owner.GetType().Name);
            output.AppendFormat("--> balance: {0}\n", this.Balance);
            output.AppendFormat("--> interest rate: {0}", this.InterestRate);

            return output.ToString();
        }
    }
}
