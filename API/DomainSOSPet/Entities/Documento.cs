using System;

namespace DomainSOSPet.Entities
{
    public class Documento
    {
        public int IdDocumento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public Usuario Usuario { get; set; }
        public int? Numero { get; set; }
        public DateTime? DataCadastro { get; set; }
    }
}
