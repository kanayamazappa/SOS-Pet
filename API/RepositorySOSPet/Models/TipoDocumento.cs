using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("TipoDocumento")]
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Documentos = new HashSet<Documento>();
        }

        [Key]
        public int IdTipoDocumento { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        [InverseProperty(nameof(Documento.IdTipoDocumentoNavigation))]
        public virtual ICollection<Documento> Documentos { get; set; }
    }
}
