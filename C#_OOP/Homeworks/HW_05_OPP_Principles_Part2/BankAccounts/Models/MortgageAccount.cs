namespace BankAccounts.Models
{
    using BankAccounts.Interfaces;
    using System;
    using System.Text;
    class MortgageAccount : Account, IDepositable
    {
        public MortgageAccount(ICustomer owner, decimal balance, decimal interestRate)
            : base(owner, balance, interestRate)
        {

        }

        public override decimal CalculateInterest(int months)
        {
            decimal interest = 0.0m;
            string customerType = this.Owner.GetType().Name;

            if (customerType == "CompanyCustomer")
            {
                if(months <= 12)
                {
                    interest = base.CalculateInterest(months) / 2;
                }
                else
                {
                    interest = (base.CalculateInterest(12) / 2) + base.CalculateInterest(months - 12) ;
                }                
            }
            else if (customerType == "IndividualCustomer")
            {
                if(months <= 6)
                {
                    interest = 0;
                }
                else
                {
                    base.CalculateInterest(months - 6);
                }
            }
            else
            {
                throw new ArgumentException("Unknown customer type!");
            }
            return interest;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.Append("\n--> type: Mortgage");
            return output.ToString();
        }
    }
}
