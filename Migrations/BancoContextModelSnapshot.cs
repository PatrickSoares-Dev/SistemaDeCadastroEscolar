﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sistema_Escolar.Data;

namespace Sistema_Escolar.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sistema_Escolar.Models.AlunosModel", b =>
                {
                    b.Property<int>("ID_Aluno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ano_Letivo")
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EscolaID_Escola")
                        .HasColumnType("int");

                    b.Property<int>("ID_Escola")
                        .HasColumnType("int");

                    b.Property<int>("ID_Turma")
                        .HasColumnType("int");

                    b.Property<string>("Nome_Completo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status_Cadastro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TurmaID_Turma")
                        .HasColumnType("int");

                    b.HasKey("ID_Aluno");

                    b.HasIndex("EscolaID_Escola");

                    b.HasIndex("TurmaID_Turma");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("Sistema_Escolar.Models.EscolaModel", b =>
                {
                    b.Property<int>("ID_Escola")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome_Escola")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Qtde_Alunos")
                        .HasColumnType("int");

                    b.Property<int>("Qtde_Turmas")
                        .HasColumnType("int");

                    b.HasKey("ID_Escola");

                    b.ToTable("Escolas");
                });

            modelBuilder.Entity("Sistema_Escolar.Models.MateriasModel", b =>
                {
                    b.Property<int>("ID_Materia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome_Materia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Professor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID_Materia");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("Sistema_Escolar.Models.TurmaMateriaModel", b =>
                {
                    b.Property<int>("ID_Turma")
                        .HasColumnType("int");

                    b.Property<int>("ID_Materia")
                        .HasColumnType("int");

                    b.HasKey("ID_Turma", "ID_Materia");

                    b.HasIndex("ID_Materia");

                    b.ToTable("TurmaMateria");
                });

            modelBuilder.Entity("Sistema_Escolar.Models.TurmasModel", b =>
                {
                    b.Property<int>("ID_Turma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EscolaID_Escola")
                        .HasColumnType("int");

                    b.Property<int>("ID_Escola")
                        .HasColumnType("int");

                    b.Property<string>("Nome_Escola")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome_Turma")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Turma");

                    b.HasIndex("EscolaID_Escola");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("Sistema_Escolar.Models.AlunosModel", b =>
                {
                    b.HasOne("Sistema_Escolar.Models.EscolaModel", "Escola")
                        .WithMany("Alunos")
                        .HasForeignKey("EscolaID_Escola");

                    b.HasOne("Sistema_Escolar.Models.TurmasModel", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaID_Turma");

                    b.Navigation("Escola");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Sistema_Escolar.Models.TurmaMateriaModel", b =>
                {
                    b.HasOne("Sistema_Escolar.Models.MateriasModel", "Materia")
                        .WithMany("TurmasMaterias")
                        .HasForeignKey("ID_Materia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_Escolar.Models.TurmasModel", "Turma")
                        .WithMany()
                        .HasForeignKey("ID_Turma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materia");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Sistema_Escolar.Models.TurmasModel", b =>
                {
                    b.HasOne("Sistema_Escolar.Models.EscolaModel", "Escola")
                        .WithMany("Turmas")
                        .HasForeignKey("EscolaID_Escola");

                    b.Navigation("Escola");
                });

            modelBuilder.Entity("Sistema_Escolar.Models.EscolaModel", b =>
                {
                    b.Navigation("Alunos");

                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("Sistema_Escolar.Models.MateriasModel", b =>
                {
                    b.Navigation("TurmasMaterias");
                });

            modelBuilder.Entity("Sistema_Escolar.Models.TurmasModel", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}
