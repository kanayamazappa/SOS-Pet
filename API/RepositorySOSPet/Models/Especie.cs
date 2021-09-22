using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("Especie")]
    public partial class Especie
    {
        public Especie()
        {
            Animals = new HashSet<Animal>();
            Racas = new HashSet<Raca>();
        }

        [Key]
        public int IdEspecie { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [InverseProperty(nameof(Animal.IdEspecieNavigation))]
        public virtual ICollection<Animal> Animals { get; set; }
        [InverseProperty(nameof(Raca.IdEspecieNavigation))]
        public virtual ICollection<Raca> Racas { get; set; }
    }
}
