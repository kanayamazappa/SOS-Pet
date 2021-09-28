using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities
{
    public class Cidade
    {
        public int IdCidade { get; set; }
        public int IdEstado { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
    }
}
