using BusinessLogic.Services.Implementations;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BusinessLogicTest;

public class BusinessLogicTest : IDisposable
{
    private DatabaseContext _database;

    private AccountService _accountService;
    private EmployeeService _employeeService;
    private MessageService _messageService;
    private RecordService _recordService;

    public BusinessLogicTest()
    {
        _database = new DatabaseContext(new DbContextOptions<DatabaseContext>());
        
        _accountService = new AccountService(_database);
        _employeeService = new EmployeeService(_database);
        _messageService = new MessageService(_database);
        _recordService = new RecordService(_database);
    }

    public void Dispose()
    {
        _database.Dispose();
    }

    [Fact]
    public void CreateEmployee()
    {
        
    }
}