using System;
using System.Linq.Expressions;

namespace ClearBank.DeveloperTest.Specifications;

public abstract class Specification<T> : ISpecification<T>
{
    protected Specification(Expression<Func<T, bool>> predicate)
    {
        Predicate = predicate;
    }

    public Expression<Func<T, bool>> Predicate { get; }
}