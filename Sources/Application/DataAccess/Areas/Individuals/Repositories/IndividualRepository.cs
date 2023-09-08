using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanBlazor.DataAccess.Infrastructure.Repositories.Base;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Repositories;

namespace Mmu.CleanBlazor.DataAccess.Areas.Individuals.Repositories;

[UsedImplicitly]
public class IndividualRepository : RepositoryBase<Individual>, IIndividualRepository
{
    public override async Task DeleteAsync(long id)
    {
        var loadedEntity = await Query().SingleOrDefaultAsync(f => f.Id == id);

        if (loadedEntity == null)
        {
            return;
        }

        loadedEntity.MarkAsDeleted();
        Delete(loadedEntity);
    }
}