namespace BankAccounts
{
    public class MortgageAccount : Account, IDepositMoney
    {
        public MortgageAccount(Customer customer, decimal balance, double IR)
            : base(TypeAccount.Mortgage, customer, balance, IR)
        {
        }


        public override decimal CalculateInterestRate(int months)
        {
            var halfIR = this.InterestRate / 2;
            int promoMonths = 6;
            decimal rate;
            if (this.Customer == Customer.Company)
	        {
                promoMonths = 12;
	        }

            var leftMonths = months - promoMonths;

            if (months <= promoMonths)
            {
                rate = (decimal)(months * halfIR);
            }
            else
            {
                var promoPeriodRate = promoMonths * halfIR;
                var leftPeriodRate = leftMonths * this.InterestRate;
                rate = (decimal)(promoPeriodRate + leftPeriodRate);
            }   
            return rate;
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
