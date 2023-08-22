using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataIncidenciaCat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CategoriasIncidencias",
                columns: new[] { "Id", "Categoria" },
                values: new object[,]
                {
                    { 1, "Software" },
                    { 2, "Hardware" }
                });

            migrationBuilder.InsertData(
                table: "GravedadesIncidencias",
                columns: new[] { "Id", "Gravedad" },
                values: new object[,]
                {
                    { 1, "Leve" },
                    { 2, "Moderada" },
                    { 3, "Grave" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoriasIncidencias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoriasIncidencias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GravedadesIncidencias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GravedadesIncidencias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GravedadesIncidencias",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
