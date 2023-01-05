namespace DataAccess.Models;

public class Employee
{
    private Employee() { }

    public Employee(Guid id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Messages = new List<Message>();
        Subordinates = new List<Guid>();
    }

    public Guid Id { get; set; }
    public Guid DirectorId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<Message> Messages { get; set; }
    public List<Guid> Subordinates { get; set; }
}