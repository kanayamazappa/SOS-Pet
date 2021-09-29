using System;
using System.ComponentModel.DataAnnotations;

namespace DomainSOSPet.Entities
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public int IdTipoEndereco { get; set; }
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(550)]
        public string Logradouro { get; set; }
        [Required]
        [StringLength(20)]
        public string Numero { get; set; }
        [StringLength(500)]
        public string Complemento { get; set; }
        [Required]
        [StringLength(255)]
        public string Bairro { get; set; }
        public int Cep { get; set; }
        public int IdCidade { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
