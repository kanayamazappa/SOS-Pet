using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("Animal")]
    public partial class Animal
    {
        public Animal()
        {
            AdocaoAnimals = new HashSet<AdocaoAnimal>();
            DoacaoAnimals = new HashSet<DoacaoAnimal>();
        }

        [Key]
        public int IdAnimal { get; set; }
        public int? IdOng { get; set; }
        public int IdEspecie { get; set; }
        public int IdUsuario { get; set; }
        public int IdSexo { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [StringLength(255)]
        public string Microchip { get; set; }
        [StringLength(255)]
        public string Tag { get; set; }
        [Column(TypeName = "date")]
        public DateTime DataNascimento { get; set; }
        public int IdRaca { get; set; }
        public bool Castrado { get; set; }
        [Required]
        [StringLength(50)]
        public string Cor { get; set; }
        public int IdPelagem { get; set; }
        public byte? Peso { get; set; }
        public byte? Altura { get; set; }
        [StringLength(255)]
        public string Personalidade { get; set; }
        public bool Vacinacao { get; set; }
        [StringLength(255)]
        public string NomePai { get; set; }
        [StringLength(255)]
        public string NomeMae { get; set; }
        public bool? Disponivel { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey(nameof(IdEspecie))]
        [InverseProperty(nameof(Especie.Animals))]
        public virtual Especie IdEspecieNavigation { get; set; }
        [ForeignKey(nameof(IdOng))]
        [InverseProperty(nameof(Ong.Animals))]
        public virtual Ong IdOngNavigation { get; set; }
        [ForeignKey(nameof(IdPelagem))]
        [InverseProperty(nameof(Pelagem.Animals))]
        public virtual Pelagem IdPelagemNavigation { get; set; }
        [ForeignKey(nameof(IdRaca))]
        [InverseProperty(nameof(Raca.Animals))]
        public virtual Raca IdRacaNavigation { get; set; }
        [ForeignKey(nameof(IdSexo))]
        [InverseProperty(nameof(Sexo.Animals))]
        public virtual Sexo IdSexoNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Animals))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
        [InverseProperty(nameof(AdocaoAnimal.IdAnimalNavigation))]
        public virtual ICollection<AdocaoAnimal> AdocaoAnimals { get; set; }
        [InverseProperty(nameof(DoacaoAnimal.IdAnimalNavigation))]
        public virtual ICollection<DoacaoAnimal> DoacaoAnimals { get; set; }
    }
}
