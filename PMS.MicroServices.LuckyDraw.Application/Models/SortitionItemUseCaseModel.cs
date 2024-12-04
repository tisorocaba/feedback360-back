namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class SortitionItemUseCaseModel
{
    #region Properties
    public string AccessKey { get; set; } = default!;
    public int Key { get; set; }
    public List<int> Values { get; set; } = default!;
    #endregion Properties
}
