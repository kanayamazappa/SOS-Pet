using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("TipoAdotarAni")]
    public partial class TipoAdotarAni
    {
        [Key]
        public int IdTipoAdotarAnimal { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}
