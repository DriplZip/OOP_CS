using BusinessLogic.Dto;

namespace BusinessLogic.Services.Implementations;

public class EmployeeService: IEmployeeService
{
    public async Task<EmployeeDto> Create(string name, string surname)
    {
        throw new NotImplementedException();
    }

    public async Task<EmployeeDto> FindByFIO(string name, string surname)
    {
        throw new NotImplementedException();
    }

    public async Task<EmployeeDto> FindById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task AddMessage(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task AddDirector(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task AddSubordinates(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool Exist(Guid id)
    {
        throw new NotImplementedException();
    }
}