namespace GateKeeper.Domain.Entities
{
    public class Address
    {
        public string PostCode { get; set; }
        public string AddressNumber { get; set; }
        public string Complement { get; set; }
        public string StreetAddress { get; set; }
        // Bairro
        public string Neighborhood { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}