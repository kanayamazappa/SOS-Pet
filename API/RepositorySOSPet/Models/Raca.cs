using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("Raca")]
    public partial class Raca
    {
        public Raca()
        {
            Animals = new HashSet<Animal>();
        }

        [Key]
        public int IdRaca { get; set; }
        public int IdEspecie { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [ForeignKey(nameof(IdEspecie))]
        [InverseProperty(nameof(Especie.Racas))]
        public virtual Especie IdEspecieNavigation { get; set; }
        [InverseProperty(nameof(Animal.IdRacaNavigation))]
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
