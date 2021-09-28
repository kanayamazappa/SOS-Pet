using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities
{
    public class Doacao
    {
        [Key]
        public int IdDoacao { get; set; }
        public int IdUsuario { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }
        public int DataCadastro { get; set; }
    }
}
