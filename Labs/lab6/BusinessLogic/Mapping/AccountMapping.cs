using BusinessLogic.Dto;
using BusinessLogic.Enums;
using DataAccess.Models;

namespace BusinessLogic.Mapping;

public static class AccountMapping
{
    public static AccountDto AsDto(this Account account)
        => new AccountDto(account.Id, account.Login, GetRole(account).ToString());

    private static AccountRole GetRole(Account account)
    {
        return (account.AllowEmployeeStatus, account.AllowDirectorStatus) switch
        {
            (true, true) => AccountRole.Admin,
            (true, false) => AccountRole.Employee,
            (false, true) => AccountRole.Director,
            _ => AccountRole.User,
        };
    }
}