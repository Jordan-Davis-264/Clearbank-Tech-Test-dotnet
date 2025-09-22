using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Validators;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Validators;

public abstract class PaymentValidatorTests
{
    protected readonly PaymentValidator PaymentValidator;
    protected PaymentValidatorTests(PaymentValidator paymentValidator)
    {
        PaymentValidator = paymentValidator;
    }

    [Fact]
    public virtual void Validate_AccountIsNull_ShouldReturnFalse()
    {
        //arrange
        var account = (Account)null;
        var request = new MakePaymentRequest();

        //act
        var result = PaymentValidator.Validate(account, request);

        //assert
        Assert.False(result);
    }

    [Fact]
    public virtual void Validate_AccountDoesNotHaveAllowedPaymentScheme_ShouldReturnFalse()
    {
        //arrange
        var account = new Account();
        var request = new MakePaymentRequest();

        //act
        var result = PaymentValidator.Validate(account, request);

        //assert
        Assert.False(result);
    }
}