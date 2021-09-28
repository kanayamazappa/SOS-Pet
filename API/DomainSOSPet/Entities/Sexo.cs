using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainSOSPet.Entities

{
    [Table("Sexo")]
    public class Sexo
    {
        public Sexo()
        {
            Animals = new HashSet<AnimalBASE>();
            Usuarios = new HashSet<Usuario>();
        }

        [Key]
        public int IdSexo { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        [InverseProperty(nameof(AnimalBASE.IdSexoNavigation))]
        public virtual ICollection<AnimalBASE> Animals { get; set; }
        [InverseProperty(nameof(Usuario.IdSexoNavigation))]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
