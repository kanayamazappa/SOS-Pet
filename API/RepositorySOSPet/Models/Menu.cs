using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("Menu")]
    [Index(nameof(IdMenuPai), Name = "IX_Menu", IsUnique = true)]
    public partial class Menu
    {
        public Menu()
        {
            PermissaoIndividuals = new HashSet<PermissaoIndividual>();
            Permissaos = new HashSet<Permissao>();
        }

        [Key]
        public int IdMenu { get; set; }
        public int IdMenuPai { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [StringLength(255)]
        public string Url { get; set; }

        public virtual Menu IdMenuNavigation { get; set; }
        public virtual Menu InverseIdMenuNavigation { get; set; }
        [InverseProperty(nameof(PermissaoIndividual.IdMenuNavigation))]
        public virtual ICollection<PermissaoIndividual> PermissaoIndividuals { get; set; }
        [InverseProperty(nameof(Permissao.IdMenuNavigation))]
        public virtual ICollection<Permissao> Permissaos { get; set; }
    }
}
