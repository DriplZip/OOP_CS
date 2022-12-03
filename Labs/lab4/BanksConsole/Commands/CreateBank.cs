namespace BanksConsole.Commands
{
    public class CreateBank : ICommand
    {
        public void Do()
        {
            CreateCentralBank.CentralBank.AddBank();
        }
    }
}