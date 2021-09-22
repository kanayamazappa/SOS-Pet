using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    public partial class CargaHorarium
    {
        [Key]
        public int IdCargaHoraria { get; set; }
        public int IdFuncionario { get; set; }
        public int DiaSemana { get; set; }
        public bool Manha { get; set; }
        public bool Tarde { get; set; }
        public bool Noite { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey(nameof(IdFuncionario))]
        [InverseProperty(nameof(Funcionario.CargaHoraria))]
        public virtual Funcionario IdFuncionarioNavigation { get; set; }
    }
}
