using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainSOSPet.Entities
{
    public class AchadoPerdidoPOST : AchadoPerdidoBASE
    {
        public int IdUsuario { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
