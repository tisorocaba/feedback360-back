namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IAddDocumentTemplateUseCase
{
    Task ExecuteAsync(DocumentTemplateUseCaseModel? model, bool commit = false);
}
