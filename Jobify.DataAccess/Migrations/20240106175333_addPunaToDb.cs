using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jobify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addPunaToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Punet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmriPozites = table.Column<string>(name: "Emri_Pozites", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pershkrimi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Kerkesat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokacioni = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punet", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Punet",
                columns: new[] { "Id", "Emri_Pozites", "Kerkesat", "Lokacioni", "Pershkrimi" },
                values: new object[,]
                {
                    { 1, "Full-Stack", "Kerkesat1", "Prishtine", "edhe back edhe front" },
                    { 2, "Administrata Nate", "Kerkesat2", "Prishtine", "edhessss edhe front" },
                    { 3, "Frontend", "Kerkesat3", "Vushtrri", "eddhe front" },
                    { 4, "Backend", "Kerkesat31", "Prishtine", "edhe back " }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Punet");
        }
    }
}
