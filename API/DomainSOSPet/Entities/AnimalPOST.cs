using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities
{
    public class AnimalPOST : AnimalBASE
    {
        public int IdEspecie { get; set; }
        public int IdUsuario { get; set; }
        public int IdSexo { get; set; }
        public int IdRaca { get; set; }
        public int IdPelagem { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
