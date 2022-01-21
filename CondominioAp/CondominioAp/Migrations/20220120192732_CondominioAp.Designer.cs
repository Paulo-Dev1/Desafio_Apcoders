﻿// <auto-generated />
using System;
using CondominioAp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CondominioAp.Migrations
{
    [DbContext(typeof(ApContext))]
    [Migration("20220120192732_CondominioAp")]
    partial class CondominioAp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CondominioAp.Models.Despesas", b =>
                {
                    b.Property<int>("Id_Despesa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status_Pagamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo_Despesa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnidadeId_unidade")
                        .HasColumnType("int");

                    b.Property<int?>("UnidadesId_Unidade")
                        .HasColumnType("int");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vencimento_Fatura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Despesa");

                    b.HasIndex("UnidadesId_Unidade");

                    b.ToTable("Despesas");
                });

            modelBuilder.Entity("CondominioAp.Models.Inquilinos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Inquilinos");
                });

            modelBuilder.Entity("CondominioAp.Models.Unidades", b =>
                {
                    b.Property<int>("Id_Unidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Condominio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identificacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InquilinosId")
                        .HasColumnType("int");

                    b.Property<int>("InquilinosId_Inquilino")
                        .HasColumnType("int");

                    b.Property<string>("Propietario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Unidade");

                    b.HasIndex("InquilinosId");

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("CondominioAp.Models.Despesas", b =>
                {
                    b.HasOne("CondominioAp.Models.Unidades", "Unidades")
                        .WithMany()
                        .HasForeignKey("UnidadesId_Unidade");

                    b.Navigation("Unidades");
                });

            modelBuilder.Entity("CondominioAp.Models.Unidades", b =>
                {
                    b.HasOne("CondominioAp.Models.Inquilinos", "Inquilinos")
                        .WithMany()
                        .HasForeignKey("InquilinosId");

                    b.Navigation("Inquilinos");
                });
#pragma warning restore 612, 618
        }
    }
}
