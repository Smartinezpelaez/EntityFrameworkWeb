using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectEFWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("636ab663-4d46-4b0d-99c7-17396bd1ba01"), null, "Actividaes pendientes", 20 },
                    { new Guid("636ab663-4d46-4b0d-99c7-17396bd1ba02"), null, "Actividaes personales", 50 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Puntos", "Titulo" },
                values: new object[,]
                {
                    { new Guid("636ab663-4d46-4b0d-99c7-17396bd1ba10"), new Guid("636ab663-4d46-4b0d-99c7-17396bd1ba01"), null, new DateTime(2023, 10, 2, 23, 54, 34, 104, DateTimeKind.Local).AddTicks(192), 1, 5, "Pago servicios publicos" },
                    { new Guid("636ab663-4d46-4b0d-99c7-17396bd1ba11"), new Guid("636ab663-4d46-4b0d-99c7-17396bd1ba02"), null, new DateTime(2023, 10, 2, 23, 54, 34, 104, DateTimeKind.Local).AddTicks(209), 0, 2, "Terminar de ver pelicula" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("636ab663-4d46-4b0d-99c7-17396bd1ba10"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("636ab663-4d46-4b0d-99c7-17396bd1ba11"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("636ab663-4d46-4b0d-99c7-17396bd1ba01"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("636ab663-4d46-4b0d-99c7-17396bd1ba02"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
