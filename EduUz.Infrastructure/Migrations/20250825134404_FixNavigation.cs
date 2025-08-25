using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduUz.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directors_Users_UserId1",
                table: "Directors");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Users_UserId1",
                table: "Parents");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserId1",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Users_UserId1",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_UserId1",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Parents_UserId1",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Directors_UserId1",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Directors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Teachers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Students",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Parents",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Directors",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId1",
                table: "Teachers",
                column: "UserId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId1",
                table: "Students",
                column: "UserId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parents_UserId1",
                table: "Parents",
                column: "UserId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Directors_UserId1",
                table: "Directors",
                column: "UserId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Directors_Users_UserId1",
                table: "Directors",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Users_UserId1",
                table: "Parents",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserId1",
                table: "Students",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Users_UserId1",
                table: "Teachers",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
