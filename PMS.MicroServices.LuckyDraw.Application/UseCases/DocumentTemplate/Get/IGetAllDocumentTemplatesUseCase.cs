namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetAllDocumentTemplatesUseCase
{
    Task<List<DocumentTemplateUseCaseModel>> ExecuteAsync();
}
