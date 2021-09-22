using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("Sexo")]
    public partial class Sexo
    {
        public Sexo()
        {
            Animals = new HashSet<Animal>();
            Usuarios = new HashSet<Usuario>();
        }

        [Key]
        public int IdSexo { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        [InverseProperty(nameof(Animal.IdSexoNavigation))]
        public virtual ICollection<Animal> Animals { get; set; }
        [InverseProperty(nameof(Usuario.IdSexoNavigation))]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
