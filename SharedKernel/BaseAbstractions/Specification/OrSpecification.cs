using System;
using System.Linq.Expressions;

namespace SharedKernel.BaseAbstractions.Specification
{
    public class OrSpecification<T> : Specification<T>
    {
        public Specification<T> Left;
        public Specification<T> Right;


        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            Right = right;
            Left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = Left.ToExpression();
            var rightExpression = Right.ToExpression();
            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.OrElse(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }
    }
}
