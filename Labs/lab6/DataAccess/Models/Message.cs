using DataAccess.Enums;

namespace DataAccess.Models;

public class Message
{
    protected Message() { }

    public Message(string message, Guid id, Guid employeeId)
    {
        Id = id;
        MessageText = message;
        CreationTime = DateTime.Now;
        Status = MessageStatus.New;
        Comment = string.Empty;
        EmployeeId = employeeId;
    }

    public Guid Id { get; set; }
    public string MessageText { get; set; }
    public DateTime CreationTime { get; set; }
    public Guid EmployeeId { get; set; }
    public string Comment { get; set; }
    public MessageStatus Status { get; set; }
}