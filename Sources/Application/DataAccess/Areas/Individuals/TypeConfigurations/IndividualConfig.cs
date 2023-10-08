using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanBlazor.DataAccess.Areas.Individuals.TypeConfigurations.Base;
using Mmu.CleanBlazor.Domain.Areas.Individuals.Models;

namespace Mmu.CleanBlazor.DataAccess.Areas.Individuals.TypeConfigurations;

public class IndividualConfig : EntityConfigBase<Individual>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Individual> builder)
    {
        builder.Property(f => f.BirthDate).IsRequired();
        builder.Property(f => f.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(f => f.Gender).IsRequired();
        builder.Property(f => f.LastName).HasMaxLength(100).IsRequired();
        builder.Property(f => f.Length).IsRequired();
        builder.ToTable(nameof(Individual), Schemas.Individuals);
    }
}