using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace RepositorySOSPet.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ApplicationDbContext(IConfiguration configuration, DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<AchadoPerdido> AchadoPerdidos { get; set; }
        public virtual DbSet<AdocaoAnimal> AdocaoAnimals { get; set; }
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<CargaHorarium> CargaHoraria { get; set; }
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<ClinicaVeterinarium> ClinicaVeterinaria { get; set; }
        public virtual DbSet<Doacao> Doacaos { get; set; }
        public virtual DbSet<DoacaoAnimal> DoacaoAnimals { get; set; }
        public virtual DbSet<DoarAnimal> DoarAnimals { get; set; }
        public virtual DbSet<Documento> Documentos { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Especie> Especies { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Mural> Murals { get; set; }
        public virtual DbSet<Ong> Ongs { get; set; }
        public virtual DbSet<Pelagem> Pelagems { get; set; }
        public virtual DbSet<Permissao> Permissaos { get; set; }
        public virtual DbSet<PermissaoIndividual> PermissaoIndividuals { get; set; }
        public virtual DbSet<Raca> Racas { get; set; }
        public virtual DbSet<Sexo> Sexos { get; set; }
        public virtual DbSet<Telefone> Telefones { get; set; }
        public virtual DbSet<TipoAdotarAni> TipoAdotarAnis { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public virtual DbSet<TipoEndereco> TipoEnderecos { get; set; }
        public virtual DbSet<TipoTelefone> TipoTelefones { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioFoto> UsuarioFotos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SQLServer"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AchadoPerdido>(entity =>
            {
                entity.Property(e => e.Texto).IsUnicode(false);

                entity.Property(e => e.Tipo).IsUnicode(false);

                entity.Property(e => e.Titulo).IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AchadoPerdidos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AchadoPerdido_Usuario");
            });

            modelBuilder.Entity<AdocaoAnimal>(entity =>
            {
                entity.HasKey(e => e.IdAdocaoAnimal)
                    .HasName("PK_AdotarAnimal");

                entity.HasOne(d => d.IdAnimalNavigation)
                    .WithMany(p => p.AdocaoAnimals)
                    .HasForeignKey(d => d.IdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdotarAnimal_Animal");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.AdocaoAnimals)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("FK_AdocaoAnimal_Funcionario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AdocaoAnimals)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdotarAnimal_Usuario");
            });

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.Cor).IsUnicode(false);

                entity.Property(e => e.Disponivel).HasDefaultValueSql("((1))");

                entity.Property(e => e.Microchip).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.NomeMae).IsUnicode(false);

                entity.Property(e => e.NomePai).IsUnicode(false);

                entity.Property(e => e.Personalidade).IsUnicode(false);

                entity.Property(e => e.Tag).IsUnicode(false);

                entity.HasOne(d => d.IdEspecieNavigation)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.IdEspecie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animal_Especie");

                entity.HasOne(d => d.IdOngNavigation)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.IdOng)
                    .HasConstraintName("FK_Animal_Ong");

                entity.HasOne(d => d.IdPelagemNavigation)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.IdPelagem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animal_Pelagem");

                entity.HasOne(d => d.IdRacaNavigation)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.IdRaca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animal_Raca");

                entity.HasOne(d => d.IdSexoNavigation)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.IdSexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animal_Sexo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animal_Usuario");
            });

            modelBuilder.Entity<CargaHorarium>(entity =>
            {
                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.CargaHoraria)
                    .HasForeignKey(d => d.IdFuncionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CargaHoraria_Funcionario");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.Property(e => e.Nome).IsUnicode(false);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Cidades)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cidade_Estado");
            });

            modelBuilder.Entity<ClinicaVeterinarium>(entity =>
            {
                entity.Property(e => e.Atendimento).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Endereco).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Telefones).IsUnicode(false);
            });

            modelBuilder.Entity<Doacao>(entity =>
            {
                entity.Property(e => e.IdDoacao).ValueGeneratedNever();

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Doacaos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doacao_Usuario");
            });

            modelBuilder.Entity<DoacaoAnimal>(entity =>
            {
                entity.HasOne(d => d.IdAnimalNavigation)
                    .WithMany(p => p.DoacaoAnimals)
                    .HasForeignKey(d => d.IdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoacaoAnimal_Animal");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.DoacaoAnimals)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoacaoAnimal_Usuario");
            });

            modelBuilder.Entity<DoarAnimal>(entity =>
            {
                entity.Property(e => e.IdDoarAnimal).ValueGeneratedNever();
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Documentos)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .HasConstraintName("FK_Documento_TipoDocumento");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Documentos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Documento_Usuario");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.Property(e => e.Bairro).IsUnicode(false);

                entity.Property(e => e.Complemento).IsUnicode(false);

                entity.Property(e => e.Logradouro).IsUnicode(false);

                entity.Property(e => e.Numero).IsUnicode(false);

                entity.HasOne(d => d.IdCidadeNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.IdCidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Endereco_Cidade");

                entity.HasOne(d => d.IdTipoEnderecoNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.IdTipoEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Endereco_TipoEndereco");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Endereco_Usuario");
            });

            modelBuilder.Entity<Especie>(entity =>
            {
                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Sigla).IsUnicode(false);
            });

            modelBuilder.Entity<EstadoCivil>(entity =>
            {
                entity.Property(e => e.Descricao).IsUnicode(false);
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.Property(e => e.IdFuncionario).ValueGeneratedNever();

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionario_Cargo");

                entity.HasOne(d => d.IdOngNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdOng)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionario_Ong");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionario_Usuario");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.IdMenu).ValueGeneratedOnAdd();

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Url).IsUnicode(false);

                entity.HasOne(d => d.IdMenuNavigation)
                    .WithOne(p => p.InverseIdMenuNavigation)
                    .HasPrincipalKey<Menu>(p => p.IdMenuPai)
                    .HasForeignKey<Menu>(d => d.IdMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menu_Menu");
            });

            modelBuilder.Entity<Mural>(entity =>
            {
                entity.Property(e => e.Texto).IsUnicode(false);

                entity.Property(e => e.Titulo).IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Murals)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mural_Usuario");
            });

            modelBuilder.Entity<Ong>(entity =>
            {
                entity.Property(e => e.Bairro).IsUnicode(false);

                entity.Property(e => e.Cep).IsUnicode(false);

                entity.Property(e => e.Cidade).IsUnicode(false);

                entity.Property(e => e.Cnpj).IsUnicode(false);

                entity.Property(e => e.Complemento).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Estado).IsUnicode(false);

                entity.Property(e => e.Ie).IsUnicode(false);

                entity.Property(e => e.Logradouro).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.NomeFantasia).IsUnicode(false);

                entity.Property(e => e.Numero).IsUnicode(false);

                entity.Property(e => e.RedeSocial).IsUnicode(false);

                entity.Property(e => e.Telefone).IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Ongs)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ong_Usuario");
            });

            modelBuilder.Entity<Pelagem>(entity =>
            {
                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<Permissao>(entity =>
            {
                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.Permissaos)
                    .HasForeignKey(d => d.IdMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permissao_Menu");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Permissaos)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permissao_TipoUsuario");
            });

            modelBuilder.Entity<PermissaoIndividual>(entity =>
            {
                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.PermissaoIndividuals)
                    .HasForeignKey(d => d.IdMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PermissaoIndividual_Menu");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.PermissaoIndividuals)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PermissaoIndividual_Usuario");
            });

            modelBuilder.Entity<Raca>(entity =>
            {
                entity.Property(e => e.Nome).IsUnicode(false);

                entity.HasOne(d => d.IdEspecieNavigation)
                    .WithMany(p => p.Racas)
                    .HasForeignKey(d => d.IdEspecie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Raca_Especie");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.Property(e => e.Descricao).IsUnicode(false);
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.HasOne(d => d.IdTipoTelefoneNavigation)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.IdTipoTelefone)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Telefone_TipoTelefone");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Telefone_Usuario");
            });

            modelBuilder.Entity<TipoAdotarAni>(entity =>
            {
                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.Property(e => e.Descricao).IsUnicode(false);
            });

            modelBuilder.Entity<TipoEndereco>(entity =>
            {
                entity.Property(e => e.Descricao).IsUnicode(false);
            });

            modelBuilder.Entity<TipoTelefone>(entity =>
            {
                entity.Property(e => e.Descricao).IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.Property(e => e.Descricao).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);

                entity.HasOne(d => d.IdEstadoCivilNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEstadoCivil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_EstadoCivil");

                entity.HasOne(d => d.IdSexoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdSexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Sexo");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK_Usuario_TipoUsuario1");
            });

            modelBuilder.Entity<UsuarioFoto>(entity =>
            {
                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioFotos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioFoto_Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
