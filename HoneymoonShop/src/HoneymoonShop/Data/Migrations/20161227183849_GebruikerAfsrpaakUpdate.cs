using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneymoonShop.Data.Migrations
{
    public partial class GebruikerAfsrpaakUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emailadres",
                table: "Gebruiker");

            migrationBuilder.DropColumn(
                name: "Naam",
                table: "Gebruiker");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Gebruiker",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Nieuwsbrief",
                table: "Gebruiker",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "VoornaamAchternaam",
                table: "Gebruiker",
                maxLength: 100,
                nullable: true);
            
            migrationBuilder.AlterColumn<string>(
                name: "Telefoonnummer",
                table: "Gebruiker",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Gebruiker");

            migrationBuilder.DropColumn(
                name: "Nieuwsbrief",
                table: "Gebruiker");

            migrationBuilder.DropColumn(
                name: "VoornaamAchternaam",
                table: "Gebruiker");

            migrationBuilder.AddColumn<string>(
                name: "Emailadres",
                table: "Gebruiker",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Naam",
                table: "Gebruiker",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Telefoonnummer",
                table: "Gebruiker",
                nullable: false);
        }
    }
}
