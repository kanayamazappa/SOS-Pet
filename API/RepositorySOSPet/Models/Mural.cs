using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("Mural")]
    public partial class Mural
    {
        [Key]
        public int IdMural { get; set; }
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(255)]
        public string Titulo { get; set; }
        [Required]
        [StringLength(1000)]
        public string Texto { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Murals))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
