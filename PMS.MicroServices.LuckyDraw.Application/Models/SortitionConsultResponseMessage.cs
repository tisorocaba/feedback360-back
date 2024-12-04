namespace PMS.MicroServices.LuckyDraw.Application.Models;

public class SortitionConsultResponseMessage
{
    #region Properties
    public int SortitionParticipantNumber { get; set; }
    public int AccessCounter { get; set; }
    public Guid? IdTeam { get; set; }
    public Guid IdSortition { get; set; }
    public int SortitionNumber { get; set; }
    public bool SortitionActive { get; set; }
    public string Result { get; set; } = default!;
    #endregion Properties
}
