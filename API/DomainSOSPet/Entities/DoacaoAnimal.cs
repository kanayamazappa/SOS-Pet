using System;

namespace DomainSOSPet.Entities
{
    public class DoacaoAnimal
    {
        public int IdDoacaoAnimal { get; set; }
        public Usuario Usuario { get; set; }
        public Animal Animal { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
