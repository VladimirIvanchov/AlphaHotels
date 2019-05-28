using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaHotel.Data.Migrations
{
    public partial class addedShortDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Businesses",
                maxLength: 130,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 1,
                column: "ShortDescription",
                value: "In the heart of Sofia next to South Park shopping & National Palace of Culture (venue for Bulgarian EU Presidency 2018)");

            migrationBuilder.UpdateData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShortDescription",
                value: "The hotel has the largest ballroom and conference hall and a remarkable room on the top floor, with a unique view of Sofia.");

            migrationBuilder.UpdateData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 3,
                column: "ShortDescription",
                value: "Metropolitan Hotel Sofia is the right spot to inspire your business day – 10 fully equipped meeting rooms will host your event.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Businesses");
        }
    }
}
