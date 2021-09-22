using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("AdocaoAnimal")]
    public partial class AdocaoAnimal
    {
        [Key]
        public int IdAdocaoAnimal { get; set; }
        public int IdUsuario { get; set; }
        public int IdAnimal { get; set; }
        public int? IdFuncionario { get; set; }
        public bool Aprovado { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAprovacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey(nameof(IdAnimal))]
        [InverseProperty(nameof(Animal.AdocaoAnimals))]
        public virtual Animal IdAnimalNavigation { get; set; }
        [ForeignKey(nameof(IdFuncionario))]
        [InverseProperty(nameof(Funcionario.AdocaoAnimals))]
        public virtual Funcionario IdFuncionarioNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.AdocaoAnimals))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
