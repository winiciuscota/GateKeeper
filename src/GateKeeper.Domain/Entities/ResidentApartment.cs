
namespace GateKeeper.Domain.Entities
{
    public class ResidentApartment : SoftDeleteableEntity
    {
        public Resident Resident { get; set; }
        public int ResidentId { get; set; }
        public Apartment Apartment { get; set; }
        public int ApartmentId { get; set; }      
    }
}