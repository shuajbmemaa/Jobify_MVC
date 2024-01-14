using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addForeignKEy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PunaId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "PunaId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "PunaId",
                value: 1);

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_PunaId",
                table: "Products",
                column: "PunaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Punet_PunaId",
                table: "Products",
                column: "PunaId",
                principalTable: "Punet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Punet_PunaId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PunaId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PunaId",
                table: "Products");

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
