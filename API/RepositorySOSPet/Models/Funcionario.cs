using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("Funcionario")]
    public partial class Funcionario
    {
        public Funcionario()
        {
            AdocaoAnimals = new HashSet<AdocaoAnimal>();
            CargaHoraria = new HashSet<CargaHorarium>();
        }

        [Key]
        public int IdFuncionario { get; set; }
        public int IdOng { get; set; }
        public int IdUsuario { get; set; }
        public int IdCargo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataAdmissao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataDemissao { get; set; }
        public bool Ativo { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Salario { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey(nameof(IdCargo))]
        [InverseProperty(nameof(Cargo.Funcionarios))]
        public virtual Cargo IdCargoNavigation { get; set; }
        [ForeignKey(nameof(IdOng))]
        [InverseProperty(nameof(Ong.Funcionarios))]
        public virtual Ong IdOngNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Funcionarios))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
        [InverseProperty(nameof(AdocaoAnimal.IdFuncionarioNavigation))]
        public virtual ICollection<AdocaoAnimal> AdocaoAnimals { get; set; }
        [InverseProperty(nameof(CargaHorarium.IdFuncionarioNavigation))]
        public virtual ICollection<CargaHorarium> CargaHoraria { get; set; }
    }
}
