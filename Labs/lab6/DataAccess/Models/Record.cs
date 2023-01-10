namespace DataAccess.Models;

public class Record
{
    protected Record() { }

    public Record(Guid id, Guid employeeId)
    {
        Id = id;
        EmployeeId = employeeId;
        Messages = new List<Message>();
    }

    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public ICollection<Message> Messages { get; set; }
}