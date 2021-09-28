using System.ComponentModel.DataAnnotations;

namespace DomainSOSPet.Entities
{
    public class Pelagem
    {
        [Key]
        public int IdPelagem { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}
