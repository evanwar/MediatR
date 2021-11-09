using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SpecificationDemo.Specifications
{
    public class AndSpecification<T> : Specification<T>
    {

        readonly Specification<T> Left;
        readonly Specification<T> Right;

        public override Expression<Func<T, bool>> Expression
        {
            get
            {
                var param = System.Linq.Expressions.Expression.Parameter(typeof(T));

                var Body = System.Linq.Expressions.Expression.AndAlso(System.Linq.Expressions.Expression.Invoke(Left.Expression, param),
                    System.Linq.Expressions.Expression.Invoke(Right.Expression, param));


                return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(Body, param);


            }
        }


        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            this.Left = left;
            this.Right = right;
        }




    }
}
