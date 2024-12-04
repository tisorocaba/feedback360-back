namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetLastSortitionNumberUseCase
{
    Task<int> ExecuteAsync();
}
