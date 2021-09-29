using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities

{
    public class Sexo
    {
        public int IdSexo { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }
    }
}
