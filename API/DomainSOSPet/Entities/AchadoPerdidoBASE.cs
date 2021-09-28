using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities
{
    public class AchadoPerdidoBASE
    {
        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }
        [Required]
        [StringLength(255)]
        public string Titulo { get; set; }
        [StringLength(1000)]
        public string Texto { get; set; }
        public byte[] Imagem { get; set; }
    }
}
