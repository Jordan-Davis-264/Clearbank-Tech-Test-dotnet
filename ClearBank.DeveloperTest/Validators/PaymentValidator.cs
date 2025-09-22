using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Specifications;
using ClearBank.DeveloperTest.Types;
using System.Collections.Generic;
using System.Linq;

namespace ClearBank.DeveloperTest.Validators;

public abstract class PaymentValidator : IPaymentValidator
{
    protected List<Specification<Account>> Specifications = new();

    protected PaymentValidator(AllowedPaymentSchemes allowedPaymentSchemes)
    {
        Specifications.Add(new AccountIsNullSpecification());
        Specifications.Add(new AllowedPaymentSchemeHasFlagSpecification(allowedPaymentSchemes));
    }
    public virtual bool Validate(Account account, MakePaymentRequest request)
    {
        return Specifications.All(specification => !specification.Predicate.Compile().Invoke(account));
    }
}