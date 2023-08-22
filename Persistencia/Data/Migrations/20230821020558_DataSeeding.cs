using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TipoSoftware",
                columns: new[] { "Id", "Tipo" },
                values: new object[,]
                {
                    { 1, "Sistema" },
                    { 2, "Aplicacion" },
                    { 3, "Gestion" },
                    { 4, "Programacion" }
                });

            migrationBuilder.InsertData(
                table: "TiposHardware",
                columns: new[] { "Id", "NombreHardware" },
                values: new object[,]
                {
                    { 1, "Teclado" },
                    { 2, "Mouse" },
                    { 3, "Diadema" },
                    { 4, "Pantalla" },
                    { 5, "CPU" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TipoSoftware",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoSoftware",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoSoftware",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipoSoftware",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TiposHardware",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposHardware",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TiposHardware",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TiposHardware",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TiposHardware",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
