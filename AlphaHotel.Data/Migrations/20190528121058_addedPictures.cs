using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaHotel.Data.Migrations
{
    public partial class addedPictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Businesses",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoverPicture",
                table: "Businesses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(nullable: true),
                    BusinessId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Picture_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "About", "CoverPicture" },
                values: new object[] { "Welcome to the Hilton Sofia in the heart of the Bulgarian capital. You’ll appreciate the stunning backdrop of the Vitosha Mountain and our central location opposite Sofia Congress Center. Whether you’re here on business or leisure, you’ll find all the first-class amenities you need for a successful stay. Get to work in our meeting rooms or business center or escape it all with a trip to our spa.", "~/images/hotelPresentation/hilton-sofia.jpg" });

            migrationBuilder.UpdateData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "About", "CoverPicture" },
                values: new object[] { "Five Star Marinela Hotel Sofia has been designed by the renowned Japanese architect Kisho Kurokawa, the author of a number of world landmarks. The hotel is located on an area of ​​30,000 square meters, there are 442 rooms and suites, including the largest Presidential Suite in Bulgaria. The Hotel Marinela can satisfy the most discerning tastes and needs.", "~/images/hotelPresentation/marinela-sofia.jpg" });

            migrationBuilder.UpdateData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "About", "CoverPicture" },
                values: new object[] { "A stylish urban hotel with unconventional design welcomes you at the eastern gate of the capital city of Bulgaria, Sofia. Metropolitan Hotel Sofia is strategically located close to Sofia Airport, Business Park Sofia, Megapark, European Trade Center, Capital Fort,  Shopping center “The Mall” and International Expo Center.", "~/images/hotelPresentation/metropolitan-hotel-sofia.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_Picture_BusinessId",
                table: "Picture",
                column: "BusinessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropColumn(
                name: "About",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "CoverPicture",
                table: "Businesses");
        }
    }
}
