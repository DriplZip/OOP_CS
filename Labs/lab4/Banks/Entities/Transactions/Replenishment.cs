using Banks.Entities.Accounts;
using Banks.Tools;

namespace Banks.Entities.Banks.Transactions
{
    public class Refill : Transaction
    {
        public Refill(decimal value, IAccount account) : base(value, account)
        {
        }

        public override void Do()
        {
            Account.Replenishment(Value);
        }

        public override void Cancel()
        {
            if (!CanselIsAvailable) throw new AccountException("Transaction already cancelled");
            
            Account.Withdrawal(Value);
            CanselIsAvailable = false;
        }
    }
}