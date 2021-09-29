using System;
using System.ComponentModel.DataAnnotations;

namespace DomainSOSPet.Entities
{
    public class Ong
    {
        public int IdOng { get; set; }
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [StringLength(255)]
        public string NomeFantasia { get; set; }
        [StringLength(20)]
        public string Cnpj { get; set; }
        [StringLength(20)]
        public string Ie { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Telefone { get; set; }
        [StringLength(500)]
        public string RedeSocial { get; set; }
        [StringLength(255)]
        public string Logradouro { get; set; }
        [StringLength(20)]
        public string Numero { get; set; }
        [StringLength(255)]
        public string Complemento { get; set; }
        [StringLength(255)]
        public string Bairro { get; set; }
        [StringLength(150)]
        public string Cidade { get; set; }
        [StringLength(2)]
        public string Estado { get; set; }
        [StringLength(20)]
        public string Cep { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
