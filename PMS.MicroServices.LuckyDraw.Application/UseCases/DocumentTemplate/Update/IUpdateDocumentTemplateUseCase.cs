namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IUpdateDocumentTemplateUseCase
{
    Task ExecuteAsync(DocumentTemplateUseCaseModel? model, bool commit = false);
}
