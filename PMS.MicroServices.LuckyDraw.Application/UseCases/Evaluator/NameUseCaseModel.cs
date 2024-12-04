using PMS.Core.Application.Models.Base;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class NameUseCaseModel
    : AuditableUseCaseModelBase<Guid, NameUseCaseModel>
{
    #region Methods
    public override void Bind(NameUseCaseModel source)
    {

    }
    #endregion Methods

    #region Properties
    public string? Name { get; set; }
    #endregion Properties
}
