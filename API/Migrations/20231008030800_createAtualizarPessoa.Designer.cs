﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20231008030800_createAtualizarPessoa")]
    partial class createAtualizarPessoa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.21");

            modelBuilder.Entity("API.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comportamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Especie")
                        .HasColumnType("TEXT");

                    b.Property<string>("Foto")
                        .HasColumnType("TEXT");

                    b.Property<string>("Idade")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ONGId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Porte")
                        .HasColumnType("TEXT");

                    b.Property<string>("Raca")
                        .HasColumnType("TEXT");

                    b.Property<string>("Video")
                        .HasColumnType("TEXT");

                    b.HasKey("AnimalId");

                    b.HasIndex("ONGId");

                    b.ToTable("Animais");
                });

            modelBuilder.Entity("API.Models.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataEvento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("ONGId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventoId");

                    b.HasIndex("ONGId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("API.Models.ONG", b =>
                {
                    b.Property<int>("ONGId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("Historico")
                        .HasColumnType("TEXT");

                    b.Property<string>("InformacoesContato")
                        .HasColumnType("TEXT");

                    b.Property<string>("Missao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("ONGId");

                    b.ToTable("ONGs");
                });

            modelBuilder.Entity("API.Models.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroTelefone")
                        .HasColumnType("TEXT");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("API.Models.Animal", b =>
                {
                    b.HasOne("API.Models.ONG", "ONG")
                        .WithMany()
                        .HasForeignKey("ONGId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ONG");
                });

            modelBuilder.Entity("API.Models.Evento", b =>
                {
                    b.HasOne("API.Models.ONG", "ONG")
                        .WithMany()
                        .HasForeignKey("ONGId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ONG");
                });
#pragma warning restore 612, 618
        }
    }
}
