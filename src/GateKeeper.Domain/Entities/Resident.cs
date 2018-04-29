using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GateKeeper.Domain.Entities
{
    public class Resident : SoftDeleteableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Block { get; set; }

        public string Apartment { get; set; }

        public string Phone { get; set; }

        public string Cpf { get; set; }

    }
}