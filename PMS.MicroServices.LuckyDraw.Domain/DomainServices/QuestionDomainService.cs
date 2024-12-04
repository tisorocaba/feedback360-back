﻿using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class QuestionDomainService
    : DomainServiceBase<Question, Guid>,
    IQuestionDomainService
{
    #region Constructors
    public QuestionDomainService(IQuestionRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}
