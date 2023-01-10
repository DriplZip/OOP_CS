using BusinessLogic.Dto;
using DataAccess.Enums;
using DataAccess.Models;

namespace BusinessLogic.Services;

public interface IMessageService
{
    Task<MessageDto> Create(string text, Guid employeeId);

    Task<MessageDto> GetMessageById(Guid id);

    Task<List<MessageDto>> GetMessagesByEmployee(Guid employeeId);

    Task<List<MessageDto>> GetNotViewedMessages();

    Task<MessageDto> UpdateMessageStatus(Guid id, MessageStatus status);

    Task<MessageDto> SetMessageComment(Guid id, string comment);

    Task Delete(Guid id);
}