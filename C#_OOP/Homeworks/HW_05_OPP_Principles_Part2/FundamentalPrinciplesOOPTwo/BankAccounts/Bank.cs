namespace BankAccounts
{
    using System;
    using System.Collections.Generic;

    public class Bank
    {
        private List<Account> accounts;
        private string name;


        public Bank(string name)
        {
            this.Name = name;
            this.accounts = new List<Account>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be an empty text!");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Name cannot be less than 3 symbols!");
                }
                this.name = value;
            }
        }

        public List<Account> Accounts
        {
            get
            {
                return new List<Account>(this.accounts);
            }
        }

        public void AddAccount(Account acc)
        {
            this.accounts.Add(acc);
        }

        public void RemoveAccount(Account acc)
        {
            this.accounts.Remove(acc);
        }

        public override string ToString()
        {
            return string.Format("Bank name: {0}\n{1}",this.Name ,string.Join("\n", this.accounts));
        }
    }
}
