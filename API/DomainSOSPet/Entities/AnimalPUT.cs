using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities
{
    public class AnimalPUT : AnimalBASE
    {
        public int IdAnimal { get; set; }
        public int? IdOng { get; set; }
        public int IdEspecie { get; set; }
        public int IdUsuario { get; set; }
        public int IdSexo { get; set; }
        public int IdRaca { get; set; }
        public int IdPelagem { get; set; }

    }
}
