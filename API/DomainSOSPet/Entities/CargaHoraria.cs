using System;

namespace DomainSOSPet.Entities
{
    public class CargaHoraria : CargaHorariaBASE
    {
        public int IdCargaHoraria { get; set; }
        public Funcionario Funcionario { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
