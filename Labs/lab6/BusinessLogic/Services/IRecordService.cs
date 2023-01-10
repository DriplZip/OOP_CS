using BusinessLogic.Dto;
using DataAccess.Models;

namespace BusinessLogic.Services;

public interface IRecordService
{
    Task<RecordDto> Create(Guid employeeId);
    Task AddNewMessageInRecord(Guid recordId, Guid messageId);
    Task Delete(Guid id);
    Task<RecordDto> FindRecord(Guid id);
}