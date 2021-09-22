using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("Cidade")]
    public partial class Cidade
    {
        public Cidade()
        {
            Enderecos = new HashSet<Endereco>();
        }

        [Key]
        public int IdCidade { get; set; }
        public int IdEstado { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [ForeignKey(nameof(IdEstado))]
        [InverseProperty(nameof(Estado.Cidades))]
        public virtual Estado IdEstadoNavigation { get; set; }
        [InverseProperty(nameof(Endereco.IdCidadeNavigation))]
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
