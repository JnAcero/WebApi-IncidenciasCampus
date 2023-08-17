using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Colombia" });

            migrationBuilder.InsertData(
                table: "TiposEmail",
                columns: new[] { "Id", "Tipo" },
                values: new object[,]
                {
                    { 1, "Email Personal" },
                    { 2, "Email Empresarial" }
                });

            migrationBuilder.InsertData(
                table: "TiposTelefono",
                columns: new[] { "Id", "Tipo" },
                values: new object[,]
                {
                    { 1, "Telefono personal" },
                    { 2, "Telefono empresarial" }
                });

            migrationBuilder.InsertData(
                table: "Dptos",
                columns: new[] { "Id", "Nombre", "PaisId" },
                values: new object[] { 1, "Santander", 1 });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "Id", "DptoId", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Bucaramanga" },
                    { 2, 1, "Floridablanca" },
                    { 3, 1, "Giron" },
                    { 4, 1, "Piedecuesta" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ciudades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TiposEmail",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposEmail",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TiposTelefono",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposTelefono",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dptos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
