namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IFindNickNameUseCase
{
    Task<List<string>> ExecuteAsync();
}
