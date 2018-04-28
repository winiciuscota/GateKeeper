using GateKeeper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GateKeeper.Data.Configuration
{
    public class ApartmentConfiguration: IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasQueryFilter(p => !p.Deleted);
        }
    }
}