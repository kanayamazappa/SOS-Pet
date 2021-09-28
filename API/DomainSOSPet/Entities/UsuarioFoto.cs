using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities
{
    [Table("UsuarioFoto")]
    public class UsuarioFoto
    {
        [Key]
        public int IdUsuarioFoto { get; set; }
        public int IdUsuario { get; set; }
        [Required]
        [Column(TypeName = "image")]
        public byte[] Foto { get; set; }
        public bool Principal { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.UsuarioFotos))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
