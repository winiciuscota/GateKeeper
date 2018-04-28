using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GateKeeper.Domain.Entities
{
    public class CondominiumBlock : SoftDeleteableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Condominium Condominium { get; set; }

        public int CondominiumId { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }

        public CondominiumBlock() => Apartments = new Collection<Apartment>();
    }
}