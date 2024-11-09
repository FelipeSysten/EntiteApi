using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemProdutos",
                columns: table => new
                {
                    IdItemProduto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemQuantidade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemProdutos", x => x.IdItemProduto);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeProduto = table.Column<string>(type: "text", nullable: false),
                    TipoProduto = table.Column<string>(type: "text", nullable: false),
                    ValorProduto = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.IdProduto);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeCliente = table.Column<string>(type: "text", nullable: false),
                    EmailCliente = table.Column<string>(type: "text", nullable: false),
                    NumeroCliente = table.Column<string>(type: "text", nullable: false),
                    DataNascimentoCliente = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StatusPedido = table.Column<string>(type: "text", nullable: false),
                    ItemProdutoIdItemProduto = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_ItemProdutos_ItemProdutoIdItemProduto",
                        column: x => x.ItemProdutoIdItemProduto,
                        principalTable: "ItemProdutos",
                        principalColumn: "IdItemProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vinculas",
                columns: table => new
                {
                    IdItemProduto = table.Column<int>(type: "integer", nullable: false),
                    IdProduto = table.Column<int>(type: "integer", nullable: false),
                    ProdutoIdProduto = table.Column<int>(type: "integer", nullable: false),
                    ItemProdutoModelIdItemProduto = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vinculas", x => new { x.IdItemProduto, x.IdProduto });
                    table.ForeignKey(
                        name: "FK_Vinculas_ItemProdutos_ItemProdutoModelIdItemProduto",
                        column: x => x.ItemProdutoModelIdItemProduto,
                        principalTable: "ItemProdutos",
                        principalColumn: "IdItemProduto");
                    table.ForeignKey(
                        name: "FK_Vinculas_Produtos_ProdutoIdProduto",
                        column: x => x.ProdutoIdProduto,
                        principalTable: "Produtos",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ItemProdutoIdItemProduto",
                table: "Clientes",
                column: "ItemProdutoIdItemProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Vinculas_ItemProdutoModelIdItemProduto",
                table: "Vinculas",
                column: "ItemProdutoModelIdItemProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Vinculas_ProdutoIdProduto",
                table: "Vinculas",
                column: "ProdutoIdProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Vinculas");

            migrationBuilder.DropTable(
                name: "ItemProdutos");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
