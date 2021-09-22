using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("DoarAnimal")]
    public partial class DoarAnimal
    {
        [Key]
        public int IdDoarAnimal { get; set; }
    }
}
