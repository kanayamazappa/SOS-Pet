using System;

namespace DomainSOSPet.Entities
{
    public class AdocaoAnimal
    {
        public int IdAdocaoAnimal { get; set; }
        public Usuario Usuario { get; set; }
        public Animal Animal { get; set; }
        public Funcionario Funcionario { get; set; }
        public bool Aprovado { get; set; }
        public DateTime? DataAprovacao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}