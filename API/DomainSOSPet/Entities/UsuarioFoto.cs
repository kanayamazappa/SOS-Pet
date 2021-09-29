using System;
using System.ComponentModel.DataAnnotations;

namespace DomainSOSPet.Entities
{
    public class UsuarioFoto
    {
        public int IdUsuario { get; set; }
        [Required]
        public byte[] Foto { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}