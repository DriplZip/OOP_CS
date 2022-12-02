using System;

namespace Banks.Entities.Accounts
{
    public class DepositAccountCreator : AccountCreator
    {
        private decimal _value;
        private decimal _smallPercentage;
        private decimal _averagePercentage;
        private decimal _largePercentage;
        private DateTime _withdrawalUnlockDate;
        private Guid _id;

        public DepositAccountCreator(decimal value, decimal smallPercentage, decimal averagePercentage, decimal largePercentage,
            Guid id, DateTime withdrawalUnlockDate)
        {
            _value = value;
            _smallPercentage = smallPercentage;
            _averagePercentage = averagePercentage;
            _largePercentage = largePercentage;
            _withdrawalUnlockDate = withdrawalUnlockDate;
            _id = id;
        }

        public override IAccount Create()
        {
            DepositAccount account = new DepositAccount(_value, _smallPercentage, _averagePercentage, _largePercentage, _id,
                _withdrawalUnlockDate);
            
            return account;
        }
    }
}