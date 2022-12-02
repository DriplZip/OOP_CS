using Banks.Tools;

namespace Banks.Entities.Clients
{
    public class Client
    {
        public Client(string name, string surname, int passportId = 0, string address = null)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ClientException("Name is empty");
            if (string.IsNullOrWhiteSpace(surname)) throw new ClientException("Surname is empty");
            if (passportId < 0) throw new ClientException("Incorrect passport id");

            Name = name;
            Surname = surname;
            PassportId = passportId;
            Address = address;
        }
        
        public int PassportId { get; }
        public string Address { get; }
        public string Name { get; }
        public string Surname { get; }
        public bool IsDoubtfulClient() => (PassportId == 0 || Address == null);
    }
}