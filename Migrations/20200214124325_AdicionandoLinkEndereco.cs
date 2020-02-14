using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoEvento.Migrations
{
    public partial class AdicionandoLinkEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkEndereco",
                table: "Local",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkEndereco",
                table: "Local");
        }
    }
}
