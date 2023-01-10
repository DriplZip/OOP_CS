using BusinessLogic.Dto;
using DataAccess.Models;

namespace BusinessLogic.Mapping;

public static class RecordMapping
{
    public static RecordDto AsDto(this Record record)
        => new RecordDto(record.Id, record.EmployeeId);
}