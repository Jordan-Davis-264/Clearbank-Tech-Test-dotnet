using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Enums;

namespace ClearBank.DeveloperTest.Factories;

public interface IDataStoreFactory
{
    IDataStore Create(DataStoreType dataStoreType);
}