namespace DataAccess.Models;

public class Employee
{
    protected Employee() { }

    public Employee(Guid id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Messages = new List<Message>();
        Subordinates = new List<Employee>();
    }

    public Guid Id { get; set; }
    public Guid DirectorId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public ICollection<Message> Messages { get; set; }
    public ICollection<Employee> Subordinates { get; set; }
}