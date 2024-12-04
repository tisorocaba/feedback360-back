namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class SortitionConsultRequestMessage
{
    #region Properties
    public Guid IdTeam { get; set; }
    public int ParticipantNumber { get; set; }
    public string Code { get; set; } = default!;
    #endregion Properties
}
