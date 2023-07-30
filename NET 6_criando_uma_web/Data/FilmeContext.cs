using Microsoft.EntityFrameworkCore;
using NET_6_criando_uma_web.Models;
using NET_6_criando_uma_web.Models.Movie_theater;
using NET_6_Relacionando_Entidades.Models;

namespace NET_6_Relacionando_Entidades.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts) 
            : base(opts) 
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sessao>()
                .HasKey(sessao => new
                {
                    sessao.FilmeId,
                    sessao.CinemaId
                });

            modelBuilder.Entity<Sessao>()
                .HasOne(sessao => sessao.Cinema)
                .WithMany(cinema => cinema.Sessoes)
                .HasForeignKey(sessao => sessao.CinemaId);

           modelBuilder.Entity<Sessao>()
                .HasOne(sessao => sessao.Filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.FilmeId);

            modelBuilder.Entity<Endereco>()
                .HasOne(enderco => enderco.Cinema)
                .WithOne(cinema => cinema.Endereco)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Sessao> Sessoes { get; set; }
    }
}
