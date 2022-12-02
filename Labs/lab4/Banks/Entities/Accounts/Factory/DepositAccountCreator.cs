using System;

namespace Banks.Entities.Accounts
{
    public class DepositAccountCreator : AccountCreator
    {
        public override IAccount Create(decimal percent, Guid id)
        {
            return new DepositAccount(percent, id);
        }
    }
}