using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("Endereco")]
    public partial class Endereco
    {
        [Key]
        public int IdEndereco { get; set; }
        public int IdTipoEndereco { get; set; }
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(550)]
        public string Logradouro { get; set; }
        [Required]
        [StringLength(20)]
        public string Numero { get; set; }
        [StringLength(500)]
        public string Complemento { get; set; }
        [Required]
        [StringLength(255)]
        public string Bairro { get; set; }
        [Column("CEP")]
        public int Cep { get; set; }
        public int IdCidade { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey(nameof(IdCidade))]
        [InverseProperty(nameof(Cidade.Enderecos))]
        public virtual Cidade IdCidadeNavigation { get; set; }
        [ForeignKey(nameof(IdTipoEndereco))]
        [InverseProperty(nameof(TipoEndereco.Enderecos))]
        public virtual TipoEndereco IdTipoEnderecoNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Enderecos))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
