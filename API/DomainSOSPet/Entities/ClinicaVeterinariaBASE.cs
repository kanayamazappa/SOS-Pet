using System.ComponentModel.DataAnnotations;

namespace DomainSOSPet.Entities
{
    public class ClinicaVeterinariaBASE
    {
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        [StringLength(255)]
        public string Telefones { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(500)]
        public string Endereco { get; set; }
        [Required]
        [StringLength(500)]
        public string Atendimento { get; set; }
    }
}
