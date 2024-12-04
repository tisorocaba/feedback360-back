﻿using PMS.MicroServices.LuckyDraw.Domain.DomainModels.Base;
using PMS.MicroServices.LuckyDraw.Domain.Enums;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class CoWorker
    : EvaluatableDomainModelBase<AgreementAndSatisfactionEnum>
{
    #region Properties
    public string? Author { get; set; }
    public string? EvaluatedCoWorker { get; set; }
    public string? CoWorkerTeam { get; set; }
    public string? CoWorkerType { get; set; }
    #endregion Properties
}