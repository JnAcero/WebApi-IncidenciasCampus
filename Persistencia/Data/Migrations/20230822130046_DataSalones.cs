using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSalones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Salones",
                columns: new[] { "Id", "AreaId", "CantidadEquipos", "NombreSalon" },
                values: new object[,]
                {
                    { 1, 3, 25, "Apolo" },
                    { 2, 3, 25, "Sputnik" },
                    { 3, 3, 25, "Artemis" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Salones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Salones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Salones",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
