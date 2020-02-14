using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoEvento.Migrations
{
    public partial class AlterandoLocalEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Local",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Evento",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Local");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Evento");
        }
    }
}
