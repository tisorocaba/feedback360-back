﻿using PMS.Core.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

public interface IEvaluationResultDomainService
    : IDomainService<EvaluationResult, Guid>
{

}