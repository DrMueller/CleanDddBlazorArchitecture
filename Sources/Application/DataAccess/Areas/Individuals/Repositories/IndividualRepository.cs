using JetBrains.Annotations;
using Mmu.CleanBlazor.DataAccess.Infrastructure.Repositories.Base;
using Mmu.CleanBlazor.Domain.Areas.Common.Specifications;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Repositories;

namespace Mmu.CleanBlazor.DataAccess.Areas.Individuals.Repositories;

[UsedImplicitly]
public class IndividualRepository : RepositoryBase<Individual>, IIndividualRepository
{

}