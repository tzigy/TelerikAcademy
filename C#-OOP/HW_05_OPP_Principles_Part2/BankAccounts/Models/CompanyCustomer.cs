namespace BankAccounts.Models
{
    using System;
    using BankAccounts.Interfaces;    
    class CompanyCustomer : Customer, ICustomer
    {
        public CompanyCustomer(string name)
            : base (name)
        {
           
        }

        //public override string ToString()
        //{
        //    return this.Name;
        //}
    }
}
