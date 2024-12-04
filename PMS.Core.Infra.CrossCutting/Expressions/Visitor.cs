using PMS.Core.Infra.CrossCutting.Utilities;
using System.Linq.Expressions;

namespace PMS.Core.Infra.CrossCutting.Expressions;

public class Visitor<T>
    : ExpressionVisitor
{
    #region Constructors
    public Visitor(ParameterExpression parameter)
    {
        this._parameter = parameter;
    }
    #endregion Constructors

    #region Fields
    readonly ParameterExpression _parameter;
    #endregion Fields

    #region Methods
    private MemberExpression VisitFieldMember(MemberExpression node)
    {
        var memberName = node.Member.Name;
        var otherMember = ReflectionUtility.GetField<T>(memberName);
        var inner = Visit(node.Expression);

        MemberExpression field;
        if (otherMember != null)
            field = Expression.Field(inner, otherMember);
        else
            field = node;
        return field;
    }

    protected override Expression VisitMember(MemberExpression node)
    {
        if (node.Member.MemberType != System.Reflection.MemberTypes.Property)
        {
            if (node.Member.MemberType == System.Reflection.MemberTypes.Field)
                return VisitFieldMember(node);
        }

        var memberName = node.Member.Name;
        var otherMember = ReflectionUtility.GetProperty<T>(memberName);
        var inner = Visit(node.Expression);
        return Expression.Property(inner, otherMember);       
    }

    protected override Expression VisitParameter(ParameterExpression node)
    {
        return this._parameter;
    }
    #endregion Methods
}
