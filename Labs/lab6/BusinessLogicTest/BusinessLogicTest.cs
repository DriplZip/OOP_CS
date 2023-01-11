using BusinessLogic.Dto;
using BusinessLogic.Services.Implementations;
using DataAccess;
using DataAccess.Enums;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Record = Xunit.Record;

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
    public void CreateEmployee_EmployeeCreated()
    { 
        Task<EmployeeDto> employee = _employeeService.CreateEmployee("1", "1");

        Employee? employeeExisting = _database.Employees.FirstOrDefault(x => x.Id == employee.Result.id);
        
        Assert.NotNull(employee);
    }

    [Fact]
    public void DeleteEmployee_EmployeeDeleted()
    {
        Task<EmployeeDto> employee = _employeeService.CreateEmployee("1", "1");
        _employeeService.Delete(employee.Result.id);
        
        Employee? employeeExisting = _database.Employees.FirstOrDefault(x => x.Id == employee.Result.id);
        
        Assert.Null(employeeExisting);
    }
    
    [Fact]
    public void AddDirectorToEmployee_DirectorAdded()
    {
        Task<EmployeeDto> employee = _employeeService.CreateEmployee("1", "1");
        Task<EmployeeDto> director = _employeeService.CreateEmployee("2", "2");
        
        _employeeService.AddDirector(employee.Result.id, director.Result.id);

        Employee? employeeExisting = _database.Employees.FirstOrDefault(x => x.Id == employee.Result.id);

        Assert.Equal(employeeExisting.DirectorId, director.Result.id);
    }
    
    [Fact]
    public void AddSubordinatesToEmployee_SubordinatesAdded()
    {
        Task<EmployeeDto> employee = _employeeService.CreateEmployee("1", "1");
        Task<EmployeeDto> subordinates = _employeeService.CreateEmployee("2", "2");
        
        _employeeService.AddSubordinates(employee.Result.id, subordinates.Result.id);

        Employee? employeeExisting = _database.Employees.FirstOrDefault(x => x.Id == employee.Result.id);

        Assert.Equal(employeeExisting.Subordinates.Last().Id, subordinates.Result.id);
    }

    [Fact]
    public void CreateAccount_AccountCreated()
    {
        Task<AccountDto> account = _accountService.Create("1", "1");

        Account? accountExisting = _database.Accounts.FirstOrDefault(x => x.Id == account.Result.id);
        
        Assert.NotNull(accountExisting);
    }

    [Fact]
    public void GrantEmployeeStatus_EmployeeStatusDone()
    {
        Task<AccountDto> account = _accountService.Create("1", "1");
        _accountService.GrantEmployeeStatus(account.Result.id);
        
        Account? accountExisting = _database.Accounts.FirstOrDefault(x => x.Id == account.Result.id);
        
        Assert.True(accountExisting.AllowEmployeeStatus);
    }
    
    [Fact]
    public void GrantDirectorStatus_DirectorStatusDone()
    {
        Task<AccountDto> account = _accountService.Create("1", "1");
        _accountService.GrantDirectorStatus(account.Result.id);
        
        Account? accountExisting = _database.Accounts.FirstOrDefault(x => x.Id == account.Result.id);
        
        Assert.True(accountExisting.AllowDirectorStatus);
    }

    [Fact]
    public void CreateMessage_MessageCreated()
    {
        Task<EmployeeDto> employee = _employeeService.CreateEmployee("1", "1");
        Task<MessageDto> message = _messageService.Create("text", employee.Result.id);

        Message? messageExisting = _database.Messages.FirstOrDefault(x => x.Id == message.Result.messageId);
        
        Assert.NotNull(messageExisting);
    }

    [Fact]
    public void SetMessageComment_CommentWasSet()
    {
        const string comment = "comment";
        
        Task<EmployeeDto> employee = _employeeService.CreateEmployee("1", "1");
        Task<MessageDto> message = _messageService.Create("text", employee.Result.id);

        _messageService.SetMessageComment(message.Result.messageId, comment);
        
        Message? messageExisting = _database.Messages.FirstOrDefault(x => x.Id == message.Result.messageId);
        
        Assert.Equal(comment, messageExisting.Comment);
    }

    [Fact]
    public void UpdateMessageStatus_MessageStatusUpdated()
    {
        const MessageStatus messageStatus = MessageStatus.New;
        
        Task<EmployeeDto> employee = _employeeService.CreateEmployee("1", "1");
        Task<MessageDto> message = _messageService.Create("text", employee.Result.id);

        _messageService.UpdateMessageStatus(message.Result.messageId, messageStatus);
        
        Message? messageExisting = _database.Messages.FirstOrDefault(x => x.Id == message.Result.messageId);
        
        Assert.Equal(messageStatus, messageExisting.Status);
    }
    
    [Fact]
    public void DeleteMessage_MessageDeleted()
    {
        Task<EmployeeDto> employee = _employeeService.CreateEmployee("1", "1");
        Task<MessageDto> message = _messageService.Create("text", employee.Result.id);

        _messageService.Delete(message.Result.messageId);
        
        Message? messageExisting = _database.Messages.FirstOrDefault(x => x.Id == message.Result.messageId);
        
        Assert.Null(messageExisting);
    }

    [Fact]
    public void CreateRecord_RecordCreated()
    {
        Task<EmployeeDto> employee = _employeeService.CreateEmployee("1", "1");
        Task<RecordDto> record = _recordService.Create(employee.Result.id);

        DataAccess.Models.Record? recordExisting = _database.Records.FirstOrDefault(x => x.Id == record.Result.id);
        
        Assert.NotNull(recordExisting);
    }

    [Fact]
    public void AddNewMessageToRecord_MessageAdded()
    {
        Task<EmployeeDto> employee = _employeeService.CreateEmployee("1", "1");
        Task<RecordDto> record = _recordService.Create(employee.Result.id);
        Task<MessageDto> message = _messageService.Create("text", employee.Result.id);

        _recordService.AddNewMessageInRecord(record.Result.id, message.Result.messageId);
        
        DataAccess.Models.Record? recordExisting = _database.Records.FirstOrDefault(x => x.Id == record.Result.id);
        
        Assert.Equal(1, recordExisting.Messages.Count);
    }

    [Fact]
    public void DeleteRecord_RecordDeleted()
    {
        Task<EmployeeDto> employee = _employeeService.CreateEmployee("1", "1");
        Task<RecordDto> record = _recordService.Create(employee.Result.id);

        _recordService.Delete(record.Result.id);
        DataAccess.Models.Record? recordExisting = _database.Records.FirstOrDefault(x => x.Id == record.Result.id);
        
        Assert.Null(recordExisting);
    }
}