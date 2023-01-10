using BusinessLogic.Dto;

namespace BusinessLogic.Services;

public interface IAccountService
{
    Task<AccountDto> Create(string login, string password);
    Task<AccountDto> FindAccount(string login, string password);
    Task<AccountDto> GrantEmployeeStatus(Guid accountId);
    Task<AccountDto> GrantDirectorStatus(Guid accountId);
}