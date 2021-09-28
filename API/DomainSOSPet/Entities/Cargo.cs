using System.ComponentModel.DataAnnotations;

namespace DomainSOSPet.Entities
{
    public class Cargo
    {
        public int IdCargo { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

    }
}
