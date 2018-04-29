using System.ComponentModel.DataAnnotations;

namespace GateKeeper.Api.ViewModels
{
    public class ResidentViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Block { get; set; }

        [Required]
        public string Apartment { get; set; }
    }
}