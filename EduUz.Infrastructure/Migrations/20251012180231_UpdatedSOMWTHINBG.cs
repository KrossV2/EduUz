using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduUz.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSOMWTHINBG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Toshkent viloyati");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Toshkent shahri");

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name" },
                values: new object[] { 14, "Toshkent viloyati" });
        }
    }
}
