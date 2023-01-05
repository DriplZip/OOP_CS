using BusinessLogic.Dto;
using DataAccess.Models;

namespace BusinessLogic.Services;

public interface IMessageService
{
    Task<MessageDto> Create(Employee employee);

    Task<List<ReportsDomain.Models.WorkTask>> GetAllTasks();

    Task<ReportsDomain.Models.WorkTask> GetTaskById(Guid id);

    Task<ReportsDomain.Models.WorkTask> GetTaskByDate(DateTime dateTime);

    Task<ReportsDomain.Models.WorkTask> GetTaskByEmployee(Employee employee);

    List<ReportsDomain.Models.WorkTask> GetUnchangedTasks();

    Task<ReportsDomain.Models.WorkTask> UpdateTaskStatus(Guid id, TaskStatus status);

    Task<ReportsDomain.Models.WorkTask> SetTaskComment(Guid id, string comment);

    Task Delete(Guid id);

    bool Exists(Guid id);
}