using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Specifications;

public class AccountBalanceIsLessThanRequestAmountSpecification : Specification<Account>
{
    public AccountBalanceIsLessThanRequestAmountSpecification(decimal amount) : base(x => x.Balance < amount)
    {
    }
}