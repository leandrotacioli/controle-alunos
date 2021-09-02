﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Data;

namespace WebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210902223750_Script01")]
    partial class Script01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApp.Models.Aluno", b =>
                {
                    b.Property<int>("CodAluno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodCurso")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("Date");

                    b.Property<string>("NomeAluno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CodAluno");

                    b.HasIndex("CodCurso");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("WebApp.Models.Curso", b =>
                {
                    b.Property<int>("CodCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeCurso")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CodCurso");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("WebApp.Models.Aluno", b =>
                {
                    b.HasOne("WebApp.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CodCurso")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Curso");
                });
#pragma warning restore 612, 618
        }
    }
}