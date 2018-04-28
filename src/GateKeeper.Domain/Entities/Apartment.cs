using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GateKeeper.Domain.Entities
{
    public class Apartment : SoftDeleteableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CondominiumBlockId { get; set; }

        public CondominiumBlock CondominiumBlock { get; set; }

        public ICollection<ResidentApartment> ResidentApartments { get; set; }
        public Apartment() => ResidentApartments = new Collection<ResidentApartment>();

    }
}