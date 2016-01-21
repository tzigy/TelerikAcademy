namespace BankAccounts
{
    using System;

    class BankAccountMain
    {
        static void Main()
        {
            var customer = new DepositAccount(Customer.Individual, 3000, 6.7);
            var anotherCustomer = new MortgageAccount(Customer.Company, 15.5M, 9.9);


            Console.WriteLine(customer.CalculateInterestRate(12));

            Console.WriteLine(customer.Balance);

            customer.Deposit(505.5M);
            Console.WriteLine(customer.Balance);

            var accounts = new Bank("UBB");
            accounts.AddAccount(customer);
            accounts.AddAccount(anotherCustomer);

            Console.WriteLine(accounts.ToString());
        }
    }
}
