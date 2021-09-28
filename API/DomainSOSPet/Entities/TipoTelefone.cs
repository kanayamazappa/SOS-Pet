using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities
{
    [Table("TipoTelefone")]
    public class TipoTelefone
    {
        public TipoTelefone()
        {
            Telefones = new HashSet<Telefone>();
        }

        [Key]
        public int IdTipoTelefone { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        [InverseProperty(nameof(Telefone.IdTipoTelefoneNavigation))]
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
