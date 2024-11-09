using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Status_StatusId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.RenameTable(
                name: "Status",
                newName: "Statuses");

            migrationBuilder.AddColumn<string>(
                name: "NomeStatus",
                table: "Statuses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "IdStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Statuses_StatusId",
                table: "Pedidos",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "IdStatus",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Statuses_StatusId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "NomeStatus",
                table: "Statuses");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Status",
                column: "IdStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Status_StatusId",
                table: "Pedidos",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "IdStatus",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
