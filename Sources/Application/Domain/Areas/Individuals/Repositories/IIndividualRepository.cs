﻿using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;
using Mmu.CleanBlazor.Domain.Infrastructure.Data.Repositories;

namespace Mmu.CleanBlazor.Domain.Areas.Individuals.Repositories;

public interface IIndividualRepository : IRepository
{
    Task DeleteAsync(long id);
    Task InsertAsync(Individual ind);

    Task<Individual> LoadSingleAsync(IAggregateSpecification<Individual> spec);
}