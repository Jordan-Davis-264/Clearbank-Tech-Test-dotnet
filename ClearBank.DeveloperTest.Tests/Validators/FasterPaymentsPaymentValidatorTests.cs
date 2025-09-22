using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Validators;

public class FasterPaymentsPaymentValidatorTests : PaymentValidatorTests
{
    public FasterPaymentsPaymentValidatorTests() : base(new FasterPaymentsPaymentValidator())
    {
    }
    
    [Fact]
    public void Validate_AccountBalanceIsLessThanRequestAmount_ShouldReturnFalse()
    {
        //arrange
        var account = new Account() { AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments, Balance = 1 };
        var request = new MakePaymentRequest() { Amount = 2 };

        //act
        var result = PaymentValidator.Validate(account, request);

        //assert
        Assert.False(result);
    }

    [Fact]
    public void Validate_AccountHasAllowedPaymentScheme_ShouldReturnTrue()
    {
        //arrange
        var account = new Account() { AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments, Balance = 2 };
        var request = new MakePaymentRequest() { Amount = 1 };

        //act
        var result = PaymentValidator.Validate(account, request);

        //assert
        Assert.True(result);
    }
}