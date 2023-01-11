using BusinessLogic.Dto;
using BusinessLogic.Exceptions;
using BusinessLogic.Mapping;
using DataAccess;
using DataAccess.Enums;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BusinessLogic.Services.Implementations;

public class EmployeeService : IEmployeeService
{
    private readonly DatabaseContext _context;

    public EmployeeService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<EmployeeDto> CreateEmployee(string name, string surname)
    {
        Employee employee = new Employee(Guid.NewGuid(), name, surname);

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        return employee.AsDto();
    }

    public async Task<EmployeeDto> FindById(Guid id)
    {
        Employee employee = await _context.Employees.FirstOrDefaultAsync(employee => employee.Id == id);
        if (employee is null) throw new EntityNotFoundException("Employee does not exist");

        return employee.AsDto();
    }

    public async Task Delete(Guid id)
    {
        Employee employee = await _context.Employees.FirstOrDefaultAsync(employee => employee.Id == id);

        if (employee is null) throw new EntityNotFoundException("Employee does not exist");

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }

    public async Task AddMessage(Guid employeeId, Guid messageId)
    {
        Employee employee = await _context.Employees.FirstOrDefaultAsync(employee => employee.Id == employeeId);
        if (employee is null) throw new EntityNotFoundException("Employee does not exist");

        Message message = await _context.Messages.FirstOrDefaultAsync(message => message.Id == messageId);
        if (message is null) throw new EntityNotFoundException("Message does not exist");

        message.EmployeeId = employee.Id;
        message.Status = MessageStatus.New;
        employee.Messages.Add(message);

        _context.Update(employee);
        _context.Update(message);

        await _context.SaveChangesAsync();
    }

    public async Task AddDirector(Guid employeeId, Guid directorId)
    {
        Employee employee = await _context.Employees.FirstOrDefaultAsync(employee => employee.Id == employeeId);
        if (employee is null) throw new EntityNotFoundException("Employee does not exist");

        employee.DirectorId = directorId;
        _context.Update(employee);

        await _context.SaveChangesAsync();
    }

    public async Task AddSubordinates(Guid directorId, Guid subordinatesId)
    {
        Employee director = await _context.Employees.FirstOrDefaultAsync(director => director.Id == directorId);
        if (director is null) throw new EntityNotFoundException("Director does not exist");

        Employee subordinates = await _context.Employees.FirstOrDefaultAsync(employee => employee.Id == subordinatesId);
        if (subordinates is null)
            throw new EntityNotFoundException("Employee does not exist");

        director.Subordinates.Add(subordinates);
        _context.Update(director);

        await _context.SaveChangesAsync();
    }
}