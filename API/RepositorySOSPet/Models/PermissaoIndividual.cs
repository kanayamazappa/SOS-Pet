using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("PermissaoIndividual")]
    public partial class PermissaoIndividual
    {
        [Key]
        public int IdPermissaoIndividual { get; set; }
        public int IdUsuario { get; set; }
        public int IdMenu { get; set; }

        [ForeignKey(nameof(IdMenu))]
        [InverseProperty(nameof(Menu.PermissaoIndividuals))]
        public virtual Menu IdMenuNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.PermissaoIndividuals))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
