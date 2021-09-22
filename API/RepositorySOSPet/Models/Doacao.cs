using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("Doacao")]
    public partial class Doacao
    {
        [Key]
        public int IdDoacao { get; set; }
        public int IdUsuario { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }
        public int DataCadastro { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Doacaos))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
