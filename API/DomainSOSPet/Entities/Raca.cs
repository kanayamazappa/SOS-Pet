using System.ComponentModel.DataAnnotations;

namespace DomainSOSPet.Entities
{
    public class Raca
    {
        [Key]
        public int IdRaca { get; set; }
        public int IdEspecie { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}
