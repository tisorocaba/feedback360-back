using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IFindOneDocumentTemplateUseCase
{
    Task<DocumentTemplateUseCaseModel?> ExecuteAsync(Expression<Func<DocumentTemplateUseCaseModel, bool>> expression);
}
