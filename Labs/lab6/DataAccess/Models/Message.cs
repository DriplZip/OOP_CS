using DataAccess.Enums;

namespace DataAccess.Models;

public class Message
{
    private Message() { }

    public Message(Employee employee, string message Guid id)
    {
        Employee = employee;
        Id = id;
        CreationTime = DateTime.Now;
        Status = MessageStatus.New;
    }

    public Guid Id { get; set; }
    public DateTime CreationTime { get; set; }
    public Employee Employee { get; set; }
    public string Comment { get; set; }
    public MessageStatus Status { get; set; }
}