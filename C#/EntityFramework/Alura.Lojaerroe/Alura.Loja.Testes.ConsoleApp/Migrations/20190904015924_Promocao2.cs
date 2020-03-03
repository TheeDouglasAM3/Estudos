using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.Loja.Testes.ConsoleApp.Migrations
{
    public partial class Promocao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Promocoes_PromocaoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_PromocaoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PromocaoId",
                table: "Produtos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PromocaoId",
                table: "Produtos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_PromocaoId",
                table: "Produtos",
                column: "PromocaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Promocoes_PromocaoId",
                table: "Produtos",
                column: "PromocaoId",
                principalTable: "Promocoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
