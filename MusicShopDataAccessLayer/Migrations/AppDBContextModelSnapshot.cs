﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicShopDataAccessLayer;

#nullable disable

namespace MusicShopDataAccessLayer.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MusicShopEntities.Entities.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedYear")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RecordCompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Singer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Albums", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1000,
                            CreatedDate = new DateTime(2023, 8, 4, 13, 22, 37, 876, DateTimeKind.Local).AddTicks(7370),
                            CreatedYear = 2021,
                            CustomerId = 100,
                            Name = "UltraVolence",
                            RecordCompanyName = "Atlanta",
                            Singer = "Lana"
                        },
                        new
                        {
                            Id = 1001,
                            CreatedDate = new DateTime(2023, 8, 4, 13, 22, 37, 876, DateTimeKind.Local).AddTicks(7382),
                            CreatedYear = 2022,
                            CustomerId = 101,
                            Name = "NormanFW",
                            RecordCompanyName = "Parental",
                            Singer = "Lana"
                        });
                });

            modelBuilder.Entity("MusicShopEntities.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 100,
                            CreatedDate = new DateTime(2023, 8, 4, 13, 22, 37, 876, DateTimeKind.Local).AddTicks(7663),
                            Email = "ceren@gmail.com",
                            Name = "Ceren",
                            Phone = "1234567890"
                        },
                        new
                        {
                            Id = 101,
                            CreatedDate = new DateTime(2023, 8, 4, 13, 22, 37, 876, DateTimeKind.Local).AddTicks(7666),
                            Email = "tuana2@gmail.com",
                            Name = "Tuana",
                            Phone = "9876543210"
                        });
                });

            modelBuilder.Entity("MusicShopEntities.Entities.RecordCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyValue")
                        .HasColumnType("int");

                    b.Property<int>("CompanyYear")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId")
                        .IsUnique();

                    b.ToTable("RecordCompanies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 10,
                            AlbumId = 1000,
                            CompanyValue = 1000000,
                            CompanyYear = 1990,
                            CreatedDate = new DateTime(2023, 8, 4, 13, 22, 37, 876, DateTimeKind.Local).AddTicks(7812),
                            Name = "Atlanta"
                        },
                        new
                        {
                            Id = 11,
                            AlbumId = 1001,
                            CompanyValue = 2000000,
                            CompanyYear = 2000,
                            CreatedDate = new DateTime(2023, 8, 4, 13, 22, 37, 876, DateTimeKind.Local).AddTicks(7815),
                            Name = "Parental"
                        });
                });

            modelBuilder.Entity("MusicShopEntities.Entities.UserAutho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PassWordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PassWordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("UserAutho", (string)null);
                });

            modelBuilder.Entity("MusicShopEntities.Entities.Album", b =>
                {
                    b.HasOne("MusicShopEntities.Entities.Customer", "Customer")
                        .WithMany("Albums")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MusicShopEntities.Entities.RecordCompany", b =>
                {
                    b.HasOne("MusicShopEntities.Entities.Album", "Album")
                        .WithOne("RecordCompany")
                        .HasForeignKey("MusicShopEntities.Entities.RecordCompany", "AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("MusicShopEntities.Entities.Album", b =>
                {
                    b.Navigation("RecordCompany")
                        .IsRequired();
                });

            modelBuilder.Entity("MusicShopEntities.Entities.Customer", b =>
                {
                    b.Navigation("Albums");
                });
#pragma warning restore 612, 618
        }
    }
}
