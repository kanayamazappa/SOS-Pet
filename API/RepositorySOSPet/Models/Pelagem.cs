using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("Pelagem")]
    public partial class Pelagem
    {
        public Pelagem()
        {
            Animals = new HashSet<Animal>();
        }

        [Key]
        public int IdPelagem { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [InverseProperty(nameof(Animal.IdPelagemNavigation))]
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
