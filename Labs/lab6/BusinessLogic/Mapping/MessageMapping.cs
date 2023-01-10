using BusinessLogic.Dto;
using DataAccess.Models;

namespace BusinessLogic.Mapping;

public static class MessageMapping
{
    public static MessageDto AsDto(this Message message)
        => new MessageDto(message.EmployeeId, message.MessageText, message.Comment, message.Id, message.CreationTime, message.Status);
}