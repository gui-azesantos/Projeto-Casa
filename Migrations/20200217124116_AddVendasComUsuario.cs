using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoEvento.Migrations
{
    public partial class AddVendasComUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "Venda",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Venda");
        }
    }
}
