namespace BankAccounts
{
    interface IDepositAndWithDrawMoney : IDepositMoney
    {
        void WithDraw(decimal amount);
    }
}
