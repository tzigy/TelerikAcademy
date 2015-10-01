namespace BankAccounts
{
    public class DepositAccount : Account, IDepositAndWithDrawMoney
    {

        public DepositAccount(Customer customer, decimal balance, double IR) 
            : base(TypeAccount.Deposit, customer, balance, IR)
        {
        }

        public override decimal CalculateInterestRate(int months)
        {
            if (this.Balance >= 0 && this.Balance <= 1000)
            {
                this.InterestRate = 0; 
            }
            return (decimal)(months * this.InterestRate);
        }

        public void WithDraw(decimal amount)
        {
            this.Balance -= amount;
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
