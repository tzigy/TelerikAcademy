namespace BankAccounts.Models
{
    using BankAccounts.Interfaces;
    using System;
    using System.Text;
    class LoanAccount : Account
    {
        public LoanAccount(ICustomer owner, decimal balance, decimal interestRate)
            : base (owner, balance, interestRate)
        {

        }

        public override decimal CalculateInterest(int months)
        {
            decimal interest;
            string customerType = this.Owner.GetType().Name;

            if (customerType == "CompanyCustomer")
            {
                months = Math.Max(0, months - 2);
                interest = base.CalculateInterest(months);                
            }
            else if (customerType == "IndividualCustomer")
            {
                months = Math.Max(0, months - 3);
                interest = base.CalculateInterest(months);
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
            output.Append("\n--> type: Loan");
            return output.ToString();
        }
    }
}
