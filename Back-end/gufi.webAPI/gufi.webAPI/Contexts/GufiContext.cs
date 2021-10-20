using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using gufi.webAPI.Domains;

#nullable disable

namespace gufi.webAPI.Contexts
{
    public partial class GUFIContext : DbContext
    {
        public GUFIContext()
        {
        }

        public GUFIContext(DbContextOptions<GUFIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<ImagemPerfil> ImagemPerfils { get; set; }
        public virtual DbSet<Instituicao> Instituicaos { get; set; }
        public virtual DbSet<Presenca> Presencas { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<TipoEvento> TipoEventos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:senai-gufi.database.windows.net,1433;Initial Catalog=GUFI;Persist Security Info=False;User ID=lucao_o;Password=Lu418891104@132;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PK__evento__C8DC7BDA0F717BC6");

                entity.ToTable("evento");

                entity.Property(e => e.IdEvento).HasColumnName("idEvento");

                entity.Property(e => e.AcessoLivre)
                    .HasColumnName("acessoLivre")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DataEvento)
                    .HasColumnType("datetime")
                    .HasColumnName("dataEvento");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdInstituicao).HasColumnName("idInstituicao");

                entity.Property(e => e.IdTipoEvento).HasColumnName("idTipoEvento");

                entity.Property(e => e.NomeEvento)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeEvento");

                entity.HasOne(d => d.IdInstituicaoNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdInstituicao)
                    .HasConstraintName("FK__evento__idInstit__46E78A0C");

                entity.HasOne(d => d.IdTipoEventoNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdTipoEvento)
                    .HasConstraintName("FK__evento__idTipoEv__45F365D3");
            });

            modelBuilder.Entity<ImagemPerfil>(entity =>
            {
                entity.HasKey(e => e.IdImagemPerfil)
                    .HasName("PK__ImagemPe__630232F665BC7154");

                entity.ToTable("ImagemPerfil");

                entity.HasIndex(e => e.IdUsuario, "UQ__ImagemPe__645723A70CDF1DEE")
                    .IsUnique();

                entity.Property(e => e.IdImagemPerfil).HasColumnName("idImagemPerfil");

                entity.Property(e => e.Binario)
                    .IsRequired()
                    .HasColumnName("binario");

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("datetime")
                    .HasColumnName("dataCriacao")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("mimeType");

                entity.Property(e => e.NomeArquivo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeArquivo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.ImagemPerfil)
                    .HasForeignKey<ImagemPerfil>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ImagemPer__idUsu__70DDC3D8");
            });

            modelBuilder.Entity<Instituicao>(entity =>
            {
                entity.HasKey(e => e.IdInstituicao)
                    .HasName("PK__institui__8EA7AB0098D35412");

                entity.ToTable("instituicao");

                entity.HasIndex(e => e.Cnpj, "UQ__institui__35BD3E48C47A7087")
                    .IsUnique();

                entity.HasIndex(e => e.Endereco, "UQ__institui__9456D40685078326")
                    .IsUnique();

                entity.Property(e => e.IdInstituicao).HasColumnName("idInstituicao");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("cnpj")
                    .IsFixedLength(true);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeFantasia");
            });

            modelBuilder.Entity<Presenca>(entity =>
            {
                entity.HasKey(e => e.IdPresenca)
                    .HasName("PK__presenca__44CEA42789FEBEDA");

                entity.ToTable("presenca");

                entity.Property(e => e.IdPresenca).HasColumnName("idPresenca");

                entity.Property(e => e.IdEvento).HasColumnName("idEvento");

                entity.Property(e => e.IdSituacao)
                    .HasColumnName("idSituacao")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Presencas)
                    .HasForeignKey(d => d.IdEvento)
                    .HasConstraintName("FK__presenca__idEven__4BAC3F29");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Presencas)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__presenca__idSitu__4CA06362");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Presencas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__presenca__idUsua__4AB81AF0");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__situacao__12AFD1974975A76A");

                entity.ToTable("situacao");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<TipoEvento>(entity =>
            {
                entity.HasKey(e => e.IdTipoEvento)
                    .HasName("PK__tipoEven__CDB3A3BE3476C7B7");

                entity.ToTable("tipoEvento");

                entity.HasIndex(e => e.TituloTipoEvento, "UQ__tipoEven__D2A1CBBB021E96D5")
                    .IsUnique();

                entity.Property(e => e.TituloTipoEvento)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tituloTipoEvento");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF0705A6A7");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.TituloTipoUsuario, "UQ__tipoUsua__C6B29FC3E40D5DF8")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.TituloTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tituloTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A6589AE157");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E6164AD8245FB")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuario__idTipoU__4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
