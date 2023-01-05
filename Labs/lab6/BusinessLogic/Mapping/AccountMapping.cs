using BusinessLogic.Dto;

namespace BusinessLogic.Mapping;

public static class AccountMapping
{
    public static AccountDto AsDto(this AccountDto account)
        => new AccountDto(account.id, account.login);
}