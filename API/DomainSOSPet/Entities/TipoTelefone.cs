using System.ComponentModel.DataAnnotations;

namespace DomainSOSPet.Entities
{
    public class TipoTelefone
    {
        public int IdTipoTelefone { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }
    }
}
