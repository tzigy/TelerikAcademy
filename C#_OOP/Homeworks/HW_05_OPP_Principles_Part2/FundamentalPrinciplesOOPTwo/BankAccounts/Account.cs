namespace BankAccounts
{
    using System;
    public abstract class Account
    {
        private const string ExceptionMessageForIR = "Interest Rate cannot be negative or over 100%!"; 
        private double interestRate;


        public Account(TypeAccount type, Customer customer, decimal balance, double IR)
        {
            this.Type = type;
            this.Customer = customer;
            this.InterestRate = IR;
            this.Balance = balance;
        }

        public TypeAccount Type { get; private set; }

        public Customer Customer { get; private set; }

        public decimal Balance { get; protected set; }

        public double InterestRate
        {
            get 
            { 
                return this.interestRate; 
            }

            protected set 
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessageForIR);
                }
                this.interestRate = value;
            }
        }

        public abstract decimal CalculateInterestRate(int months);
    }
}
