using System.Collections.Generic;
using Banks.Entities.Clients;
using Banks.TimeAccelerationMechanism;

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
        
        public TimeAccelerator TimeAccelerator { get; }
    }
}