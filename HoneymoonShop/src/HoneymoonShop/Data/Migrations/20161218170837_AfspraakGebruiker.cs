using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneymoonShop.Data.Migrations
{
    public partial class AfspraakGebruiker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gebruiker",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Emailadres = table.Column<string>(nullable: false),
                    Naam = table.Column<string>(maxLength: 100, nullable: false),
                    Telefoonnummer = table.Column<int>(nullable: false),
                    Trouwdatum = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruiker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Afspraak",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    GebruikerId = table.Column<int>(nullable: true),
                    Tijd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afspraak", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Afspraak_Gebruiker_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afspraak_GebruikerId",
                table: "Afspraak",
                column: "GebruikerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Afspraak");

            migrationBuilder.DropTable(
                name: "Gebruiker");
        }
    }
}
