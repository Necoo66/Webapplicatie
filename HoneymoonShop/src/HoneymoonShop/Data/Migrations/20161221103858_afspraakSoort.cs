using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneymoonShop.Data.Migrations
{
    public partial class afspraakSoort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AfspraakSoort",
                table: "Afspraak",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AfspraakSoort",
                table: "Afspraak");
        }
    }
}
