using System.Security.Cryptography;
using System.Text;
using BusinessLogic.Dto;
using BusinessLogic.Exceptions;
using BusinessLogic.Mapping;
using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BusinessLogic.Services.Implementations;

public class AccountService : IAccountService
{
    private readonly DatabaseContext _context;

    public AccountService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<AccountDto> Create(string login, string password)
    {
        if (string.IsNullOrWhiteSpace(login)) throw new BusinessLogicException("Incorrect login");
        if (string.IsNullOrWhiteSpace(password)) throw new BusinessLogicException("Incorrect password");

        string passwordHash = GetPasswordHash(password);

        Account account = new Account(Guid.NewGuid(), login, passwordHash);

        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();

        return account.AsDto();
    }

    public async Task<AccountDto> FindAccount(string login, string password)
    {
        if (string.IsNullOrWhiteSpace(login)) throw new BusinessLogicException("Incorrect login");
        if (string.IsNullOrWhiteSpace(password)) throw new BusinessLogicException("Incorrect password");

        string passwordHash = GetPasswordHash(password);

        Account account = await _context.Accounts.FirstOrDefaultAsync(account =>
            account.Login == login && account.PasswordHash == passwordHash);

        return account.AsDto();
    }

    public async Task<AccountDto> GrantEmployeeStatus(Guid accountId)
    {
        Account account = await _context.Accounts.FirstOrDefaultAsync(account => account.Id == accountId);
        account.AllowEmployeeStatus = true;

        await _context.SaveChangesAsync();
        return account.AsDto();
    }

    public async Task<AccountDto> GrantDirectorStatus(Guid accountId)
    {
        Account account = await _context.Accounts.FirstOrDefaultAsync(account => account.Id == accountId);
        account.AllowDirectorStatus = true;

        await _context.SaveChangesAsync();
        return account.AsDto();
    }

    private static string GetPasswordHash(string password)
    {
        using var hashingAlgorithm = SHA256.Create();
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        return BitConverter.ToString(hashingAlgorithm.ComputeHash(passwordBytes));
    }
}