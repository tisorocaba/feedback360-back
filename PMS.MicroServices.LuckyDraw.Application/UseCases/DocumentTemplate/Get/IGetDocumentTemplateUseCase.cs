namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetDocumentTemplateUseCase
{
    Task<DocumentTemplateUseCaseModel?> ExecuteAsync(Guid id);
}
