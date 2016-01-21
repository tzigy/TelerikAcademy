namespace BankAccounts.Models
{
    using BankAccounts.Interfaces;
using System;
    using System.Text;
    class DepositAccount : Account, IDepositable, IDrawable
    {
        public DepositAccount(ICustomer owner, decimal balance, decimal interestRate)
            : base (owner, balance, interestRate)
        {

        }

        public void DrawMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("amount", "Draw amount cannot be less than zero!");
            }
            this.Balance -= amount;
        }

        public override decimal CalculateInterest(int months)
        {
            decimal interest;

            if (this.Balance > 0 && this.Balance < 1000)
            {
                interest = 0.0m;
            }
            else
            {
                interest = base.CalculateInterest(months);
            }
            return interest;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.Append("\n--> type: Deposit");
            return output.ToString();
        }
        
    }
}
