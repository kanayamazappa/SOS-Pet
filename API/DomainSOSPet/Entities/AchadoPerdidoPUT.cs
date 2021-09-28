using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities
{
    public class AchadoPerdidoPUT : AchadoPerdidoBASE
    {
        public int IdUsuario { get; set; }
        public int IdAchadoPerdido { get; set; }
    }
}
