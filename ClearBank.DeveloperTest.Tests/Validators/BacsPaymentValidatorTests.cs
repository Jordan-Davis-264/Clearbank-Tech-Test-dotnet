using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Validators;

public class BacsPaymentValidatorTests : PaymentValidatorTests
{
    public BacsPaymentValidatorTests() : base(new BacsPaymentValidator())
    {
    }

    [Fact]
    public void Validate_AccountHasAllowedPaymentScheme_ShouldReturnTrue()
    {
        //arrange
        var account = new Account() { AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs };
        var request = new MakePaymentRequest();

        //act
        var result = PaymentValidator.Validate(account, request);

        //assert
        Assert.True(result);
    }
}