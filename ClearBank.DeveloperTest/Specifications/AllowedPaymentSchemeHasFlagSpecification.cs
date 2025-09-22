using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Specifications;

public class AllowedPaymentSchemeHasFlagSpecification : Specification<Account>
{
    public AllowedPaymentSchemeHasFlagSpecification(AllowedPaymentSchemes allowedPaymentSchemes) : base(x => !x.AllowedPaymentSchemes.HasFlag(allowedPaymentSchemes))
    {
    }
}