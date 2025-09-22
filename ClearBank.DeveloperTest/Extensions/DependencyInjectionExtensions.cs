using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Options;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClearBank.DeveloperTest.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDataStoreFactory, DataStoreFactory>();
        services.AddKeyedScoped<IDataStore, AccountDataStore>(DataStoreType.Main);
        services.AddKeyedScoped<IDataStore, BackupAccountDataStore>(DataStoreType.Backup);

        services.AddScoped<IPaymentValidatorFactory, IPaymentValidatorFactory>();
        services.AddKeyedScoped<IPaymentValidator, BacsPaymentValidator>(PaymentScheme.Bacs);
        services.AddKeyedScoped<IPaymentValidator, ChapsPaymentValidator>(PaymentScheme.Chaps);
        services.AddKeyedScoped<IPaymentValidator, FasterPaymentsPaymentValidator>(PaymentScheme.FasterPayments);

        services.AddScoped<IPaymentService, PaymentService>();
        services.Configure<DataStoreOptions>(configuration.GetSection(DataStoreOptions.Section));
        return services;
    }
}