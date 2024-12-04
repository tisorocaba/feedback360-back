using PMS.Core.Application.Models.Base;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class NickNameUseCaseModel
    : AuditableUseCaseModelBase<Guid, NickNameUseCaseModel>
{
    #region Methods
    public override void Bind(NickNameUseCaseModel source)
    {
        
    }
    #endregion Methods

    #region Properties
    public string? NickName { get; set; }
    #endregion Properties
}
