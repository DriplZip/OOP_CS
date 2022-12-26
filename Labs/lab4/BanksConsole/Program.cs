using System;
using Banks.Entities.Banks;
using BanksConsole.Commands;

namespace BanksConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to BankApp\n You can run the following commands: \n" +
                              "createCentralBank\n" +
                              "createBank\n" +
                              "createClient\n" +
                              "createAccount\n" +
                              "doTransaction\n");
            
            bool breaker = true;
            while (breaker)
            {
                switch (Console.ReadLine())
                {
                    case "createCentralBank":
                        CreateCentralBank createCentralBank = new CreateCentralBank();
                        createCentralBank.Do();
                        break;
                    case "createBank":
                        CreateBank createBank = new CreateBank();
                        createBank.Do();
                        break;
                    case "createClient":
                        CreateClient createClient = new CreateClient();
                        createClient.Do();
                        break;
                    case "createAccount":
                        CreateAccount createAccount = new CreateAccount();
                        createAccount.Do();
                        break;
                    case "doTransaction":
                        DoTransaction doTransaction = new DoTransaction();
                        doTransaction.Do();
                        break;
                    default:
                        breaker = false;
                        break;
                }
            }
        }
    }
}