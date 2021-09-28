using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities
{
    public class Funcionario
    {
        [Key]
        public int IdFuncionario { get; set; }
        public int IdOng { get; set; }
        public int IdUsuario { get; set; }
        public int IdCargo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataAdmissao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataDemissao { get; set; }
        public bool Ativo { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Salario { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }
    }
}
