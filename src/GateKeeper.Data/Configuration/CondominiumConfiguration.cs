using GateKeeper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GateKeeper.Data.Configuration
{
    public class CondominiumConfiguration : IEntityTypeConfiguration<Condominium>
    {
        public void Configure(EntityTypeBuilder<Condominium> builder)
        {
            builder.HasQueryFilter(p => !p.Deleted);

            builder.OwnsOne(p => p.Address);
        }
    }
}