using System;
using System.ComponentModel.DataAnnotations;

namespace DomainSOSPet.Entities
{
    public class Mural
    {
        public int IdMural { get; set; }
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(255)]
        public string Titulo { get; set; }
        [Required]
        [StringLength(1000)]
        public string Texto { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
