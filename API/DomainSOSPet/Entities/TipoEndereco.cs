using System.ComponentModel.DataAnnotations;

namespace DomainSOSPet.Entities
{
    public class TipoEndereco
    {
        public int IdTipoEndereco { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }
    }
}