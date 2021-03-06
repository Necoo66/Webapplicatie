﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HoneymoonShop.Data;

namespace HoneymoonShop.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170110120546_trouwjurk")]
    partial class trouwjurk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HoneymoonShop.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Bruid.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naam")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Bruid.Kleur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Kleurcode")
                        .HasAnnotation("MaxLength", 6);

                    b.Property<int?>("TrouwjurkId");

                    b.Property<string>("Naam")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("TrouwjurkId");

                    b.ToTable("Kleur");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Bruid.Merk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naam")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Merk");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Bruid.Neklijn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("TrouwjurkId");

                    b.Property<string>("Naam")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("TrouwjurkId");

                    b.ToTable("Neklijn");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Bruid.Silhouette", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("TrouwjurkId");

                    b.Property<string>("Naam")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("TrouwjurkId");

                    b.ToTable("Silhouette");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Bruid.Stijl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("TrouwjurkId");

                    b.Property<string>("Naam")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("TrouwjurkId");

                    b.ToTable("Stijl");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Bruid.Trouwjurk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtikelNummer")
                        .IsRequired();

                    b.Property<int?>("CategorieId");

                    b.Property<int?>("MerkId")
                        .IsRequired();

                    b.Property<double>("Prijs");

                    b.Property<string>("Beschrijving");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.HasIndex("MerkId");

                    b.ToTable("Trouwjurk");
                });

            modelBuilder.Entity("HoneymoonShop.Models.GebruikerModels.Afspraak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AfspraakSoort");

                    b.Property<DateTime>("Datum");

                    b.Property<int?>("GebruikerId");

                    b.Property<string>("Tijd");

                    b.HasKey("Id");

                    b.HasIndex("GebruikerId");

                    b.ToTable("Afspraak");
                });

            modelBuilder.Entity("HoneymoonShop.Models.GebruikerModels.Gebruiker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("Nieuwsbrief");

                    b.Property<string>("Telefoonnummer");

                    b.Property<DateTime>("Trouwdatum")
                        .HasColumnType("Date");

                    b.Property<string>("VoornaamAchternaam")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.ToTable("Gebruiker");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Bruid.Kleur", b =>
                {
                    b.HasOne("HoneymoonShop.Models.Bruid.Trouwjurk")
                        .WithMany("Kleuren")
                        .HasForeignKey("TrouwjurkId");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Bruid.Neklijn", b =>
                {
                    b.HasOne("HoneymoonShop.Models.Bruid.Trouwjurk")
                        .WithMany("Neklijnen")
                        .HasForeignKey("TrouwjurkId");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Bruid.Silhouette", b =>
                {
                    b.HasOne("HoneymoonShop.Models.Bruid.Trouwjurk")
                        .WithMany("Silhouetten")
                        .HasForeignKey("TrouwjurkId");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Bruid.Stijl", b =>
                {
                    b.HasOne("HoneymoonShop.Models.Bruid.Trouwjurk")
                        .WithMany("Stijlen")
                        .HasForeignKey("TrouwjurkId");
                });

            modelBuilder.Entity("HoneymoonShop.Models.Bruid.Trouwjurk", b =>
                {
                    b.HasOne("HoneymoonShop.Models.Bruid.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieId");

                    b.HasOne("HoneymoonShop.Models.Bruid.Merk", "Merk")
                        .WithMany()
                        .HasForeignKey("MerkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HoneymoonShop.Models.GebruikerModels.Afspraak", b =>
                {
                    b.HasOne("HoneymoonShop.Models.GebruikerModels.Gebruiker", "Gebruiker")
                        .WithMany("Afspraken")
                        .HasForeignKey("GebruikerId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HoneymoonShop.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HoneymoonShop.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HoneymoonShop.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
