using GateKeeper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GateKeeper.Data.Configuration
{
    public class ResidentApartmentConfiguration : IEntityTypeConfiguration<ResidentApartment>
    {
        public void Configure(EntityTypeBuilder<ResidentApartment> builder)
        {
            builder.HasKey(x => new { x.ResidentId, x.ApartmentId });

            builder.HasQueryFilter(p => !p.Deleted);

        }
    }
}