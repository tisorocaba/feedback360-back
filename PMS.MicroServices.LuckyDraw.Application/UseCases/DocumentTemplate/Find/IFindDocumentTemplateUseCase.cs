using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IFindDocumentTemplateUseCase
{
    Task<List<DocumentTemplateUseCaseModel>> ExecuteAsync(Expression<Func<DocumentTemplateUseCaseModel, bool>> expression);
}
