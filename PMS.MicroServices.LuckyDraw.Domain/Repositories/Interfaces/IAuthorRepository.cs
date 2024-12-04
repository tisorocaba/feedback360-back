﻿using PMS.Core.Domain.Repositories.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

public interface IAuthorRepository
    : IRepository<Author, Guid>
{

}
