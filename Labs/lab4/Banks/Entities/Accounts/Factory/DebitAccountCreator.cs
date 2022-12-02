using System;

namespace Banks.Entities.Accounts
{
    public class DebitAccountCreator : AccountCreator
    {
        public override IAccount Create(decimal percent, Guid id)
        {
            return new DebitAccount(percent, id);
        }
    }
}