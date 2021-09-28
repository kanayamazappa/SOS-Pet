using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities
{
    public class EstadoCivil
    {
        [Key]
        public int IdEstadoCivil { get; set; }
        [StringLength(50)]
        public string Descricao { get; set; }
    }
}
