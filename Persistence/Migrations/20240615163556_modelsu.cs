using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modelsu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyPrice",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Models");

            migrationBuilder.AddColumn<decimal>(
                name: "DailyPrice",
                table: "Cars",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 4, 48, 87, 223, 150, 106, 27, 45, 207, 193, 171, 199, 69, 29, 24, 57, 17, 84, 32, 249, 121, 108, 11, 104, 178, 152, 203, 193, 37, 59, 184, 188, 75, 123, 98, 44, 202, 194, 146, 219, 7, 68, 194, 163, 153, 135, 125, 110, 252, 86, 106, 238, 11, 133, 220, 53, 6, 67, 180, 70, 180, 196, 102, 124 }, new byte[] { 251, 30, 40, 104, 66, 4, 180, 77, 96, 226, 71, 238, 205, 205, 205, 150, 133, 200, 248, 36, 139, 11, 83, 123, 242, 227, 157, 31, 36, 240, 239, 104, 29, 53, 67, 126, 77, 52, 197, 23, 116, 156, 165, 91, 81, 248, 2, 180, 255, 92, 81, 230, 96, 80, 185, 199, 194, 13, 163, 23, 122, 99, 210, 70, 23, 146, 235, 117, 140, 208, 10, 51, 101, 28, 71, 142, 206, 191, 151, 140, 46, 35, 85, 88, 145, 124, 102, 0, 200, 229, 99, 31, 172, 169, 118, 179, 176, 47, 205, 173, 141, 223, 15, 18, 242, 76, 72, 30, 61, 1, 11, 184, 152, 169, 181, 37, 152, 45, 194, 220, 195, 213, 249, 17, 208, 92, 96, 99 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyPrice",
                table: "Cars");

            migrationBuilder.AddColumn<decimal>(
                name: "DailyPrice",
                table: "Models",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Models",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 5, 107, 102, 243, 29, 181, 137, 130, 76, 146, 250, 98, 183, 53, 107, 21, 6, 105, 219, 194, 97, 86, 144, 101, 246, 220, 116, 114, 101, 209, 216, 224, 144, 13, 169, 215, 66, 78, 162, 223, 247, 64, 137, 66, 136, 96, 173, 138, 133, 184, 112, 254, 125, 99, 211, 36, 209, 61, 77, 182, 96, 61, 215, 129 }, new byte[] { 158, 190, 157, 244, 221, 187, 166, 238, 30, 57, 144, 30, 103, 74, 175, 52, 238, 196, 196, 159, 51, 125, 43, 181, 142, 171, 49, 145, 210, 207, 168, 61, 66, 232, 53, 201, 65, 95, 181, 114, 187, 106, 34, 142, 195, 219, 112, 193, 166, 155, 202, 250, 50, 15, 231, 49, 238, 156, 69, 190, 180, 228, 97, 106, 104, 218, 247, 11, 182, 237, 135, 121, 185, 18, 169, 235, 219, 227, 154, 191, 151, 108, 54, 150, 243, 124, 149, 84, 142, 69, 57, 106, 94, 83, 69, 241, 222, 241, 102, 155, 123, 176, 218, 24, 253, 123, 193, 177, 70, 132, 179, 231, 86, 12, 73, 210, 171, 1, 14, 113, 142, 38, 179, 207, 228, 120, 138, 51 } });
        }
    }
}
