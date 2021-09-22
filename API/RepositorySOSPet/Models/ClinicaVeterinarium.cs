using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    public partial class ClinicaVeterinarium
    {
        [Key]
        public int IdClinicaVeterinaria { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        [StringLength(255)]
        public string Telefones { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(500)]
        public string Endereco { get; set; }
        [Required]
        [StringLength(500)]
        public string Atendimento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }
    }
}
