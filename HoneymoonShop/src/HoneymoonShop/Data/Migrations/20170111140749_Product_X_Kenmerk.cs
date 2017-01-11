using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneymoonShop.Data.Migrations
{
    public partial class Product_X_Kenmerk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Kenmerk_KenmerkId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_KenmerkId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "KenmerkId",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "Product_X_Kenmerk",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    KenmerkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_X_Kenmerk", x => new { x.ProductId, x.KenmerkId });
                    table.ForeignKey(
                        name: "FK_Product_X_Kenmerk_Kenmerk_KenmerkId",
                        column: x => x.KenmerkId,
                        principalTable: "Kenmerk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_X_Kenmerk_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_X_Kenmerk_KenmerkId",
                table: "Product_X_Kenmerk",
                column: "KenmerkId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_X_Kenmerk_ProductId",
                table: "Product_X_Kenmerk",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_X_Kenmerk");

            migrationBuilder.AddColumn<int>(
                name: "KenmerkId",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_KenmerkId",
                table: "Product",
                column: "KenmerkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Kenmerk_KenmerkId",
                table: "Product",
                column: "KenmerkId",
                principalTable: "Kenmerk",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
