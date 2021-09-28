using System.ComponentModel.DataAnnotations;

namespace DomainSOSPet.Entities
{
    public class Especie
    {
        [Key]
        public int IdEspecie { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}
