namespace Banks.Entities.Banks.Transactions
{
    public interface ITransaction
    {
        public void Do();
        public void Cancel();
    }
}