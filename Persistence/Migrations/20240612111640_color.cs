using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class color : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ColorId",
                table: "Models",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 170, 74, 27, 226, 6, 138, 214, 241, 126, 102, 118, 224, 223, 84, 46, 181, 150, 98, 79, 132, 216, 50, 93, 15, 112, 218, 223, 181, 255, 194, 165, 43, 210, 178, 131, 186, 175, 193, 44, 60, 127, 211, 124, 147, 17, 62, 235, 221, 51, 28, 188, 124, 239, 3, 41, 34, 248, 215, 233, 109, 86, 14, 39, 183 }, new byte[] { 64, 19, 167, 145, 231, 141, 235, 211, 19, 57, 74, 1, 248, 76, 174, 49, 56, 230, 2, 209, 125, 40, 28, 109, 140, 103, 172, 132, 192, 137, 83, 80, 56, 129, 89, 39, 114, 160, 181, 161, 29, 244, 104, 62, 122, 10, 93, 88, 44, 249, 111, 57, 200, 65, 96, 139, 249, 88, 146, 35, 33, 48, 4, 224, 20, 153, 255, 189, 250, 234, 66, 67, 150, 187, 253, 85, 60, 132, 228, 203, 137, 60, 199, 126, 206, 217, 207, 151, 242, 17, 83, 191, 227, 60, 104, 149, 172, 53, 40, 241, 150, 130, 210, 190, 253, 212, 86, 86, 203, 21, 48, 90, 75, 208, 16, 57, 9, 211, 226, 23, 47, 193, 34, 240, 180, 54, 254, 162 } });

            migrationBuilder.CreateIndex(
                name: "IX_Models_ColorId",
                table: "Models",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "UK_Colors_Name",
                table: "Colors",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Colors_ColorId",
                table: "Models",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Colors_ColorId",
                table: "Models");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Models_ColorId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Models");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 64, 54, 147, 174, 133, 214, 148, 167, 3, 61, 155, 211, 64, 183, 181, 201, 19, 187, 117, 87, 208, 188, 195, 215, 91, 45, 73, 81, 195, 205, 186, 64, 107, 188, 53, 195, 185, 143, 24, 100, 55, 147, 167, 122, 138, 207, 171, 68, 234, 22, 190, 188, 255, 68, 8, 37, 201, 104, 233, 59, 170, 195, 206, 104 }, new byte[] { 69, 51, 92, 162, 133, 13, 46, 171, 74, 131, 246, 108, 163, 242, 232, 171, 193, 217, 29, 242, 135, 242, 252, 99, 235, 95, 98, 8, 86, 212, 33, 164, 189, 46, 254, 99, 249, 242, 108, 174, 28, 74, 74, 136, 1, 209, 76, 15, 241, 229, 246, 103, 7, 23, 71, 87, 193, 67, 121, 5, 184, 77, 166, 99, 169, 193, 64, 215, 209, 20, 52, 98, 161, 226, 149, 62, 188, 250, 179, 183, 117, 52, 127, 225, 196, 190, 30, 5, 215, 201, 69, 217, 111, 0, 172, 137, 170, 69, 131, 240, 66, 197, 30, 3, 172, 112, 13, 101, 16, 22, 136, 249, 44, 45, 115, 252, 131, 56, 123, 73, 187, 255, 189, 98, 90, 92, 240, 248 } });
        }
    }
}
