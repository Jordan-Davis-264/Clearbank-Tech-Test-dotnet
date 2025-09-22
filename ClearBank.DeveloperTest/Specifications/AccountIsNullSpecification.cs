using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Specifications;

public class AccountIsNullSpecification : Specification<Account>
{
    public AccountIsNullSpecification() : base(x => x == null)
    {
    }
}