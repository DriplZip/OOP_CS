using BusinessLogic.Dto;
using BusinessLogic.Exceptions;
using BusinessLogic.Mapping;
using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BusinessLogic.Services.Implementations;

public class RecordService : IRecordService
{
    private readonly DatabaseContext _context;

    public RecordService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<RecordDto> Create(Guid employeeId)
    {
        Employee employee = await _context.Employees.FirstOrDefaultAsync(employee => employee.Id == employeeId);
        if (employee is null) throw new EntityNotFoundException("Employee does not exist");

        Record record = new Record(Guid.NewGuid(), employee.Id);

        _context.Records.Add(record);
        await _context.SaveChangesAsync();

        return record.AsDto();
    }

    public async Task AddNewMessageInRecord(Guid recordId, Guid messageId)
    {
        Record record = await _context.Records.FirstOrDefaultAsync(record => record.Id == recordId);
        if (record is null) throw new EntityNotFoundException("Record does not exist");

        Message message = await _context.Messages.FirstOrDefaultAsync(message => message.Id == messageId);
        if (message is null) throw new EntityNotFoundException("Message does not exist");

        record.Messages.Add(message);

        _context.Update(record);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        Record record = await _context.Records.FirstOrDefaultAsync(record => record.Id == id);
        if (record is null) throw new EntityNotFoundException("Record does not exist");

        _context.Records.Remove(record);
        await _context.SaveChangesAsync();
    }

    public async Task<RecordDto> FindRecord(Guid id)
    {
        Record record = await _context.Records.FirstOrDefaultAsync(record => record.Id == id);
        if (record is null) throw new EntityNotFoundException("Record does not exist");

        return record.AsDto();
    }
}