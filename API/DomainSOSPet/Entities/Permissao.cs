using System.ComponentModel.DataAnnotations;

namespace DomainSOSPet.Entities
{
    public class Permissao
    {
        [Key]
        public int IdPermissao { get; set; }
        public int IdTipoUsuario { get; set; }
        public int IdMenu { get; set; }
    }
}
