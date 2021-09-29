using System.ComponentModel.DataAnnotations;

namespace DomainSOSPet.Entities
{
    public class TipoUsuario
    {
        [Required]
        public int IdTipoUsuario { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }
    }
}