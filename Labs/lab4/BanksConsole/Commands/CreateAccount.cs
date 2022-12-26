using System;
using Banks.Entities.Accounts;
using Banks.Entities.Banks;
using Banks.Entities.Clients;
using Banks.Tools;

namespace BanksConsole.Commands
{
    public class CreateAccount : ICommand
    {
        private CentralBank _centralBank = CreateCentralBank.CentralBank;
        
        public void Do()
        {
            Console.WriteLine("Enter client passport id");
            int passportId = Convert.ToInt32(Console.ReadLine());
            Client client = _centralBank.FindClient(passportId);
            Console.WriteLine("Enter bankName");
            string bankName = Console.ReadLine();
            Bank bank = _centralBank.FindBank(bankName) ?? throw new BankException("Bank does not exist");
            Console.WriteLine("Enter account type: Debit Deposit Credit");
            switch (Console.ReadLine())
            {
                case "Debit":
                    bank.CreateAccount(client, AccountType.Debit);
                    break;
                case "Deposit":
                    bank.CreateAccount(client, AccountType.Deposit);
                    break;
                case "Credit":
                    bank.CreateAccount(client, AccountType.Credit);
                    break;
                default:
                    Console.WriteLine("Account has not been created");
                    break;
            }
            
            Console.WriteLine("Account successfully created");
        }
    }
}