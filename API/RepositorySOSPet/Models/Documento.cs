using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("Documento")]
    public partial class Documento
    {
        [Key]
        public int IdDocumento { get; set; }
        public int? IdTipoDocumento { get; set; }
        public int? IdUsuario { get; set; }
        public int? Numero { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCadastro { get; set; }

        [ForeignKey(nameof(IdTipoDocumento))]
        [InverseProperty(nameof(TipoDocumento.Documentos))]
        public virtual TipoDocumento IdTipoDocumentoNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Documentos))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
