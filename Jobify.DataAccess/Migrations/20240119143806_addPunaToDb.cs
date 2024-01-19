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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kerkesat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokacioni = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punet", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Punet",
                columns: new[] { "Id", "Description", "Kerkesat", "Lokacioni", "Name" },
                values: new object[,]
                {
                    { 1, "Fullstack", "Shume", "Prishtine", "Full-Stack" },
                    { 2, "bakcend", "Kogja", "Prishtine", "Backend" },
                    { 3, "devops", "Pak", "Prishtine", "DevOps" }
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
