using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoEvento.Migrations
{
    public partial class AddVendasDTO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CasaDeShowNome",
                table: "Venda");

            migrationBuilder.AddColumn<int>(
                name: "CasaDeShowId",
                table: "Venda",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venda_CasaDeShowId",
                table: "Venda",
                column: "CasaDeShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Local_CasaDeShowId",
                table: "Venda",
                column: "CasaDeShowId",
                principalTable: "Local",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Local_CasaDeShowId",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_CasaDeShowId",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "CasaDeShowId",
                table: "Venda");

            migrationBuilder.AddColumn<string>(
                name: "CasaDeShowNome",
                table: "Venda",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
