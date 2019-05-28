using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaHotel.Data.Migrations
{
    public partial class picturePathCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoverPicture", "Location" },
                values: new object[] { "/images/hotelPresentation/hilton-sofia.jpg", "1, Bulgaria Blvd., Sofia 1421, Bulgaria" });

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
                table: "LogBooks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Disco");

            migrationBuilder.UpdateData(
                table: "LogBooks",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Fitness");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoverPicture", "Location" },
                values: new object[] { "~/images/hotelPresentation/hilton-sofia.jpg", "1, Bulgaraa Blvd., Sofia 1421, Bulgaria" });

            migrationBuilder.UpdateData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CoverPicture",
                value: "~/images/hotelPresentation/marinela-sofia.jpg");

            migrationBuilder.UpdateData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CoverPicture",
                value: "~/images/hotelPresentation/metropolitan-hotel-sofia.jpg");

            migrationBuilder.UpdateData(
                table: "LogBooks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Spa");

            migrationBuilder.UpdateData(
                table: "LogBooks",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Spa");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "~/images/hotelPresentation/hilton1.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: "~/images/hotelPresentation/hilton2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 3,
                column: "Location",
                value: "~/images/hotelPresentation/hilton3.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 4,
                column: "Location",
                value: "~/images/hotelPresentation/hilton4.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 5,
                column: "Location",
                value: "~/images/hotelPresentation/marinela1.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 6,
                column: "Location",
                value: "~/images/hotelPresentation/marinela2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 7,
                column: "Location",
                value: "~/images/hotelPresentation/marinela3.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 8,
                column: "Location",
                value: "~/images/hotelPresentation/marinela4.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 9,
                column: "Location",
                value: "~/images/hotelPresentation/metropolitan1.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 10,
                column: "Location",
                value: "~/images/hotelPresentation/metropolitan2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 11,
                column: "Location",
                value: "~/images/hotelPresentation/metropolitan3.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 12,
                column: "Location",
                value: "~/images/hotelPresentation/metropolitan4.jpg");
        }
    }
}
