using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanBlazor.DataAccess.Areas.Individuals.TypeConfigurations.Base;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;

namespace Mmu.CleanBlazor.DataAccess.Areas.Individuals.TypeConfigurations;

public class OrganisationConfig : EntityConfigBase<Organisation>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Organisation> builder)
    {
        builder.Property(f => f.Name).HasMaxLength(100).IsRequired();
        builder.ToTable(nameof(Organisation), Schemas.Individuals);
    }
}