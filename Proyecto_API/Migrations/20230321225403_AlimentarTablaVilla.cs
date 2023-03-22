using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Proyecto_API.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTablaVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreateDate", "Detail", "Fee", "Name", "Occupants", "SquareMeter", "UpdateDate", "UrlImage" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2023, 3, 21, 17, 54, 2, 877, DateTimeKind.Local).AddTicks(4444), "Detail of the village...", 100.0, "Villa Real", 2, 100, new DateTime(2023, 3, 21, 17, 54, 2, 877, DateTimeKind.Local).AddTicks(4466), "" },
                    { 2, 0, new DateTime(2023, 3, 21, 17, 54, 2, 877, DateTimeKind.Local).AddTicks(4469), "Detail of the village Juancho...", 200.0, "Villa Juancho", 4, 200, new DateTime(2023, 3, 21, 17, 54, 2, 877, DateTimeKind.Local).AddTicks(4470), "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
