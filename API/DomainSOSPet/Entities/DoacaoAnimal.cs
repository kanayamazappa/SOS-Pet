using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities
{
    public class DoacaoAnimal
    {
        [Key]
        public int IdDoacaoAnimal { get; set; }
        public int IdUsuario { get; set; }
        public int IdAnimal { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }
    }
}
