using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("Cargo")]
    public partial class Cargo
    {
        public Cargo()
        {
            Funcionarios = new HashSet<Funcionario>();
        }

        [Key]
        public int IdCargo { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [InverseProperty(nameof(Funcionario.IdCargoNavigation))]
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
