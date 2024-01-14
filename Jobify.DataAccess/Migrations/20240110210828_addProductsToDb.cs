using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jobify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addProductsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmriPozites = table.Column<string>(name: "Emri_Pozites", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pershkrimi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Kerkesat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Emri_Pozites", "Kerkesat", "Pershkrimi" },
                values: new object[,]
                {
                    { 1, "siu", "sssa", "ssss" },
                    { 2, "siau", "sss2a", "sssfs" }
                });

            migrationBuilder.UpdateData(
                table: "Punet",
                keyColumn: "Id",
                keyValue: 1,
                column: "Emri_Pozites",
                value: "Full-Stack");

            migrationBuilder.UpdateData(
                table: "Punet",
                keyColumn: "Id",
                keyValue: 2,
                column: "Emri_Pozites",
                value: "Administrata Nate");

            migrationBuilder.UpdateData(
                table: "Punet",
                keyColumn: "Id",
                keyValue: 3,
                column: "Emri_Pozites",
                value: "Frontend");

            migrationBuilder.UpdateData(
                table: "Punet",
                keyColumn: "Id",
                keyValue: 4,
                column: "Emri_Pozites",
                value: "Backend");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.UpdateData(
                table: "Punet",
                keyColumn: "Id",
                keyValue: 1,
                column: "Emri_Pozites",
                value: null);

            migrationBuilder.UpdateData(
                table: "Punet",
                keyColumn: "Id",
                keyValue: 2,
                column: "Emri_Pozites",
                value: null);

            migrationBuilder.UpdateData(
                table: "Punet",
                keyColumn: "Id",
                keyValue: 3,
                column: "Emri_Pozites",
                value: null);

            migrationBuilder.UpdateData(
                table: "Punet",
                keyColumn: "Id",
                keyValue: 4,
                column: "Emri_Pozites",
                value: null);
        }
    }
}
