using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneymoonShop.Data.Migrations
{
    public partial class SoortAfspraakToegevoegd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AfspraakSoort",
                table: "Afspraak"

            );
            migrationBuilder.AddColumn<int>(
            name:"AfspraakSoort",
            table: "Afspraak",
            nullable: false,
            defaultValue:0
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
