namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IFindNameUseCase
{
    Task<List<string>> ExecuteAsync();
}
