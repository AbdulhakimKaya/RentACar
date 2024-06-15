using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class color_refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Colors_ColorId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_ColorId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Models");

            migrationBuilder.AddColumn<Guid>(
                name: "ColorId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 5, 107, 102, 243, 29, 181, 137, 130, 76, 146, 250, 98, 183, 53, 107, 21, 6, 105, 219, 194, 97, 86, 144, 101, 246, 220, 116, 114, 101, 209, 216, 224, 144, 13, 169, 215, 66, 78, 162, 223, 247, 64, 137, 66, 136, 96, 173, 138, 133, 184, 112, 254, 125, 99, 211, 36, 209, 61, 77, 182, 96, 61, 215, 129 }, new byte[] { 158, 190, 157, 244, 221, 187, 166, 238, 30, 57, 144, 30, 103, 74, 175, 52, 238, 196, 196, 159, 51, 125, 43, 181, 142, 171, 49, 145, 210, 207, 168, 61, 66, 232, 53, 201, 65, 95, 181, 114, 187, 106, 34, 142, 195, 219, 112, 193, 166, 155, 202, 250, 50, 15, 231, 49, 238, 156, 69, 190, 180, 228, 97, 106, 104, 218, 247, 11, 182, 237, 135, 121, 185, 18, 169, 235, 219, 227, 154, 191, 151, 108, 54, 150, 243, 124, 149, 84, 142, 69, 57, 106, 94, 83, 69, 241, 222, 241, 102, 155, 123, 176, 218, 24, 253, 123, 193, 177, 70, 132, 179, 231, 86, 12, 73, 210, 171, 1, 14, 113, 142, 38, 179, 207, 228, 120, 138, 51 } });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ColorId",
                table: "Cars",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Colors_ColorId",
                table: "Cars",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Colors_ColorId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ColorId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Cars");

            migrationBuilder.AddColumn<Guid>(
                name: "ColorId",
                table: "Models",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 133, 63, 241, 252, 201, 115, 184, 100, 146, 79, 66, 44, 86, 82, 24, 136, 108, 77, 4, 245, 42, 202, 250, 179, 78, 123, 161, 152, 188, 232, 112, 3, 1, 118, 250, 26, 212, 36, 153, 56, 92, 240, 60, 168, 8, 182, 209, 23, 107, 51, 213, 32, 206, 185, 253, 52, 233, 130, 59, 190, 241, 178, 36, 222 }, new byte[] { 119, 193, 150, 143, 237, 223, 65, 47, 239, 43, 110, 171, 82, 144, 28, 253, 50, 209, 158, 247, 237, 231, 116, 45, 247, 225, 219, 86, 94, 123, 16, 237, 174, 251, 66, 128, 151, 117, 69, 240, 48, 104, 251, 149, 127, 66, 160, 119, 56, 54, 154, 22, 163, 138, 155, 21, 196, 193, 105, 127, 163, 237, 247, 49, 252, 90, 35, 58, 210, 181, 84, 135, 220, 59, 107, 30, 39, 163, 63, 115, 184, 99, 150, 134, 145, 177, 109, 101, 98, 227, 233, 150, 78, 23, 148, 51, 248, 113, 193, 201, 247, 95, 249, 218, 191, 204, 20, 213, 6, 230, 127, 163, 174, 218, 18, 8, 179, 179, 63, 120, 155, 90, 51, 142, 141, 185, 16, 181 } });

            migrationBuilder.CreateIndex(
                name: "IX_Models_ColorId",
                table: "Models",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Colors_ColorId",
                table: "Models",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
