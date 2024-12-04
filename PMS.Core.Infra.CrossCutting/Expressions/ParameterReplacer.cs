using System.Linq.Expressions;

namespace PMS.Core.Infra.CrossCutting.Expressions;

public class ParameterReplacer
    : ExpressionVisitor
{
    #region Constructors
    public ParameterReplacer(ParameterExpression parameter)
    {
        this._parameter = parameter;
    }
    #endregion Constructors

    #region Fields
    readonly ParameterExpression _parameter;
    #endregion Fields

    #region Methods
    protected override Expression VisitParameter(ParameterExpression node)
    {
        return base.VisitParameter(this._parameter);
    }
    #endregion Methods
}
