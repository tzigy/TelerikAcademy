namespace BankAccounts.Models
{
    using System;
    using BankAccounts.Interfaces;
    public abstract class Customer : ICustomer
    {
        private string name;

        public Customer(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "Customer name cannot be null, empty string or white spaces!");
                }
                this.name = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
