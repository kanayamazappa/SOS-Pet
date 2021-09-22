﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("EstadoCivil")]
    public partial class EstadoCivil
    {
        public EstadoCivil()
        {
            Usuarios = new HashSet<Usuario>();
        }

        [Key]
        public int IdEstadoCivil { get; set; }
        [StringLength(50)]
        public string Descricao { get; set; }

        [InverseProperty(nameof(Usuario.IdEstadoCivilNavigation))]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
