using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("TipoTelefone")]
    public partial class TipoTelefone
    {
        public TipoTelefone()
        {
            Telefones = new HashSet<Telefone>();
        }

        [Key]
        public int IdTipoTelefone { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        [InverseProperty(nameof(Telefone.IdTipoTelefoneNavigation))]
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
