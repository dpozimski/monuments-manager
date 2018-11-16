﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Monuments.Manager.Persistence;

namespace Monuments.Manager.Persistence.Migrations
{
    [DbContext(typeof(MonumentsDbContext))]
    [Migration("20181116212802_MonumentsDbMigration")]
    partial class MonumentsDbMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Monuments.Manager.Domain.Entities.AddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .HasMaxLength(300);

                    b.Property<string>("City")
                        .HasMaxLength(100);

                    b.Property<string>("Commune")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("District")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("MonumentId");

                    b.Property<string>("Province")
                        .HasMaxLength(100);

                    b.Property<string>("Street")
                        .HasMaxLength(100);

                    b.Property<string>("StreetNumber")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("MonumentId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Monuments.Manager.Domain.Entities.CityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommuneId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CommuneId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Monuments.Manager.Domain.Entities.CommuneEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("DistrictId");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Communes");
                });

            modelBuilder.Entity("Monuments.Manager.Domain.Entities.DistrictEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("ProvinceId");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("Monuments.Manager.Domain.Entities.MonumentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ConstructionDate");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FormOfProtection")
                        .HasMaxLength(300);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Monuments");
                });

            modelBuilder.Entity("Monuments.Manager.Domain.Entities.PictureEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("image");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("MonumentId");

                    b.HasKey("Id");

                    b.HasIndex("MonumentId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Monuments.Manager.Domain.Entities.ProvinceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("Monuments.Manager.Domain.Entities.StreetEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("Monuments.Manager.Domain.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("JobTitle")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Role");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Monuments.Manager.Domain.Entities.AddressEntity", b =>
                {
                    b.HasOne("Monuments.Manager.Domain.Entities.MonumentEntity", "Monument")
                        .WithOne("Address")
                        .HasForeignKey("Monuments.Manager.Domain.Entities.AddressEntity", "MonumentId")
                        .HasConstraintName("FK_Monument_Address")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monuments.Manager.Domain.Entities.CityEntity", b =>
                {
                    b.HasOne("Monuments.Manager.Domain.Entities.CommuneEntity", "Commune")
                        .WithMany("Cities")
                        .HasForeignKey("CommuneId")
                        .HasConstraintName("FK_City_Commune")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monuments.Manager.Domain.Entities.CommuneEntity", b =>
                {
                    b.HasOne("Monuments.Manager.Domain.Entities.DistrictEntity", "District")
                        .WithMany("Communes")
                        .HasForeignKey("DistrictId")
                        .HasConstraintName("FK_Commune_District")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monuments.Manager.Domain.Entities.DistrictEntity", b =>
                {
                    b.HasOne("Monuments.Manager.Domain.Entities.ProvinceEntity", "Province")
                        .WithMany("Districts")
                        .HasForeignKey("ProvinceId")
                        .HasConstraintName("FK_District_Province")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monuments.Manager.Domain.Entities.MonumentEntity", b =>
                {
                    b.HasOne("Monuments.Manager.Domain.Entities.UserEntity", "User")
                        .WithMany("Monuments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Monument_User")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monuments.Manager.Domain.Entities.PictureEntity", b =>
                {
                    b.HasOne("Monuments.Manager.Domain.Entities.MonumentEntity", "Monument")
                        .WithMany("Pictures")
                        .HasForeignKey("MonumentId")
                        .HasConstraintName("FK_Picture_Monument")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Monuments.Manager.Domain.Entities.StreetEntity", b =>
                {
                    b.HasOne("Monuments.Manager.Domain.Entities.CityEntity", "City")
                        .WithMany("Streets")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK_Street_City")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
