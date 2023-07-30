﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NET_6_Relacionando_Entidades.Data;

#nullable disable

namespace NET_6_Relacionando_Entidades.Migrations
{
    [DbContext(typeof(FilmeContext))]
    [Migration("20230525220328_Delete_Restrict")]
    partial class Delete_Restrict
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NET_6_Relacionando_Entidades.Models.Filme", b =>
                {
                    b.Property<int>("IdFilme")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdFilme");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("NET_6_criando_uma_web.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("NET_6_criando_uma_web.Models.Movie_theater.Cinema", b =>
                {
                    b.Property<int>("IdCinema")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("NomeCinema")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdCinema");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("NET_6_criando_uma_web.Models.Sessao", b =>
                {
                    b.Property<int?>("FilmeId")
                        .HasColumnType("int");

                    b.Property<int?>("CinemaId")
                        .HasColumnType("int");

                    b.HasKey("FilmeId", "CinemaId");

                    b.HasIndex("CinemaId");

                    b.ToTable("Sessoes");
                });

            modelBuilder.Entity("NET_6_criando_uma_web.Models.Movie_theater.Cinema", b =>
                {
                    b.HasOne("NET_6_criando_uma_web.Models.Endereco", "Endereco")
                        .WithOne("Cinema")
                        .HasForeignKey("NET_6_criando_uma_web.Models.Movie_theater.Cinema", "EnderecoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("NET_6_criando_uma_web.Models.Sessao", b =>
                {
                    b.HasOne("NET_6_criando_uma_web.Models.Movie_theater.Cinema", "Cinema")
                        .WithMany("Sessoes")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NET_6_Relacionando_Entidades.Models.Filme", "Filme")
                        .WithMany("Sessoes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("NET_6_Relacionando_Entidades.Models.Filme", b =>
                {
                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("NET_6_criando_uma_web.Models.Endereco", b =>
                {
                    b.Navigation("Cinema")
                        .IsRequired();
                });

            modelBuilder.Entity("NET_6_criando_uma_web.Models.Movie_theater.Cinema", b =>
                {
                    b.Navigation("Sessoes");
                });
#pragma warning restore 612, 618
        }
    }
}
