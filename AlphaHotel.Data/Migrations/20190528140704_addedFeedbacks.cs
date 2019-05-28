using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaHotel.Data.Migrations
{
    public partial class addedFeedbacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "BusinessId", "CreatedOn", "Rate", "Text" },
                values: new object[] { "Peter", 1, new DateTime(2019, 5, 28, 12, 13, 56, 0, DateTimeKind.Unspecified), 5, "I like this hotel!" });

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "BusinessId", "CreatedOn", "Rate", "Text" },
                values: new object[] { "John Wick", 1, new DateTime(2019, 5, 15, 8, 15, 54, 0, DateTimeKind.Unspecified), 5, "My first choice in Bulgaria." });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Author", "BusinessId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Rate", "Text" },
                values: new object[,]
                {
                    { 4, "Ronald", 1, new DateTime(2019, 5, 27, 12, 20, 42, 0, DateTimeKind.Unspecified), null, false, null, 4, "I will be back!" },
                    { 5, null, 2, new DateTime(2019, 5, 22, 13, 51, 34, 0, DateTimeKind.Unspecified), null, false, null, 4, "Perfect disco" },
                    { 6, "Ivan", 2, new DateTime(2019, 5, 24, 12, 31, 35, 0, DateTimeKind.Unspecified), null, false, null, 4, "Nice Hotel. Good service!" },
                    { 7, null, 2, new DateTime(2019, 5, 27, 17, 53, 39, 0, DateTimeKind.Unspecified), null, false, null, 5, "Nice garden." },
                    { 8, "Petar", 2, new DateTime(2019, 5, 28, 17, 2, 17, 0, DateTimeKind.Unspecified), null, false, null, 5, "I like it. One of the best in Bulgaria!" },
                    { 9, "Ivan", 3, new DateTime(2019, 5, 21, 20, 39, 44, 0, DateTimeKind.Unspecified), null, false, null, 4, "Good breakfast" },
                    { 10, "Petar", 3, new DateTime(2019, 5, 14, 22, 51, 54, 0, DateTimeKind.Unspecified), null, false, null, 5, "One of the best hotel in Bulgaria!" },
                    { 11, "John", 3, new DateTime(2019, 5, 27, 17, 53, 39, 0, DateTimeKind.Unspecified), null, false, null, 4, "Nice service. I like the breakfast!" },
                    { 12, "Vasil", 3, new DateTime(2019, 5, 12, 11, 16, 21, 0, DateTimeKind.Unspecified), null, false, null, 4, "Nice and cosy!" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Author", "BusinessId", "CreatedOn", "Rate", "Text" },
                values: new object[] { null, 2, new DateTime(2019, 5, 22, 13, 51, 34, 0, DateTimeKind.Unspecified), 4, "Perfect disco" });

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Author", "BusinessId", "CreatedOn", "Rate", "Text" },
                values: new object[] { "Petar", 3, new DateTime(2019, 5, 21, 20, 39, 44, 0, DateTimeKind.Unspecified), 4, "Good breakfast" });
        }
    }
}
