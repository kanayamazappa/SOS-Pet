using System;

namespace DomainSOSPet.Entities
{
    public class Funcionario
    {
        public int IdFuncionario { get; set; }
        public int IdOng { get; set; }
        public int IdUsuario { get; set; }
        public int IdCargo { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime? DataDemissao { get; set; }
        public bool Ativo { get; set; }
        public decimal? Salario { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
