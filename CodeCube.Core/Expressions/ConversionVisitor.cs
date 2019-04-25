using System.Linq;
using System.Linq.Expressions;

namespace CodeCube.Core.Expressions
{
    internal sealed class ConversionVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression _newParameter;
        private readonly ParameterExpression _oldParameter;

        public ConversionVisitor(ParameterExpression newParameter, ParameterExpression oldParameter)
        {
            _newParameter = newParameter;
            _oldParameter = oldParameter;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _newParameter; // replace all old param references with new ones
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression != _oldParameter) // if instance is not old parameter - do nothing
                return base.VisitMember(node);

            var newObj = Visit(node.Expression);
            var newMember = _newParameter.Type.GetMember(node.Member.Name).First();
            return Expression.MakeMemberAccess(newObj, newMember);
        }
    }
}
