using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Specifications;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validators;

public class ChapsPaymentValidator : PaymentValidator
{
    public ChapsPaymentValidator() : base(AllowedPaymentSchemes.Chaps) { }

    public override bool Validate(Account account, MakePaymentRequest request)
    {
        Specifications.Add(new AccountStatusIsNotLiveSpecification());
        return base.Validate(account, request);
    }
}