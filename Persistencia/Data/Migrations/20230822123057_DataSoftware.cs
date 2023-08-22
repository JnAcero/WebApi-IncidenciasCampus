using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSoftware : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Softwares",
                columns: new[] { "Id", "Descripcion", "Nombre", "TipoSofwareId" },
                values: new object[,]
                {
                    { 1, "Framework de Microsoft para desarrollo de microservicios, desarrollo web, entre otros", ".NET Framework", 4 },
                    { 2, "Discord es un servicio de mensajería instantánea y chat de voz VolP. En esta plataforma, los usuarios tienen la capacidad de comunicarse por llamadas de voz, videollamadas, mensajes de texto etc", "Discord", 2 },
                    { 3, "Navegador web", "Chrome", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Softwares",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Softwares",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Softwares",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
