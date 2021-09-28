using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities
{
    public class Documento
    {
        [Key]
        public int IdDocumento { get; set; }
        public int? IdTipoDocumento { get; set; }
        public int? IdUsuario { get; set; }
        public int? Numero { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCadastro { get; set; }
    }
}
