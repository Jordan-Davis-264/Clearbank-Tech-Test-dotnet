using System;
using System.Linq.Expressions;

namespace ClearBank.DeveloperTest.Specifications;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Predicate { get; }
}