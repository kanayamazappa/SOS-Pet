using System.ComponentModel.DataAnnotations;

namespace DomainSOSPet.Entities
{
    public class PermissaoIndividual
    {
        public int IdPermissaoIndividual { get; set; }
        public int IdUsuario { get; set; }
        public int IdMenu { get; set; }
    }
}