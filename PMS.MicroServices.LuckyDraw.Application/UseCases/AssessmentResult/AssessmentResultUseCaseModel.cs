using PMS.Core.Application.Models.Base;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class AssessmentResultUseCaseModel
    : AuditableUseCaseModelBase<Guid, AssessmentResultUseCaseModel>
{
    #region Methods
    public override void Bind(AssessmentResultUseCaseModel source)
    {
        
    }
    #endregion Methods

    #region Properties
    public Guid? IdSortition { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? NickName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string Code { get; set; } = default!;
    public bool BelongsToManagementTeam { get; set; }
    public bool HasImmediateSubordinates { get; set; }
    public bool HasMediateSubordinates { get; set; }

    public virtual SortitionUseCaseModel? Sortition { get; set; }
    #endregion Properties
}
