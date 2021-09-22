using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("DoacaoAnimal")]
    public partial class DoacaoAnimal
    {
        [Key]
        public int IdDoacaoAnimal { get; set; }
        public int IdUsuario { get; set; }
        public int IdAnimal { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey(nameof(IdAnimal))]
        [InverseProperty(nameof(Animal.DoacaoAnimals))]
        public virtual Animal IdAnimalNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.DoacaoAnimals))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
