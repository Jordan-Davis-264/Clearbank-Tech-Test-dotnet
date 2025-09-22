using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Validators;

public class ChapsPaymentValidatorTests : PaymentValidatorTests
{
    public ChapsPaymentValidatorTests() : base(new ChapsPaymentValidator())
    {
    }

    [Theory]
    [InlineData(AccountStatus.Disabled)]
    [InlineData(AccountStatus.InboundPaymentsOnly)]
    public void Validate_AccountIsNotLive_ShouldReturnFalse(AccountStatus accountStatus)
    {
        //arrange
        var account = new Account() { AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Status = accountStatus };
        var request = new MakePaymentRequest();

        //act
        var result = PaymentValidator.Validate(account, request);

        //assert
        Assert.False(result);
    }

    [Fact]
    public void Validate_AccountIsLive_ShouldReturnTrue()
    {
        //arrange
        var account = new Account() { AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Status = AccountStatus.Live};
        var request = new MakePaymentRequest();

        //act
        var result = PaymentValidator.Validate(account, request);

        //assert
        Assert.True(result);
    }
}