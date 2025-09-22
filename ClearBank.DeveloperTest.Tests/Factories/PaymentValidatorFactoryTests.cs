using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Validators;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Factories;

public class PaymentValidatorFactoryTests
{
    private readonly Mock<IKeyedServiceProvider> _serviceProviderMock;
    private readonly PaymentValidatorFactory _paymentValidatorFactory;
    public PaymentValidatorFactoryTests()
    {
        _serviceProviderMock = new Mock<IKeyedServiceProvider>();
        _paymentValidatorFactory = new PaymentValidatorFactory(_serviceProviderMock.Object);
    }

    [Fact]
    public void Create_ShouldReturnPaymentValidator()
    {
        //arrange
        var paymentScheme = PaymentScheme.Bacs;
        var paymentValidatorMock = new Mock<IPaymentValidator>();
        _serviceProviderMock.Setup(s => s.GetKeyedService(typeof(IPaymentValidator), paymentScheme)).Returns(paymentValidatorMock.Object);

        //act
        var result = _paymentValidatorFactory.Create(paymentScheme);

        //assert
        Assert.Same(paymentValidatorMock.Object, result);
    }
}