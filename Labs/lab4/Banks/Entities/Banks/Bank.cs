using System;
using System.Collections.Generic;
using Banks.Entities.Accounts;
using Banks.Entities.Clients;
using Banks.Observer;
using Banks.Tools;

namespace Banks.Entities.Banks
{
    public class Bank : IObservable
    {
        private Dictionary<Client, List<IAccount>> _clientAccounts;
        private List<IObserver> _observers;

        public Bank(BankConfig bankConfig)
        {
            BankConfig = bankConfig;

            _clientAccounts = new Dictionary<Client, List<IAccount>>();
            _observers = new List<IObserver>();
        }
        
        public BankConfig BankConfig { get; }

        public void CreateAccount(Client client, AccountType type)
        {
            Guid accountId = Guid.NewGuid();
            AccountCreator accountCreator = GetFactory(type, accountId);
            IAccount account = accountCreator.Create();

            if (_clientAccounts.ContainsKey(client))
                _clientAccounts[client].Add(account);
            else
                _clientAccounts.Add(client, new List<IAccount>() {account});
        }

        public void AddClient(Client client)
        {
            if (_clientAccounts.ContainsKey(client)) throw new BankException("Client already exist");
            
            _clientAccounts.Add(client, new List<IAccount>());
        }

        private AccountCreator GetFactory(AccountType type, Guid id)
        {
            return type switch
            {
                AccountType.Credit => new CreditAccountCreator(BankConfig.Commission, BankConfig.CreditLimit, id),
                AccountType.Debit => new DebitAccountCreator(BankConfig.Percent, id),
                AccountType.Deposit => new DepositAccountCreator(BankConfig.SmallPercentage,
                    BankConfig.AveragePercentage,
                    BankConfig.LargePercentage, id, BankConfig.WithdrawalUnlockDate),
                _ => throw new BankException("Account type does not exist")
            };
        }

        public void RegisterObserver(IObserver observer)
        {
            if (_observers.Contains(observer)) throw new BankException("Observer already exist");
            
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            if (!_observers.Contains(observer)) throw new BankException("Observer does not exist");
            
            _observers.Remove(observer);
        }

        public void NotifyObservers(string message)
        {
            foreach (IObserver observer in _observers)
            {
                observer.Update(message);
            }
        }
    }

    public class BankConfig
    {
        public BankConfig(string name, decimal commission, decimal percent, decimal smallPercentage, decimal averagePercentage,
            decimal largePercentage, decimal creditLimit, decimal transferLimit, DateTime withdrawalUnlockDate)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new BankException("Incorrect bank name");
            if (commission < 0) throw new BankException("Commission cannot less than 0");
            if (percent < 0 || smallPercentage < 0 || averagePercentage < 0 || largePercentage < 0)
                throw new BankException("Percent cannot less than 0");
            if (transferLimit < 0) throw new BankException("Transfer cannot less than 0");

            Name = name;
            Commission = commission;
            Percent = percent;
            SmallPercentage = smallPercentage;
            AveragePercentage = averagePercentage;
            LargePercentage = largePercentage;
            CreditLimit = creditLimit;
            TransferLimit = transferLimit;
            WithdrawalUnlockDate = withdrawalUnlockDate;
        }

        public string Name { get; }
        public decimal Commission { get; private set; }
        public decimal Percent { get; private set; }
        public decimal SmallPercentage { get; private set; }
        public decimal AveragePercentage { get; private set; }
        public decimal LargePercentage { get; private set; }
        public decimal CreditLimit { get; private set; }
        public decimal TransferLimit { get; private set; }
        public DateTime WithdrawalUnlockDate { get; }

        public void ChangeCommission(decimal commission)
        {
            if (commission < 0) throw new BankException("Commission cannot less than 0");

            Commission = commission;
        }
        public void ChangePercent(decimal percent)
        {
            if (percent < 0) throw new BankException("Percent cannot less than 0");

            Percent = percent;
        }
        public void ChangeSmallPercentage(decimal smallPercentage)
        {
            if (smallPercentage < 0) throw new BankException("Percent cannot less than 0");

            SmallPercentage = smallPercentage;
        }
        public void ChangeAveragePercentage(decimal averagePercentage)
        {
            if (averagePercentage < 0) throw new BankException("Percent cannot less than 0");

            AveragePercentage = averagePercentage;
        }
        public void ChangeLargePercentage(decimal largePercentage)
        {
            if (largePercentage < 0) throw new BankException("Percent cannot less than 0");

            LargePercentage = largePercentage;
        }
        public void ChangeCreditLimit(decimal creditLimit)
        {
            CreditLimit = creditLimit;
        }

        public void ChangeTransferLimit(decimal transferLimit)
        {
            if (transferLimit < 0) throw new BankException("Transfer limit cannot less than 0");

            TransferLimit = transferLimit;
        }
    }
    
}