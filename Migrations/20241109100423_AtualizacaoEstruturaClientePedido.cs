using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoEstruturaClientePedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_ItemProdutos_ItemProdutoIdItemProduto",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "Vinculas");

            migrationBuilder.DropTable(
                name: "ItemProdutos");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ItemProdutoIdItemProduto",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DataPedido",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ItemProdutoIdItemProduto",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "StatusPedido",
                table: "Clientes");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataPedido = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoModelProdutoModel",
                columns: table => new
                {
                    PedidosIdPedido = table.Column<int>(type: "integer", nullable: false),
                    ProdutosIdProduto = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoModelProdutoModel", x => new { x.PedidosIdPedido, x.ProdutosIdProduto });
                    table.ForeignKey(
                        name: "FK_PedidoModelProdutoModel_Pedidos_PedidosIdPedido",
                        column: x => x.PedidosIdPedido,
                        principalTable: "Pedidos",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoModelProdutoModel_Produtos_ProdutosIdProduto",
                        column: x => x.ProdutosIdProduto,
                        principalTable: "Produtos",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoModelProdutoModel_ProdutosIdProduto",
                table: "PedidoModelProdutoModel",
                column: "ProdutosIdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_StatusId",
                table: "Pedidos",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoModelProdutoModel");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPedido",
                table: "Clientes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ItemProdutoIdItemProduto",
                table: "Clientes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StatusPedido",
                table: "Clientes",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_ItemProdutos_ItemProdutoIdItemProduto",
                table: "Clientes",
                column: "ItemProdutoIdItemProduto",
                principalTable: "ItemProdutos",
                principalColumn: "IdItemProduto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
