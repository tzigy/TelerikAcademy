namespace BankAccounts.Models
{
    using System;
    using BankAccounts.Interfaces;
    class IndividualCustomer : Customer, ICustomer
    {
        public IndividualCustomer(string name):
            base(name)
        {

        }


    }
}
