namespace BankAccounts.Models
{
    using BankAccounts.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    class Bank : IBank
    {
      //  private string name;
        private ICollection<IAccount> accounts;

        public Bank(string name)
        {
            this.Name = name;
            this.accounts = new List<IAccount>();
        }

        public string Name
        {
            get;
            private set;
        }

        public ICollection<IAccount> Accounts
        {
            get { return this.accounts; }
        }

        public void AddAccount(IAccount account)
        {
            this.accounts.Add(account);
        }

        public void RemoveAccount(IAccount account)
        {
            this.accounts.Remove(account);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0}:", this.Name);
            foreach (var account in this.accounts)
            {
                output.Append(account.ToString());
            }
            return output.ToString();
        }
    }
}
