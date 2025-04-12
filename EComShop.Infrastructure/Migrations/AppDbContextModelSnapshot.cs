﻿// <auto-generated />
using EComShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EComShop.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EComShop.Core.Entities.Product.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Electronic Items",
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Dresses",
                            Name = "Clothes"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Grocery Items",
                            Name = "Grocery"
                        });
                });

            modelBuilder.Entity("EComShop.Core.Entities.Product.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Photos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageName = "product-1.jpg",
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            ImageName = "product-2.jpg",
                            ProductId = 2
                        },
                        new
                        {
                            Id = 3,
                            ImageName = "product-3.jpg",
                            ProductId = 3
                        },
                        new
                        {
                            Id = 4,
                            ImageName = "product-4.jpg",
                            ProductId = 4
                        },
                        new
                        {
                            Id = 5,
                            ImageName = "product-5.jpg",
                            ProductId = 5
                        },
                        new
                        {
                            Id = 6,
                            ImageName = "product-6.jpg",
                            ProductId = 6
                        },
                        new
                        {
                            Id = 7,
                            ImageName = "product-7.jpg",
                            ProductId = 7
                        },
                        new
                        {
                            Id = 8,
                            ImageName = "product-8.jpg",
                            ProductId = 8
                        },
                        new
                        {
                            Id = 9,
                            ImageName = "product-9.jpg",
                            ProductId = 9
                        },
                        new
                        {
                            Id = 10,
                            ImageName = "product-10.jpg",
                            ProductId = 10
                        });
                });

            modelBuilder.Entity("EComShop.Core.Entities.Product.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("NewPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OldPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Dell Laptop",
                            Name = "Laptop",
                            NewPrice = 50000m,
                            OldPrice = 0m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Samsung Mobile",
                            Name = "Mobile",
                            NewPrice = 20000m,
                            OldPrice = 0m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "Peter England Shirt",
                            Name = "Shirt",
                            NewPrice = 2000m,
                            OldPrice = 0m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Polo T-Shirt",
                            Name = "T-Shirt",
                            NewPrice = 1000m,
                            OldPrice = 0m
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Description = "Basmati Rice",
                            Name = "Rice",
                            NewPrice = 50m,
                            OldPrice = 0m
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Description = "Wheat Flour",
                            Name = "Wheat",
                            NewPrice = 30m,
                            OldPrice = 0m
                        });
                });

            modelBuilder.Entity("EComShop.Core.Entities.Product.Photo", b =>
                {
                    b.HasOne("EComShop.Core.Entities.Product.Product", null)
                        .WithMany("Photos")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EComShop.Core.Entities.Product.Product", b =>
                {
                    b.HasOne("EComShop.Core.Entities.Product.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EComShop.Core.Entities.Product.Product", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
