using System.ComponentModel.DataAnnotations;

namespace DomainSOSPet.Entities
{
    public class Estado
    {
        public int IdEstado { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [StringLength(2)]
        public string Sigla { get; set; }
    }
}
