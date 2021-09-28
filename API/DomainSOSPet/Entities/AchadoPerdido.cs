using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainSOSPet.Entities
{
    public class AchadoPerdido : AchadoPerdidoBASE
    {
        public int IdAchadoPerdido { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
