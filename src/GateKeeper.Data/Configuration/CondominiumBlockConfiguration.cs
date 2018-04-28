using GateKeeper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GateKeeper.Data.Configuration
{
    public class CondominiumBlockConfiguration: IEntityTypeConfiguration<CondominiumBlock>
    {
        public void Configure(EntityTypeBuilder<CondominiumBlock> builder)
        {
            builder.HasQueryFilter(p => !p.Deleted);
        }
    }
}