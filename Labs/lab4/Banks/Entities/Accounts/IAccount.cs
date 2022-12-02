namespace Banks.Entities.Accounts
{
    public interface IAccount
    {
        public void Withdrawal(decimal value);
        public void Replenishment(decimal value);
        public void PaymentCalculation();
        public void PercentageCalculation();
    }
}