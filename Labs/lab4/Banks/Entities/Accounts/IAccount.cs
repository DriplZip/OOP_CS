namespace Banks.Entities.Accounts
{
    public interface IAccount
    {
        public void Withdrawal(decimal value);
        public void Replenishment(decimal value);
    }
}