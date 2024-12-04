using PMS.Core.Service.Base;

namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class NickNameServiceModel
    : AuditableServiceModelBase<Guid>
{
    #region Properties
    public string? NickName { get; set; }
    #endregion Properties
}
