using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities
{
    public class Animal : AnimalBASE
    {
        public int IdAnimal { get; set; }
        public Ong Ong { get; set; }
        public Especie Especie { get; set; }
        public Usuario Usuario { get; set; }
        public Sexo Sexo { get; set; }
        public Raca Raca { get; set; }
        public Pelagem Pelagem { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
