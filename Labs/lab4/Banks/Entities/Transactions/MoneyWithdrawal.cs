using Banks.Entities.Accounts;

namespace Banks.Entities.Banks.Transactions
{
    public class MoneyWithdrawal : Transaction
    {
        public MoneyWithdrawal(decimal value, IAccount account) : base(value, account)
        {
        }

        public override void Do()
        {
            throw new System.NotImplementedException();
        }

        public override void Cancel()
        {
            throw new System.NotImplementedException();
        }
    }
}