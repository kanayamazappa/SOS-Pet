using System.ComponentModel.DataAnnotations;

namespace DomainSOSPet.Entities
{
    public class EstadoCivil
    {
        public int IdEstadoCivil { get; set; }
        [StringLength(50)]
        public string Descricao { get; set; }
    }
}
