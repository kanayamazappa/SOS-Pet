using System;

namespace DomainSOSPet.Entities
{
    public class UsuarioBASE
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
