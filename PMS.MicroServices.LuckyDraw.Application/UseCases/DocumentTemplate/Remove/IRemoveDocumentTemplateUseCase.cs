namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IRemoveDocumentTemplateUseCase
{
    Task ExecuteAsync(Guid id, bool commit = false);
}
