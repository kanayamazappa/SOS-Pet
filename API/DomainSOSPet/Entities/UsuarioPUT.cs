using System;

namespace DomainSOSPet.Entities
{
    public class UsuarioPUT : UsuarioBASE
    {
        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public int IdEstadoCivil { get; set; }
        public int IdSexo { get; set; }
    }
}
