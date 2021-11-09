using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SpecificationDemo.Specifications
{
    public class GenericSpecification<T>
    {

        public Expression<Func<T, bool>> Expression { get; }


        public GenericSpecification(Expression<Func<T, bool>> Expression)
        {
            this.Expression = Expression;
        }

        public bool IsSatisfiedBy(T entity)
        {
            return Expression.Compile().Invoke(entity);
        }
    }
}
