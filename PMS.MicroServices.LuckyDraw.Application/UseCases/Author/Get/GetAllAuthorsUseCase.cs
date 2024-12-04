using Mapster;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Expressions;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class GetAllAuthorsUseCase
    : UseCaseBase,
    IGetAllAuthorsUseCase
{
    #region Constructors
    public GetAllAuthorsUseCase(IAuthorDomainService authorDomainService)
    {
        this._authorDomainService = authorDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly IAuthorDomainService _authorDomainService;
    #endregion Fields

    #region Methods
    public async Task<List<AuthorUseCaseModel>> ExecuteAsync()
    {
        OrderByExpression<AuthorUseCaseModel, object> orderByName = AuthorUseCaseExpressions.NameOrderByAscending;
        var domainModels = await this._authorDomainService.GetAllAsync(orderByName.ConvertTo<AuthorUseCaseModel, Author, object>());
        var useCaseModels = new List<AuthorUseCaseModel>(domainModels.Count());
        domainModels.ToList().ForEach(e => useCaseModels.Add(e.Adapt<AuthorUseCaseModel>(this.AdapterConfig)));
        return useCaseModels;
    }
    #endregion Methods
}
