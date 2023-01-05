using BusinessLogic.Dto;

namespace BusinessLogic.Mapping;

public static class EmployeeMapping
{
    public static EmployeeDto AsDto(this EmployeeDto employee)
        => new EmployeeDto(employee.id, employee.name, employee.surname);
}