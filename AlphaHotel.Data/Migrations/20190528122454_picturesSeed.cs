using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaHotel.Data.Migrations
{
    public partial class picturesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Pictures",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "BusinessId", "DeletedOn", "IsDeleted", "Location" },
                values: new object[,]
                {
                    { 1, 1, null, false, "~/images/hotelPresentation/hilton1.jpg" },
                    { 2, 1, null, false, "~/images/hotelPresentation/hilton2.jpg" },
                    { 3, 1, null, false, "~/images/hotelPresentation/hilton3.jpg" },
                    { 4, 1, null, false, "~/images/hotelPresentation/hilton4.jpg" },
                    { 5, 2, null, false, "~/images/hotelPresentation/marinela1.jpg" },
                    { 6, 2, null, false, "~/images/hotelPresentation/marinela2.jpg" },
                    { 7, 2, null, false, "~/images/hotelPresentation/marinela3.jpg" },
                    { 8, 2, null, false, "~/images/hotelPresentation/marinela4.jpg" },
                    { 9, 3, null, false, "~/images/hotelPresentation/metropolitan1.jpg" },
                    { 10, 3, null, false, "~/images/hotelPresentation/metropolitan2.jpg" },
                    { 11, 3, null, false, "~/images/hotelPresentation/metropolitan3.jpg" },
                    { 12, 3, null, false, "~/images/hotelPresentation/metropolitan4.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Pictures",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80);
        }
    }
}
