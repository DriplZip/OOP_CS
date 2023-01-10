using BusinessLogic.Dto;
using DataAccess.Models;

namespace BusinessLogic.Services;

public interface IEmployeeService
{
    Task<EmployeeDto> CreateEmployee(string name, string surname);

    Task<EmployeeDto> FindById(Guid id);

    Task Delete(Guid id);

    Task AddMessage(Guid employeeId, Guid messageId);

    Task AddDirector(Guid employeeId, Guid directorId);

    Task AddSubordinates(Guid directorId, Guid subordinatesId);
}