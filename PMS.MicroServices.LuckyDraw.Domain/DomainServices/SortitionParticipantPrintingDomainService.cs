﻿using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class SortitionParticipantPrintingDomainService
    : DomainServiceBase<SortitionParticipantPrinting, Guid>,
    ISortitionParticipantPrintingDomainService
{
    #region Constructors
    public SortitionParticipantPrintingDomainService(ISortitionParticipantPrintingRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}
