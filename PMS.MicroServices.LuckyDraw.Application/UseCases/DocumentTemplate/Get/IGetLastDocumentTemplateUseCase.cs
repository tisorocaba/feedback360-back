namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetLastDocumentTemplateUseCase
{
    Task<DocumentTemplateUseCaseModel?> ExecuteAsync();
}
