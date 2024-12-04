﻿using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class AssessmentResultDomainService
    : DomainServiceBase<AssessmentResult, Guid>,
    IAssessmentResultDomainService
{
    #region Constructors
    public AssessmentResultDomainService(IAssessmentResultRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}