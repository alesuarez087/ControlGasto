﻿// <auto-generated />
using System;
using API.Rest.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Rest.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211128231848_add-local1")]
    partial class addlocal1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Rest.Model.Local", b =>
                {
                    b.Property<int>("IdLocal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dirección")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLocal");

                    b.ToTable("Locales");
                });

            modelBuilder.Entity("API.Rest.Model.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("API.Rest.Model.Movimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("TipoMovimiento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Movimientos");
                });

            modelBuilder.Entity("API.Rest.Model.MovimientoProductos", b =>
                {
                    b.Property<int>("IdMovimiento")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<decimal>("Unidad")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdMovimiento");

                    b.HasIndex("IdProducto");

                    b.ToTable("MovimientoProductos");
                });

            modelBuilder.Entity("API.Rest.Model.Precio", b =>
                {
                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdProducto");

                    b.ToTable("PreciosProducto");
                });

            modelBuilder.Entity("API.Rest.Model.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdMarca")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdUnidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdMarca");

                    b.HasIndex("IdTipoProducto");

                    b.HasIndex("IdUnidad");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("API.Rest.Model.TipoProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TiposProducto");
                });

            modelBuilder.Entity("API.Rest.Model.Unidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("API.Rest.Model.MovimientoProductos", b =>
                {
                    b.HasOne("API.Rest.Model.Movimiento", "Movimiento")
                        .WithMany("MovimientoProducto")
                        .HasForeignKey("IdMovimiento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Rest.Model.Producto", "Producto")
                        .WithMany("MovimientoProducto")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movimiento");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("API.Rest.Model.Precio", b =>
                {
                    b.HasOne("API.Rest.Model.Producto", "Producto")
                        .WithOne("Precio")
                        .HasForeignKey("API.Rest.Model.Precio", "IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("API.Rest.Model.Producto", b =>
                {
                    b.HasOne("API.Rest.Model.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("IdMarca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Rest.Model.TipoProducto", "TipoProducto")
                        .WithMany()
                        .HasForeignKey("IdTipoProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Rest.Model.Unidad", "Unidad")
                        .WithMany()
                        .HasForeignKey("IdUnidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");

                    b.Navigation("TipoProducto");

                    b.Navigation("Unidad");
                });

            modelBuilder.Entity("API.Rest.Model.Movimiento", b =>
                {
                    b.Navigation("MovimientoProducto");
                });

            modelBuilder.Entity("API.Rest.Model.Producto", b =>
                {
                    b.Navigation("MovimientoProducto");

                    b.Navigation("Precio");
                });
#pragma warning restore 612, 618
        }
    }
}
