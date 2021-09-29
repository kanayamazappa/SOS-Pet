using System;
using System.Collections.Generic;

namespace DomainSOSPet.Entities
{
    public class Usuario : UsuarioBASE
    {
        public int IdUsuario { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public Sexo Sexo { get; set; }
        public UsuarioFoto Foto { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}