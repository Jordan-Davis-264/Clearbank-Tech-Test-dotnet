using ClearBank.DeveloperTest.Enums;

namespace ClearBank.DeveloperTest.Validators;

public class BacsPaymentValidator : PaymentValidator
{
    public BacsPaymentValidator() : base(AllowedPaymentSchemes.Bacs) { }
}