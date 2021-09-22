using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("Permissao")]
    public partial class Permissao
    {
        [Key]
        public int IdPermissao { get; set; }
        public int IdTipoUsuario { get; set; }
        public int IdMenu { get; set; }

        [ForeignKey(nameof(IdMenu))]
        [InverseProperty(nameof(Menu.Permissaos))]
        public virtual Menu IdMenuNavigation { get; set; }
        [ForeignKey(nameof(IdTipoUsuario))]
        [InverseProperty(nameof(TipoUsuario.Permissaos))]
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
