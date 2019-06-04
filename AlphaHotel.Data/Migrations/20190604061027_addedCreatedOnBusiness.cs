using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaHotel.Data.Migrations
{
    public partial class addedCreatedOnBusiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Businesses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Businesses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Businesses");
        }
    }
}
