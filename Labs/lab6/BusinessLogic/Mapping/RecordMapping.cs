using BusinessLogic.Dto;

namespace BusinessLogic.Mapping;

public static class RecordMapping
{
    public static RecordDto AsDto(this RecordDto record)
        => new RecordDto(record.id, record.employee);
}