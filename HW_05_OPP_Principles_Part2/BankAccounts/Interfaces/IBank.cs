namespace BankAccounts.Interfaces
{
    using System;
    using System.Collections.Generic;
    public interface IBank
    {
        string Name { get; }
        ICollection<IAccount> Accounts { get; }
        void AddAccount(IAccount account);
        void RemoveAccount(IAccount account);
    }
}
