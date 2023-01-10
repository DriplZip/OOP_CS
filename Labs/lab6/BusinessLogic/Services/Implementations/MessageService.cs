using BusinessLogic.Dto;
using BusinessLogic.Exceptions;
using BusinessLogic.Mapping;
using DataAccess;
using DataAccess.Enums;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BusinessLogic.Services.Implementations;

public class MessageService : IMessageService
{
    private readonly DatabaseContext _context;

    public MessageService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<MessageDto> Create(string text, Guid employeeId)
    {
        Message message = new Message(text, Guid.NewGuid(), employeeId);

        _context.Messages.Add(message);
        await _context.SaveChangesAsync();

        return message.AsDto();
    }

    public async Task<MessageDto> GetMessageById(Guid id)
    {
        Message message = await _context.Messages.FirstOrDefaultAsync(message => message.Id == id);

        return message.AsDto();
    }

    public async Task<List<MessageDto>> GetMessagesByEmployee(Guid employeeId)
    {
        List<MessageDto> messageDtos = new List<MessageDto>();
        List<Message> messages = new List<Message>( _context.Messages.Where(message => message.EmployeeId == employeeId));

        foreach (Message message in messages)
        {
            messageDtos.Add(message.AsDto());
        }

        return messageDtos;
    }

    public async Task<List<MessageDto>> GetNotViewedMessages()
    {
        List<MessageDto> messageDtos = new List<MessageDto>();
        List<Message> messages = new List<Message>(_context.Messages.Where(message => message.Status == MessageStatus.New));

        foreach (Message message in messages)
        {
            messageDtos.Add(message.AsDto());
        }

        return messageDtos;
    }

    public async Task<MessageDto> UpdateMessageStatus(Guid id, MessageStatus status)
    {
        Message message = await _context.Messages.FirstOrDefaultAsync(message => message.Id == id);
        if (message is null) throw new EntityNotFoundException("Message does not exist");

        if (status < message.Status) throw new BusinessLogicException("Incorrect message status");
        message.Status = status;

        _context.Update(message);
        await _context.SaveChangesAsync();

        return message.AsDto();
    }

    public async Task<MessageDto> SetMessageComment(Guid id, string comment)
    {
        Message message = await _context.Messages.FirstOrDefaultAsync(message => message.Id == id);
        if (message is null) throw new EntityNotFoundException("Message does not exist");

        message.Comment = comment;

        _context.Update(message);
        await _context.SaveChangesAsync();

        return message.AsDto();
    }

    public async Task Delete(Guid id)
    {
        Message message = await _context.Messages.FirstOrDefaultAsync(message => message.Id == id);
        if (message is null) throw new EntityNotFoundException("Message does not exist");

        _context.Messages.Remove(message);
        await _context.SaveChangesAsync();
    }
}