﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer.Databases.Configuration;

#nullable disable

namespace RepositoryLayer.Databases.Migrations
{
    [DbContext(typeof(BookingDataContext))]
    partial class BookingDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RepositoryLayer.Databases.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("RepositoryLayer.Databases.Entities.BookingEntities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ResidentId")
                        .HasColumnType("int");

                    b.Property<string>("TransactionToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ResidentId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("RepositoryLayer.Databases.Entities.BookingEntities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdditionalFeatures")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomsTypes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThumbnailImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("RepositoryLayer.Databases.Entities.BookingEntities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdditionalFeatures")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ResidentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ResidentId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RepositoryLayer.Databases.Entities.BookingEntities.Resident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Residents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Gyventojas.Vienas@mail.com",
                            Name = "Gyventojas",
                            PhoneNumber = "+37062347291",
                            Surname = "Vienas"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Gyventojas.Du@mail.com",
                            Name = "Gyventojas",
                            PhoneNumber = "+37062347292",
                            Surname = "Du"
                        },
                        new
                        {
                            Id = 3,
                            Email = "Gyventojas.Trys@mail.com",
                            Name = "Gyventojas",
                            PhoneNumber = "+37062347293",
                            Surname = "Trys"
                        },
                        new
                        {
                            Id = 4,
                            Email = "Gyventojas.Keturi@mail.com",
                            Name = "Gyventojas",
                            PhoneNumber = "+37062347294",
                            Surname = "Keturi"
                        });
                });

            modelBuilder.Entity("RepositoryLayer.Databases.Entities.BookingEntities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Number = "101",
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Number = "102",
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            Number = "103",
                            Type = 0
                        },
                        new
                        {
                            Id = 4,
                            Number = "104",
                            Type = 0
                        },
                        new
                        {
                            Id = 5,
                            Number = "105",
                            Type = 0
                        },
                        new
                        {
                            Id = 6,
                            Number = "106",
                            Type = 0
                        },
                        new
                        {
                            Id = 7,
                            Number = "107",
                            Type = 0
                        },
                        new
                        {
                            Id = 8,
                            Number = "108",
                            Type = 0
                        },
                        new
                        {
                            Id = 9,
                            Number = "109",
                            Type = 0
                        },
                        new
                        {
                            Id = 10,
                            Number = "110",
                            Type = 0
                        },
                        new
                        {
                            Id = 11,
                            Number = "201",
                            Type = 1
                        },
                        new
                        {
                            Id = 12,
                            Number = "202",
                            Type = 1
                        },
                        new
                        {
                            Id = 13,
                            Number = "203",
                            Type = 1
                        },
                        new
                        {
                            Id = 14,
                            Number = "204",
                            Type = 1
                        },
                        new
                        {
                            Id = 15,
                            Number = "205",
                            Type = 1
                        },
                        new
                        {
                            Id = 16,
                            Number = "206",
                            Type = 1
                        },
                        new
                        {
                            Id = 17,
                            Number = "207",
                            Type = 1
                        },
                        new
                        {
                            Id = 18,
                            Number = "208",
                            Type = 1
                        },
                        new
                        {
                            Id = 19,
                            Number = "209",
                            Type = 1
                        },
                        new
                        {
                            Id = 20,
                            Number = "210",
                            Type = 1
                        },
                        new
                        {
                            Id = 21,
                            Number = "301",
                            Type = 2
                        },
                        new
                        {
                            Id = 22,
                            Number = "302",
                            Type = 2
                        },
                        new
                        {
                            Id = 23,
                            Number = "303",
                            Type = 2
                        },
                        new
                        {
                            Id = 24,
                            Number = "304",
                            Type = 2
                        },
                        new
                        {
                            Id = 25,
                            Number = "305",
                            Type = 2
                        },
                        new
                        {
                            Id = 26,
                            Number = "306",
                            Type = 2
                        },
                        new
                        {
                            Id = 27,
                            Number = "307",
                            Type = 2
                        },
                        new
                        {
                            Id = 28,
                            Number = "308",
                            Type = 2
                        },
                        new
                        {
                            Id = 29,
                            Number = "309",
                            Type = 2
                        },
                        new
                        {
                            Id = 30,
                            Number = "310",
                            Type = 2
                        },
                        new
                        {
                            Id = 31,
                            Number = "401",
                            Type = 3
                        },
                        new
                        {
                            Id = 32,
                            Number = "402",
                            Type = 3
                        },
                        new
                        {
                            Id = 33,
                            Number = "403",
                            Type = 4
                        },
                        new
                        {
                            Id = 34,
                            Number = "404",
                            Type = 3
                        },
                        new
                        {
                            Id = 35,
                            Number = "405",
                            Type = 3
                        },
                        new
                        {
                            Id = 36,
                            Number = "406",
                            Type = 3
                        },
                        new
                        {
                            Id = 37,
                            Number = "407",
                            Type = 3
                        },
                        new
                        {
                            Id = 38,
                            Number = "408",
                            Type = 3
                        },
                        new
                        {
                            Id = 39,
                            Number = "409",
                            Type = 3
                        },
                        new
                        {
                            Id = 40,
                            Number = "410",
                            Type = 3
                        },
                        new
                        {
                            Id = 41,
                            Number = "501",
                            Type = 4
                        },
                        new
                        {
                            Id = 42,
                            Number = "502",
                            Type = 4
                        },
                        new
                        {
                            Id = 43,
                            Number = "503",
                            Type = 4
                        },
                        new
                        {
                            Id = 44,
                            Number = "504",
                            Type = 4
                        },
                        new
                        {
                            Id = 45,
                            Number = "505",
                            Type = 4
                        },
                        new
                        {
                            Id = 46,
                            Number = "506",
                            Type = 4
                        },
                        new
                        {
                            Id = 47,
                            Number = "507",
                            Type = 4
                        },
                        new
                        {
                            Id = 48,
                            Number = "508",
                            Type = 4
                        },
                        new
                        {
                            Id = 49,
                            Number = "509",
                            Type = 4
                        },
                        new
                        {
                            Id = 50,
                            Number = "510",
                            Type = 4
                        });
                });

            modelBuilder.Entity("RepositoryLayer.Databases.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("RepositoryLayer.Databases.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("ReservationRoom", b =>
                {
                    b.Property<int>("ReservationsId")
                        .HasColumnType("int");

                    b.Property<int>("RoomsId")
                        .HasColumnType("int");

                    b.HasKey("ReservationsId", "RoomsId");

                    b.HasIndex("RoomsId");

                    b.ToTable("ReservationRoom");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RepositoryLayer.Databases.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RepositoryLayer.Databases.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepositoryLayer.Databases.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RepositoryLayer.Databases.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RepositoryLayer.Databases.Entities.BookingEntities.Payment", b =>
                {
                    b.HasOne("RepositoryLayer.Databases.Entities.BookingEntities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepositoryLayer.Databases.Entities.BookingEntities.Resident", "Resident")
                        .WithMany()
                        .HasForeignKey("ResidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Resident");
                });

            modelBuilder.Entity("RepositoryLayer.Databases.Entities.BookingEntities.Reservation", b =>
                {
                    b.HasOne("RepositoryLayer.Databases.Entities.BookingEntities.Resident", "Resident")
                        .WithMany("Reservations")
                        .HasForeignKey("ResidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resident");
                });

            modelBuilder.Entity("RepositoryLayer.Databases.Entities.Image", b =>
                {
                    b.HasOne("RepositoryLayer.Databases.Entities.BookingEntities.Product", null)
                        .WithMany("Images")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("ReservationRoom", b =>
                {
                    b.HasOne("RepositoryLayer.Databases.Entities.BookingEntities.Reservation", null)
                        .WithMany()
                        .HasForeignKey("ReservationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepositoryLayer.Databases.Entities.BookingEntities.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RepositoryLayer.Databases.Entities.BookingEntities.Product", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("RepositoryLayer.Databases.Entities.BookingEntities.Resident", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
