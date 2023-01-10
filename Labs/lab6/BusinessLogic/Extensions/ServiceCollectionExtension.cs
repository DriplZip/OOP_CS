using BusinessLogic.Services;
using BusinessLogic.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection collection)
    {
        collection.AddScoped<IEmployeeService, EmployeeService>();
        collection.AddScoped<IMessageService, MessageService>();
        collection.AddScoped<IRecordService, RecordService>();
        collection.AddScoped<IAccountService, AccountService>();

        return collection;
    }
}