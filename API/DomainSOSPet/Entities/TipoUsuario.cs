using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities
{
    [Table("TipoUsuario")]
    public class TipoUsuario
    {
        public TipoUsuario()
        {
            Permissaos = new HashSet<Permissao>();
            Usuarios = new HashSet<Usuario>();
        }

        [Key]
        public int IdTipoUsuario { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        [InverseProperty(nameof(Permissao.IdTipoUsuarioNavigation))]
        public virtual ICollection<Permissao> Permissaos { get; set; }
        [InverseProperty(nameof(Usuario.IdTipoUsuarioNavigation))]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
