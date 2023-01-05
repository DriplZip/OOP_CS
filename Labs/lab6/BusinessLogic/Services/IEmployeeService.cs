using BusinessLogic.Dto;

namespace BusinessLogic.Services;

public interface IEmployeeService
{
    Task<EmployeeDto> Create(string name, string surname);

    Task<EmployeeDto> FindByFIO(string name, string surname);

    Task<EmployeeDto> FindById(Guid id);

    Task Delete(Guid id);

    Task AddMessage(Guid id);

    Task AddDirector(Guid id);

    Task AddSubordinates(Guid id);

    bool Exist(Guid id);
}