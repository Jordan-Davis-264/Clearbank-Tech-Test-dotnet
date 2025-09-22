using System;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace ClearBank.DeveloperTest.Factories;

public class DataStoreFactory : IDataStoreFactory
{
    private readonly IServiceProvider _serviceProvider;

    public DataStoreFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IDataStore Create(DataStoreType dataStoreType)
    {
        return _serviceProvider.GetKeyedService<IDataStore>(dataStoreType);
    }
}