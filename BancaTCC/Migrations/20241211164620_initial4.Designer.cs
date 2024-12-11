﻿// <auto-generated />
using System;
using BancaTCC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BancaTCC.Migrations
{
    [DbContext(typeof(BancaTCCContext))]
    [Migration("20241211164620_initial4")]
    partial class initial4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BancaTCC.Models.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("BancaTCC.Models.Banca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("HoraFim")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("time");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resultado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrabalhoId")
                        .HasColumnType("int");

                    b.Property<long>("TrabalhoId1")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TrabalhoId1");

                    b.ToTable("Bancas");
                });

            modelBuilder.Entity("BancaTCC.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("BancaTCC.Models.MembroExterno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BancaId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BancaId");

                    b.ToTable("MembrosExternos");
                });

            modelBuilder.Entity("BancaTCC.Models.Orientador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrdemPreferencia")
                        .HasColumnType("int");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrabalhoId")
                        .HasColumnType("int");

                    b.Property<long>("TrabalhoId1")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("TrabalhoId1");

                    b.ToTable("OrientadoresIndicados");
                });

            modelBuilder.Entity("BancaTCC.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("BancaTCC.Models.Trabalho", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int?>("AutorId")
                        .HasColumnType("int");

                    b.Property<string>("TrabalhoArea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrabalhoGitLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrabalhoLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrabalhoTema")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.ToTable("Trabalhos");
                });

            modelBuilder.Entity("BancaTCC.Models.Autor", b =>
                {
                    b.HasOne("BancaTCC.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("BancaTCC.Models.Banca", b =>
                {
                    b.HasOne("BancaTCC.Models.Trabalho", "Trabalho")
                        .WithMany()
                        .HasForeignKey("TrabalhoId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trabalho");
                });

            modelBuilder.Entity("BancaTCC.Models.MembroExterno", b =>
                {
                    b.HasOne("BancaTCC.Models.Banca", "Banca")
                        .WithMany("MembrosExternos")
                        .HasForeignKey("BancaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banca");
                });

            modelBuilder.Entity("BancaTCC.Models.Orientador", b =>
                {
                    b.HasOne("BancaTCC.Models.Professor", "Professor")
                        .WithMany("OrientadoresIndicados")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BancaTCC.Models.Trabalho", "Trabalho")
                        .WithMany()
                        .HasForeignKey("TrabalhoId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");

                    b.Navigation("Trabalho");
                });

            modelBuilder.Entity("BancaTCC.Models.Trabalho", b =>
                {
                    b.HasOne("BancaTCC.Models.Autor", null)
                        .WithMany("Trabalhos")
                        .HasForeignKey("AutorId");
                });

            modelBuilder.Entity("BancaTCC.Models.Autor", b =>
                {
                    b.Navigation("Trabalhos");
                });

            modelBuilder.Entity("BancaTCC.Models.Banca", b =>
                {
                    b.Navigation("MembrosExternos");
                });

            modelBuilder.Entity("BancaTCC.Models.Professor", b =>
                {
                    b.Navigation("OrientadoresIndicados");
                });
#pragma warning restore 612, 618
        }
    }
}
