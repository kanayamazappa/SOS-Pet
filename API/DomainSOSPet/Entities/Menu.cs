using System.ComponentModel.DataAnnotations;

namespace DomainSOSPet.Entities
{
    public class Menu
    {
        [Key]
        public int IdMenu { get; set; }
        public int IdMenuPai { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [StringLength(255)]
        public string Url { get; set; }
    }
}
