using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepositorySOSPet.Models
{
    [Table("Usuario")]
    public partial class Usuario
    {
        public Usuario()
        {
            AchadoPerdidos = new HashSet<AchadoPerdido>();
            AdocaoAnimals = new HashSet<AdocaoAnimal>();
            Animals = new HashSet<Animal>();
            DoacaoAnimals = new HashSet<DoacaoAnimal>();
            Doacaos = new HashSet<Doacao>();
            Documentos = new HashSet<Documento>();
            Enderecos = new HashSet<Endereco>();
            Funcionarios = new HashSet<Funcionario>();
            Murals = new HashSet<Mural>();
            Ongs = new HashSet<Ong>();
            PermissaoIndividuals = new HashSet<PermissaoIndividual>();
            Telefones = new HashSet<Telefone>();
            UsuarioFotos = new HashSet<UsuarioFoto>();
        }

        [Key]
        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string Senha { get; set; }
        [Column(TypeName = "date")]
        public DateTime DataNascimento { get; set; }
        public int IdEstadoCivil { get; set; }
        public int IdSexo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey(nameof(IdEstadoCivil))]
        [InverseProperty(nameof(EstadoCivil.Usuarios))]
        public virtual EstadoCivil IdEstadoCivilNavigation { get; set; }
        [ForeignKey(nameof(IdSexo))]
        [InverseProperty(nameof(Sexo.Usuarios))]
        public virtual Sexo IdSexoNavigation { get; set; }
        [ForeignKey(nameof(IdTipoUsuario))]
        [InverseProperty(nameof(TipoUsuario.Usuarios))]
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        [InverseProperty(nameof(AchadoPerdido.IdUsuarioNavigation))]
        public virtual ICollection<AchadoPerdido> AchadoPerdidos { get; set; }
        [InverseProperty(nameof(AdocaoAnimal.IdUsuarioNavigation))]
        public virtual ICollection<AdocaoAnimal> AdocaoAnimals { get; set; }
        [InverseProperty(nameof(Animal.IdUsuarioNavigation))]
        public virtual ICollection<Animal> Animals { get; set; }
        [InverseProperty(nameof(DoacaoAnimal.IdUsuarioNavigation))]
        public virtual ICollection<DoacaoAnimal> DoacaoAnimals { get; set; }
        [InverseProperty(nameof(Doacao.IdUsuarioNavigation))]
        public virtual ICollection<Doacao> Doacaos { get; set; }
        [InverseProperty(nameof(Documento.IdUsuarioNavigation))]
        public virtual ICollection<Documento> Documentos { get; set; }
        [InverseProperty(nameof(Endereco.IdUsuarioNavigation))]
        public virtual ICollection<Endereco> Enderecos { get; set; }
        [InverseProperty(nameof(Funcionario.IdUsuarioNavigation))]
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
        [InverseProperty(nameof(Mural.IdUsuarioNavigation))]
        public virtual ICollection<Mural> Murals { get; set; }
        [InverseProperty(nameof(Ong.IdUsuarioNavigation))]
        public virtual ICollection<Ong> Ongs { get; set; }
        [InverseProperty(nameof(PermissaoIndividual.IdUsuarioNavigation))]
        public virtual ICollection<PermissaoIndividual> PermissaoIndividuals { get; set; }
        [InverseProperty(nameof(Telefone.IdUsuarioNavigation))]
        public virtual ICollection<Telefone> Telefones { get; set; }
        [InverseProperty(nameof(UsuarioFoto.IdUsuarioNavigation))]
        public virtual ICollection<UsuarioFoto> UsuarioFotos { get; set; }
    }
}
