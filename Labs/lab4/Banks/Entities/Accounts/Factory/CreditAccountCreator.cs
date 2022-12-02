using System;

namespace Banks.Entities.Accounts
{
    public class CreditAccountCreator : AccountCreator
    {
        public override IAccount Create(decimal percent, Guid id)
        {
            return new CreditAccount(percent, id);
        }
    }
}