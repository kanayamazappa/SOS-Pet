using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities

{
    [Table("Telefone")]
    public class Telefone
    {
        [Key]
        public int IdTelefone { get; set; }
        public int IdTipoTelefone { get; set; }
        public int IdUsuario { get; set; }
        [Column("DDI")]
        public byte Ddi { get; set; }
        [Column("DDD")]
        public byte Ddd { get; set; }
        public short Numero { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey(nameof(IdTipoTelefone))]
        [InverseProperty(nameof(TipoTelefone.Telefones))]
        public virtual TipoTelefone IdTipoTelefoneNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Telefones))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
