using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("Ong")]
    public partial class Ong
    {
        public Ong()
        {
            Animals = new HashSet<Animal>();
            Funcionarios = new HashSet<Funcionario>();
        }

        [Key]
        public int IdOng { get; set; }
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [StringLength(255)]
        public string NomeFantasia { get; set; }
        [Column("CNPJ")]
        [StringLength(20)]
        public string Cnpj { get; set; }
        [Column("IE")]
        [StringLength(20)]
        public string Ie { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Telefone { get; set; }
        [StringLength(500)]
        public string RedeSocial { get; set; }
        [StringLength(255)]
        public string Logradouro { get; set; }
        [StringLength(20)]
        public string Numero { get; set; }
        [StringLength(255)]
        public string Complemento { get; set; }
        [StringLength(255)]
        public string Bairro { get; set; }
        [StringLength(150)]
        public string Cidade { get; set; }
        [StringLength(2)]
        public string Estado { get; set; }
        [Column("CEP")]
        [StringLength(20)]
        public string Cep { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Ongs))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
        [InverseProperty(nameof(Animal.IdOngNavigation))]
        public virtual ICollection<Animal> Animals { get; set; }
        [InverseProperty(nameof(Funcionario.IdOngNavigation))]
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
