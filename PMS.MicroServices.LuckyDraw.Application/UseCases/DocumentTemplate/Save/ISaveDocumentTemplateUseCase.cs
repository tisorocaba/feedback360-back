namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface ISaveDocumentTemplateUseCase
{
    Task ExecuteAsync(DocumentTemplateUseCaseModel? model, bool commit = false);
}
