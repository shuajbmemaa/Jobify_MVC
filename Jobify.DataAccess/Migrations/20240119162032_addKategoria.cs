using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addKategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "kategoria",
                table: "Punet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Punet",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Kerkesat", "Lokacioni", "Name", "kategoria" },
                values: new object[] { "Përshkrimi 1", "Kërkesat 1", "Lokacioni 1", "Punë 1", "Administrate" });

            migrationBuilder.UpdateData(
                table: "Punet",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Kerkesat", "Lokacioni", "Name", "kategoria" },
                values: new object[] { "Përshkrimi 2", "Kërkesat 2", "Lokacioni 2", "Punë 2", "Teknologji" });

            migrationBuilder.UpdateData(
                table: "Punet",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Kerkesat", "Lokacioni", "Name", "kategoria" },
                values: new object[] { "Përshkrimi 3", "Kërkesat 3", "Lokacioni 3", "Punë 3", "Biznis" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "kategoria",
                table: "Punet");

            migrationBuilder.UpdateData(
                table: "Punet",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Kerkesat", "Lokacioni", "Name" },
                values: new object[] { "Fullstack", "Shume", "Prishtine", "Full-Stack" });

            migrationBuilder.UpdateData(
                table: "Punet",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Kerkesat", "Lokacioni", "Name" },
                values: new object[] { "bakcend", "Kogja", "Prishtine", "Backend" });

            migrationBuilder.UpdateData(
                table: "Punet",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Kerkesat", "Lokacioni", "Name" },
                values: new object[] { "devops", "Pak", "Prishtine", "DevOps" });
        }
    }
}
