using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mmu.CleanBlazor.Application.Infrastructure.Outbox.Models;
using Mmu.CleanBlazor.DataAccess.Areas.Individuals.TypeConfigurations;
using Mmu.CleanBlazor.DataAccess.Areas.Individuals.TypeConfigurations.Base;

namespace Mmu.CleanBlazor.DataAccess.Infrastructure.Outboxes.TypeConfigurations
{
    internal class OutboxMessageConfig : EntityConfigBase<OutboxMessage>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<OutboxMessage> builder)
        {
            builder.Property(f => f.EventId).IsRequired();
            builder.Property(f => f.Error).HasMaxLength(255);
            builder.Property(f => f.EventOccurredOn).IsRequired();
            builder.Property(f => f.Payload).IsRequired();
            builder.Property(f => f.EventType).IsRequired().HasMaxLength(100);
            builder.ToTable(nameof(OutboxMessage), Schemas.Infrastructure);
        }
    }
}