using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab3.Migrations
{
    /// <inheritdoc />
    public partial class ProgressesCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Progresses_ProgressId",
                table: "Marks");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Progresses_ProgressId",
                table: "Marks",
                column: "ProgressId",
                principalTable: "Progresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Progresses_ProgressId",
                table: "Marks");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Progresses_ProgressId",
                table: "Marks",
                column: "ProgressId",
                principalTable: "Progresses",
                principalColumn: "Id");
        }
    }
}
