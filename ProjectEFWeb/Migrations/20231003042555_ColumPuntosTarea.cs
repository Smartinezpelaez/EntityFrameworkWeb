using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEFWeb.Migrations
{
    /// <inheritdoc />
    public partial class ColumPuntosTarea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Puntos",
                table: "Tarea",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Puntos",
                table: "Tarea");
        }
    }
}
