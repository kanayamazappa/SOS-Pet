using System;

namespace DomainSOSPet.Entities
{
    public class AdocaoAnimalPUT : AdocaoAnimalBASE
    {
        public int IdAdocaoAnimal { get; set; }
        public bool Aprovado { get; set; }
        public DateTime? DataAprovacao { get; set; }
    }
}