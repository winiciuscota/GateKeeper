using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GateKeeper.Domain.Entities
{
    public class Condominium : SoftDeleteableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public Address Address {get;set;}

        public virtual ICollection<CondominiumBlock> Blocks { get; set; }

        public Condominium() => Blocks = new Collection<CondominiumBlock>();
    }
}