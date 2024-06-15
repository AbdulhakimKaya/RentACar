using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class slider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 139, 111, 12, 67, 128, 205, 140, 65, 126, 23, 42, 101, 108, 153, 203, 159, 68, 218, 19, 171, 67, 60, 187, 214, 96, 53, 249, 196, 79, 53, 61, 119, 80, 207, 25, 69, 252, 74, 94, 126, 240, 102, 143, 44, 173, 11, 134, 187, 39, 20, 128, 237, 42, 228, 116, 142, 212, 108, 182, 128, 3, 160, 240, 28 }, new byte[] { 244, 119, 188, 205, 188, 71, 165, 243, 150, 210, 195, 48, 223, 204, 44, 18, 162, 243, 74, 119, 168, 183, 187, 144, 10, 8, 41, 244, 8, 20, 76, 181, 59, 251, 225, 127, 207, 180, 228, 122, 6, 183, 160, 178, 53, 100, 195, 214, 112, 84, 114, 188, 205, 108, 96, 168, 212, 75, 130, 111, 4, 177, 24, 2, 9, 134, 68, 102, 137, 9, 230, 52, 71, 158, 225, 193, 71, 20, 99, 30, 0, 233, 155, 86, 126, 45, 249, 133, 29, 240, 155, 148, 19, 246, 0, 216, 149, 213, 199, 250, 36, 204, 80, 108, 175, 255, 31, 67, 143, 137, 51, 230, 120, 91, 137, 0, 200, 87, 99, 105, 194, 50, 159, 192, 214, 125, 47, 55 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 4, 48, 87, 223, 150, 106, 27, 45, 207, 193, 171, 199, 69, 29, 24, 57, 17, 84, 32, 249, 121, 108, 11, 104, 178, 152, 203, 193, 37, 59, 184, 188, 75, 123, 98, 44, 202, 194, 146, 219, 7, 68, 194, 163, 153, 135, 125, 110, 252, 86, 106, 238, 11, 133, 220, 53, 6, 67, 180, 70, 180, 196, 102, 124 }, new byte[] { 251, 30, 40, 104, 66, 4, 180, 77, 96, 226, 71, 238, 205, 205, 205, 150, 133, 200, 248, 36, 139, 11, 83, 123, 242, 227, 157, 31, 36, 240, 239, 104, 29, 53, 67, 126, 77, 52, 197, 23, 116, 156, 165, 91, 81, 248, 2, 180, 255, 92, 81, 230, 96, 80, 185, 199, 194, 13, 163, 23, 122, 99, 210, 70, 23, 146, 235, 117, 140, 208, 10, 51, 101, 28, 71, 142, 206, 191, 151, 140, 46, 35, 85, 88, 145, 124, 102, 0, 200, 229, 99, 31, 172, 169, 118, 179, 176, 47, 205, 173, 141, 223, 15, 18, 242, 76, 72, 30, 61, 1, 11, 184, 152, 169, 181, 37, 152, 45, 194, 220, 195, 213, 249, 17, 208, 92, 96, 99 } });
        }
    }
}
