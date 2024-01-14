using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addImageUrlToPuna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Punet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Punet",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Emri_Pozites", "ImageUrl" },
                values: new object[] { "Full-Stack", "" });

            migrationBuilder.UpdateData(
                table: "Punet",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Emri_Pozites", "ImageUrl" },
                values: new object[] { "Administrata Nate", "" });

            migrationBuilder.UpdateData(
                table: "Punet",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Emri_Pozites", "ImageUrl" },
                values: new object[] { "Frontend", "" });

            migrationBuilder.UpdateData(
                table: "Punet",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Emri_Pozites", "ImageUrl" },
                values: new object[] { "Backend", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Punet");

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
