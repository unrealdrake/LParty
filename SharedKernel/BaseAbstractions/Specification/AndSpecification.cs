using System;
using System.Linq.Expressions;

namespace SharedKernel.BaseAbstractions.Specification
{
    public class AndSpecification<T> : Specification<T>
    {
        public Specification<T> Left;
        public Specification<T> Right;


        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            Right = right;
            Left = left;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = Left.ToExpression();
            Expression<Func<T, bool>> rightExpression = Right.ToExpression();

            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }
    }
}
