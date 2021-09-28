using System;

namespace DomainSOSPet.Entities
{
    public class CargaHorariaPOST : CargaHorariaBASE
    {
        public int IdFuncionario { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
