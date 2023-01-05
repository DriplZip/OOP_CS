namespace DataAccess.Models;

public class Account
{
    private Account() { }

    public Account(Guid id, string login, string passwordHash)
    {
        Id = id;
        Login = login;
        PasswordHash = passwordHash;
    }

    public Guid Id { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
}