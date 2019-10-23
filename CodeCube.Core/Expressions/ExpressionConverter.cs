using System;
using System.Linq.Expressions;

namespace CodeCube.Core.Expressions
{
    /// <summary>
    /// Class to convert type in lambda expression to another desired type.
    /// </summary>
    /// <see>
    ///     <cref>http://stackoverflow.com/questions/4601844/expression-tree-copy-or-convert</cref>
    /// </see>
    /// <typeparam name="TTo">The type to convert to.</typeparam>
    public sealed class ExpressionConverter<TTo>
    {
        /// <summary>
        /// Convert an labmda expression to a lambda expression of a different type.
        /// </summary>
        /// <typeparam name="TFrom">The object to convert from.</typeparam>
        /// <typeparam name="TOut">The object to convert to.</typeparam>
        /// <param name="expression">The expression to convert.</param>
        /// <returns>The expression created with the new type.</returns>
        public static Expression<Func<TTo, TOut>> Convert<TFrom, TOut>(Expression<Func<TFrom, TOut>> expression)
        {
            var oldParameter = expression.Parameters[0];
            var newParameter = Expression.Parameter(typeof(TTo), oldParameter.Name);
            var converter = new ConversionVisitor(newParameter, oldParameter);
            var newBody = converter.Visit(expression.Body);
            return Expression.Lambda<Func<TTo, TOut>>(newBody, newParameter);
        }
    }
}
