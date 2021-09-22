using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("AchadoPerdido")]
    public partial class AchadoPerdido
    {
        [Key]
        public int IdAchadoPerdido { get; set; }
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }
        [Required]
        [StringLength(255)]
        public string Titulo { get; set; }
        [StringLength(1000)]
        public string Texto { get; set; }
        [Column(TypeName = "image")]
        public byte[] Imagem { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.AchadoPerdidos))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
