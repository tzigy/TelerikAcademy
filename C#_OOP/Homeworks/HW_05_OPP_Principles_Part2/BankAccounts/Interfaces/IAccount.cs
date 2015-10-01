namespace BankAccounts.Interfaces
{
    using System;
    public interface IAccount
    {        
        ICustomer Owner { get;}
        
        decimal Balance { get; }

        decimal InterestRate { get; }

        decimal CalculateInterest(int months);
    }
}
