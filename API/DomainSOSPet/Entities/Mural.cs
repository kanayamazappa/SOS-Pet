using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities
{
    public class Mural
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
    }
}
