using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities
{
    [Table("TipoEndereco")]
    public class TipoEndereco
    {
        public TipoEndereco()
        {
            Enderecos = new HashSet<Endereco>();
        }

        [Key]
        public int IdTipoEndereco { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        [InverseProperty(nameof(Endereco.IdTipoEnderecoNavigation))]
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
