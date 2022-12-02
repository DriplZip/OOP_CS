﻿using System;
using Banks.Tools;

namespace Banks.Entities.Accounts
{
    public class DepositAccount : IAccount
    {
        private decimal _value;
        private decimal _percent;
        private Guid _id;

        public DepositAccount(decimal percent, Guid id)
        {
            if (percent < 0) throw new AccountException("Percent cannot less than 0");

            _percent = percent;
            _id = id;
        }
        public void Withdrawal(decimal value)
        {
            if (value < 0) throw new AccountException("Value cannot less than 0");
            if (value > _value) throw new AccountException("You cannot withdraw more money than you have in your account");

            _value -= value;
        }

        public void Replenishment(decimal value)
        {
            if (value < 0) throw new AccountException("Value cannot less than 0");

            _value += value;
        }
    }
}