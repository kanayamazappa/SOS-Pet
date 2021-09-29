using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities

{
    public class Telefone
    {
        public int IdTelefone { get; set; }
        public int IdTipoTelefone { get; set; }
        public int IdUsuario { get; set; }
        public byte Ddi { get; set; }
        public byte Ddd { get; set; }
        public short Numero { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }
    }
}
