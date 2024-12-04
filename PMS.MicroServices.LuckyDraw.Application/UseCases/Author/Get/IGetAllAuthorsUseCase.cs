using PMS.MicroServices.LuckyDraw.Application.Models;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetAllAuthorsUseCase
{
    Task<List<AuthorUseCaseModel>> ExecuteAsync();
}
