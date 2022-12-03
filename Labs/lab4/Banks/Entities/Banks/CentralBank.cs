using System.Collections.Generic;
using Banks.Entities.Clients;
using Banks.TimeAccelerationMechanism;
using Banks.Tools;

namespace Banks.Entities.Banks
{
    public class CentralBank
    {
        private List<Bank> _banks;
        private List<Client> _clients;

        public CentralBank()
        {
            _banks = new List<Bank>();
            _clients = new List<Client>();
        }

        public void AddBank(Bank bank)
        {
            if (_banks.Contains(bank)) throw new BankException("Bank already exist");
            
            _banks.Add(bank);
        }
        
        public void AddClient(Client client)
        {
            if (_clients.Contains(client)) throw new BankException("Client already exist");
            
            _clients.Add(client);
        }
        
        
        
        public TimeAccelerator TimeAccelerator { get; }
    }
}