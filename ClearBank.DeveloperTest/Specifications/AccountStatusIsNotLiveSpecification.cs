using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Specifications;

public class AccountStatusIsNotLiveSpecification : Specification<Account>
{
    public AccountStatusIsNotLiveSpecification() : base(x => x.Status != AccountStatus.Live)
    {
    }
}