using System.Linq.Expressions;

namespace Mmu.CleanBlazor.Common.LanguageExtensions
{
    public static class ExpressionExtensions
    {
        public static string GetPropertyName<T>(this Expression<Func<T, object>> expr)
        {
            Expression body = expr.Body;

            // strip boxing (value types -> object)
            if (body is UnaryExpression unary && unary.NodeType == ExpressionType.Convert)
            {
                body = unary.Operand;
            }

            if (body is MemberExpression member)
            {
                return member.Member.Name; // the actual property name
            }

            throw new ArgumentException("Expression is not a property access", nameof(expr));
        }

        public static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (!(propertyExpression.Body is MemberExpression memberExpression))
            {
                throw new ArgumentException(
                    "You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }

            return memberExpression.Member.Name;
        }
    }
}