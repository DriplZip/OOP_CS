namespace DataAccess.Models;

public class Record
{
    private Record() { }

    public Record(Guid id, Employee employee)
    {
        Id = id;
        Employee = employee;
    }

    public Guid Id { get; set; }
    public Employee Employee { get; set; }
}