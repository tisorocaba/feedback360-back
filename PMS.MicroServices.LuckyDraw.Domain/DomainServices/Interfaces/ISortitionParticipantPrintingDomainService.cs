﻿using PMS.Core.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

public interface ISortitionParticipantPrintingDomainService
    : IDomainService<SortitionParticipantPrinting, Guid>
{

}