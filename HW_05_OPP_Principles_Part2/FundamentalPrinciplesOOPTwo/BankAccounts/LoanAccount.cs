namespace BankAccounts
{
    public class LoanAccount : Account, IDepositMoney
    {
        public LoanAccount(Customer customer, decimal balance, double IR) 
            : base(TypeAccount.Loan ,customer, balance, IR)
        {
        }

        public override decimal CalculateInterestRate(int months)
        {
            if (this.Customer == Customer.Individual)
            {
                if (months <= 3)
                {
                    this.InterestRate = 0;
                }
                months -= 3;
            }
            if (this.Customer == Customer.Company)
            {
                if (months <= 2)
                {
                    this.InterestRate = 0;
                }
                months -= 2;
            }
            return (decimal)(months * this.InterestRate);
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public override string ToString()
        {
            return string.Format("Account type: {0} | Balance: {1:C2} | Interest rate: {2}%.", this.Type, this.Balance, this.InterestRate);
        }
    }
}
