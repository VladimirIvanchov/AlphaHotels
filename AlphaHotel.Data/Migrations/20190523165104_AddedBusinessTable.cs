using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaHotel.Data.Migrations
{
    public partial class AddedBusinessTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UsersLogbooks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UsersLogbooks",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UsersLogbooks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "UsersLogbooks",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Logs",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Logs",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BusinessId",
                table: "LogBooks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BusinessId",
                table: "Feedbacks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Feedbacks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 15, nullable: false),
                    Location = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogBooks_BusinessId",
                table: "LogBooks",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_BusinessId",
                table: "Feedbacks",
                column: "BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Businesses_BusinessId",
                table: "Feedbacks",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LogBooks_Businesses_BusinessId",
                table: "LogBooks",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Businesses_BusinessId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_LogBooks_Businesses_BusinessId",
                table: "LogBooks");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropIndex(
                name: "IX_LogBooks_BusinessId",
                table: "LogBooks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_BusinessId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UsersLogbooks");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UsersLogbooks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UsersLogbooks");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "UsersLogbooks");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "LogBooks");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Feedbacks");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Logs",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Logs",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 1);
        }
    }
}
