using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SpecificationDemo.Specifications
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> Expression { get; }
        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> DelegateExpression = Expression.Compile();

            return DelegateExpression(entity);
        }

        public Specification<T> And(Specification<T> specification) =>
            new AndSpecification<T>(this, specification);
    }
}
