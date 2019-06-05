using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaHotel.Data.Migrations
{
    public partial class AddedFeedbackAuthorLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Feedbacks",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CoverPicture",
                value: "hilton-sofia.jpg");

            migrationBuilder.UpdateData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CoverPicture",
                value: "marinela-sofia.jpg");

            migrationBuilder.UpdateData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CoverPicture",
                value: "metropolitan-hotel-sofia.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "hilton1.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: "hilton2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 3,
                column: "Location",
                value: "hilton3.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 4,
                column: "Location",
                value: "hilton4.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 5,
                column: "Location",
                value: "marinela1.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 6,
                column: "Location",
                value: "marinela2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 7,
                column: "Location",
                value: "marinela3.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 8,
                column: "Location",
                value: "marinela4.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 9,
                column: "Location",
                value: "metropolitan1.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 10,
                column: "Location",
                value: "metropolitan2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 11,
                column: "Location",
                value: "metropolitan3.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 12,
                column: "Location",
                value: "metropolitan4.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Feedbacks",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CoverPicture",
                value: "/images/hotelPresentation/hilton-sofia.jpg");

            migrationBuilder.UpdateData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CoverPicture",
                value: "/images/hotelPresentation/marinela-sofia.jpg");

            migrationBuilder.UpdateData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CoverPicture",
                value: "/images/hotelPresentation/metropolitan-hotel-sofia.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "/images/hotelPresentation/hilton1.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: "/images/hotelPresentation/hilton2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 3,
                column: "Location",
                value: "/images/hotelPresentation/hilton3.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 4,
                column: "Location",
                value: "/images/hotelPresentation/hilton4.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 5,
                column: "Location",
                value: "/images/hotelPresentation/marinela1.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 6,
                column: "Location",
                value: "/images/hotelPresentation/marinela2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 7,
                column: "Location",
                value: "/images/hotelPresentation/marinela3.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 8,
                column: "Location",
                value: "/images/hotelPresentation/marinela4.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 9,
                column: "Location",
                value: "/images/hotelPresentation/metropolitan1.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 10,
                column: "Location",
                value: "/images/hotelPresentation/metropolitan2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 11,
                column: "Location",
                value: "/images/hotelPresentation/metropolitan3.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 12,
                column: "Location",
                value: "/images/hotelPresentation/metropolitan4.jpg");
        }
    }
}
