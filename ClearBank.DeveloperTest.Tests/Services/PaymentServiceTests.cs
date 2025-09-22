using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Options;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Services;

public class PaymentServiceTests
{
    private readonly DataStoreOptions _dataStoreOptions = new() { DataStoreType = DataStoreType.Main };
    private readonly Mock<IDataStoreFactory> _dataStoreFactoryMock;
    private readonly Mock<IPaymentValidatorFactory> _paymentValidatorFactoryMock;
    private readonly PaymentService _paymentService;

    public PaymentServiceTests()
    {
        var dataStoreOptionsMock = new Mock<IOptions<DataStoreOptions>>();
        dataStoreOptionsMock.Setup(s => s.Value).Returns(_dataStoreOptions);
        _dataStoreFactoryMock = new Mock<IDataStoreFactory>();
        _paymentValidatorFactoryMock = new Mock<IPaymentValidatorFactory>();
        _paymentService = new PaymentService(dataStoreOptionsMock.Object, _dataStoreFactoryMock.Object, _paymentValidatorFactoryMock.Object);
    }

    [Fact]
    public void MakePayment_ValidationIsNotSuccess_ShouldReturnMakePaymentResult()
    {
        //arrange
        var request = new MakePaymentRequest();
        var dataStoreMock = new Mock<IDataStore>();
        var account = new Account();
        var paymentValidatorMock = new Mock<IPaymentValidator>();
        _dataStoreFactoryMock.Setup(s => s.Create(_dataStoreOptions.DataStoreType)).Returns(dataStoreMock.Object);
        dataStoreMock.Setup(s => s.GetAccount(request.DebtorAccountNumber)).Returns(account);
        _paymentValidatorFactoryMock.Setup(s => s.Create(request.PaymentScheme)).Returns(paymentValidatorMock.Object);
        paymentValidatorMock.Setup(s => s.Validate(account, request)).Returns(false);

        //act
        var result = _paymentService.MakePayment(request);

        //assert
        Assert.False(result.Success);
        dataStoreMock.Verify(v => v.UpdateAccount(account), Times.Never);
    }

    [Fact]
    public void MakePayment_ValidationIsSuccess_ShouldReturnMakePaymentResult()
    {
        //arrange
        var request = new MakePaymentRequest() { Amount = 1 };
        var dataStoreMock = new Mock<IDataStore>();
        var account = new Account();
        var paymentValidatorMock = new Mock<IPaymentValidator>();
        _dataStoreFactoryMock.Setup(s => s.Create(_dataStoreOptions.DataStoreType)).Returns(dataStoreMock.Object);
        dataStoreMock.Setup(s => s.GetAccount(request.DebtorAccountNumber)).Returns(account);
        _paymentValidatorFactoryMock.Setup(s => s.Create(request.PaymentScheme)).Returns(paymentValidatorMock.Object);
        paymentValidatorMock.Setup(s => s.Validate(account, request)).Returns(true);

        //act
        var result = _paymentService.MakePayment(request);

        //assert
        Assert.True(result.Success);
        dataStoreMock.Verify(v => v.UpdateAccount(account), Times.Once);
        Assert.Equal(-1, account.Balance);
    }
}