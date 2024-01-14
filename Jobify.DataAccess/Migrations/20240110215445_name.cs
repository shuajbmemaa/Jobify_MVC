using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Emri_Pozites",
                table: "Products",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "siu");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "siau");

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
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Emri_Pozites");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Emri_Pozites",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Emri_Pozites",
                value: null);

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
