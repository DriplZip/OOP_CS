namespace DataAccess.Models;

public class Account
{
    protected Account() { }

    public Account(Guid id, string login, string passwordHash)
    {
        Id = id;
        Login = login;
        PasswordHash = passwordHash;
    }

    public Guid Id { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }

    // can add, change, comment message
    public bool AllowEmployeeStatus { get; set; }

    // can create/delete/change record, employee, message
    public bool AllowDirectorStatus { get; set; }
}