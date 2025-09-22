using ClearBank.DeveloperTest.Enums;

namespace ClearBank.DeveloperTest.Options;

public class DataStoreOptions
{
    public const string Section = "DataStore";
    public DataStoreType DataStoreType { get; set; }
}