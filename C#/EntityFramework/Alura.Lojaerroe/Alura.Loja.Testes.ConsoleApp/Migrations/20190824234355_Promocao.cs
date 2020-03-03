using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Alura.Loja.Testes.ConsoleApp.Migrations
{
    public partial class Promocao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PromocaoId",
                table: "Produtos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Promocoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataTermino = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromocaoProduto",
                columns: table => new
                {
                    IdPromocao = table.Column<int>(nullable: false),
                    IdProduto = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: true),
                    PromocaoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromocaoProduto", x => new { x.IdPromocao, x.IdProduto });
                    table.ForeignKey(
                        name: "FK_PromocaoProduto_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PromocaoProduto_Promocoes_PromocaoId",
                        column: x => x.PromocaoId,
                        principalTable: "Promocoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_PromocaoId",
                table: "Produtos",
                column: "PromocaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PromocaoProduto_ProdutoId",
                table: "PromocaoProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_PromocaoProduto_PromocaoId",
                table: "PromocaoProduto",
                column: "PromocaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Promocoes_PromocaoId",
                table: "Produtos",
                column: "PromocaoId",
                principalTable: "Promocoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Promocoes_PromocaoId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "PromocaoProduto");

            migrationBuilder.DropTable(
                name: "Promocoes");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_PromocaoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PromocaoId",
                table: "Produtos");
        }
    }
}
