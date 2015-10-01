namespace BankAccounts
{
    using System;
    using BankAccounts.Models;
    class BankAccountsTest
    {
        static void Main()
        {
            Bank myBank = new Bank("MY Bank");

            myBank.AddAccount(new DepositAccount(new CompanyCustomer("Coca Cola"), 1000000.0m, 1200));
            myBank.AddAccount(new DepositAccount(new IndividualCustomer("Ivan Ivanov"), 1300.0m, 12));
            myBank.AddAccount(new LoanAccount(new IndividualCustomer("Miroslav Marinov"), 20300.0m, 1800));
            myBank.AddAccount(new LoanAccount(new CompanyCustomer("Elan"), 450500.0m, 21000));


            //DepositAccount da = new DepositAccount(new CompanyCustomer("Coca Cola"), 1000000.0m, 1200);

            Console.WriteLine(myBank); 
        }
    }
}
