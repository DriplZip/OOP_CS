using BusinessLogic.Dto;
using DataAccess.Models;

namespace BusinessLogic.Mapping;

public static class EmployeeMapping
{
    public static EmployeeDto AsDto(this Employee employee)
    {
        return new EmployeeDto(employee.Id, employee.Name, employee.Surname);
    }
}