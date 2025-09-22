using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Specifications;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Validators;

public class FasterPaymentsPaymentValidator : PaymentValidator 
{
    public FasterPaymentsPaymentValidator() : base(AllowedPaymentSchemes.FasterPayments) { }

    public override bool Validate(Account account, MakePaymentRequest request)
    {
        Specifications.Add(new AccountBalanceIsLessThanRequestAmountSpecification(request.Amount));
        return base.Validate(account, request);
    }
}