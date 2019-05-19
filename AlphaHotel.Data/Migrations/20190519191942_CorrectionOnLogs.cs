using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaHotel.Data.Migrations
{
    public partial class CorrectionOnLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LogBookId",
                table: "Logs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Logs_LogBookId",
                table: "Logs",
                column: "LogBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_LogBooks_LogBookId",
                table: "Logs",
                column: "LogBookId",
                principalTable: "LogBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_LogBooks_LogBookId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_LogBookId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "LogBookId",
                table: "Logs");
        }
    }
}
