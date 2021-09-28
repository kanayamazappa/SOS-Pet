using System;
using System.ComponentModel.DataAnnotations;

namespace DomainSOSPet.Entities
{
    public class AnimalBASE
    {
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [StringLength(255)]
        public string Microchip { get; set; }
        [StringLength(255)]
        public string Tag { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Castrado { get; set; }
        [Required]
        [StringLength(50)]
        public string Cor { get; set; }
        public byte? Peso { get; set; }
        public byte? Altura { get; set; }
        [StringLength(255)]
        public string Personalidade { get; set; }
        public bool Vacinacao { get; set; }
        [StringLength(255)]
        public string NomePai { get; set; }
        [StringLength(255)]
        public string NomeMae { get; set; }
    }
}
