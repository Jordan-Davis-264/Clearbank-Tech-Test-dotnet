using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Factories;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Factories;

public class DataStoreFactoryTests
{
    private readonly Mock<IKeyedServiceProvider> _serviceProviderMock;
    private readonly DataStoreFactory _dataStoreFactory;
    public DataStoreFactoryTests()
    {
        _serviceProviderMock = new Mock<IKeyedServiceProvider>();
        _dataStoreFactory = new DataStoreFactory(_serviceProviderMock.Object);
    }

    [Fact]
    public void Create_ShouldReturnDataStore()
    {
        //arrange
        var dataStoreType = DataStoreType.Main;
        var dataStoreMock = new Mock<IDataStore>();
        _serviceProviderMock.Setup(s => s.GetKeyedService(typeof(IDataStore), dataStoreType)).Returns(dataStoreMock.Object);

        //act
        var result = _dataStoreFactory.Create(dataStoreType);

        //assert
        Assert.Same(dataStoreMock.Object, result);
    }
}