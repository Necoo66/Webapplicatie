using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HoneymoonShop.Data.Migrations
{
    public partial class trouwjurk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    naam = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Merk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    naam = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trouwjurk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtikelNummer = table.Column<string>(nullable: false),
                    CategorieId = table.Column<int>(nullable: true),
                    MerkId = table.Column<int>(nullable: false),
                    Prijs = table.Column<double>(nullable: false),
                    beschrijving = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trouwjurk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trouwjurk_Categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trouwjurk_Merk_MerkId",
                        column: x => x.MerkId,
                        principalTable: "Merk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kleur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kleurcode = table.Column<string>(maxLength: 6, nullable: true),
                    TrouwjurkId = table.Column<int>(nullable: true),
                    naam = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kleur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kleur_Trouwjurk_TrouwjurkId",
                        column: x => x.TrouwjurkId,
                        principalTable: "Trouwjurk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Neklijn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TrouwjurkId = table.Column<int>(nullable: true),
                    naam = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neklijn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Neklijn_Trouwjurk_TrouwjurkId",
                        column: x => x.TrouwjurkId,
                        principalTable: "Trouwjurk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Silhouette",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TrouwjurkId = table.Column<int>(nullable: true),
                    naam = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Silhouette", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Silhouette_Trouwjurk_TrouwjurkId",
                        column: x => x.TrouwjurkId,
                        principalTable: "Trouwjurk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stijl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TrouwjurkId = table.Column<int>(nullable: true),
                    naam = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stijl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stijl_Trouwjurk_TrouwjurkId",
                        column: x => x.TrouwjurkId,
                        principalTable: "Trouwjurk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AlterColumn<string>(
                name: "VoornaamAchternaam",
                table: "Gebruiker",
                maxLength: 100,
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Kleur_TrouwjurkId",
                table: "Kleur",
                column: "TrouwjurkId");

            migrationBuilder.CreateIndex(
                name: "IX_Neklijn_TrouwjurkId",
                table: "Neklijn",
                column: "TrouwjurkId");

            migrationBuilder.CreateIndex(
                name: "IX_Silhouette_TrouwjurkId",
                table: "Silhouette",
                column: "TrouwjurkId");

            migrationBuilder.CreateIndex(
                name: "IX_Stijl_TrouwjurkId",
                table: "Stijl",
                column: "TrouwjurkId");

            migrationBuilder.CreateIndex(
                name: "IX_Trouwjurk_CategorieId",
                table: "Trouwjurk",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Trouwjurk_MerkId",
                table: "Trouwjurk",
                column: "MerkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kleur");

            migrationBuilder.DropTable(
                name: "Neklijn");

            migrationBuilder.DropTable(
                name: "Silhouette");

            migrationBuilder.DropTable(
                name: "Stijl");

            migrationBuilder.DropTable(
                name: "Trouwjurk");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Merk");

            migrationBuilder.AlterColumn<string>(
                name: "VoornaamAchternaam",
                table: "Gebruiker",
                maxLength: 100,
                nullable: true);
        }
    }
}
