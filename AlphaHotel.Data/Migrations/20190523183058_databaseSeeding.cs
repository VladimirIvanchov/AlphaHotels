using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaHotel.Data.Migrations
{
    public partial class databaseSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Businesses",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "1, Bulgaraa Blvd., Sofia 1421, Bulgaria", "Hilton Sofia" },
                    { 2, "100, James Bourchier Blvd., Sofia 1407, Bulgaria", "Marinela Sofia" },
                    { 3, "64, Tsarigradsko shosse Blvd., Sofia 1784, Bulgaria", "Metropolitan Hotel" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "TODO" },
                    { 2, "Maintenance" },
                    { 3, "Urgent" },
                    { 4, "Event" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Author", "BusinessId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Rate", "Text" },
                values: new object[,]
                {
                    { 1, "Ivan", 1, new DateTime(2019, 5, 23, 17, 40, 44, 0, DateTimeKind.Unspecified), null, false, null, 5, "One of the best hotels ever!!!" },
                    { 2, null, 2, new DateTime(2019, 5, 22, 13, 51, 34, 0, DateTimeKind.Unspecified), null, false, null, 4, "Perfect disco" },
                    { 3, "Petar", 3, new DateTime(2019, 5, 21, 20, 39, 44, 0, DateTimeKind.Unspecified), null, false, null, 4, "Good breakfast" }
                });

            migrationBuilder.InsertData(
                table: "LogBooks",
                columns: new[] { "Id", "BusinessId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Hotel Part" },
                    { 2, 1, "Restaurant" },
                    { 3, 1, "Spa" },
                    { 4, 2, "Hotel Part" },
                    { 5, 2, "Restaurant" },
                    { 6, 2, "Spa" },
                    { 7, 3, "Hotel Part" },
                    { 8, 3, "Restaurant" },
                    { 9, 3, "Spa" }
                });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedOn", "DeletedOn", "Description", "IsDeleted", "LogBookId", "ModifiedOn", "StatusId" },
                values: new object[,]
                {
                    { 1, "45488c85-6e76-4280-9acb-d81be65aca3b", 1, new DateTime(2019, 5, 23, 17, 40, 44, 0, DateTimeKind.Unspecified), null, "Problem with the toilet in room 405", false, 1, null, 1 },
                    { 2, "45488c85-6e76-4280-9acb-d81be65aca3b", 2, new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Broken chair in the fish part.", false, 2, null, 1 },
                    { 3, "45488c85-6e76-4280-9acb-d81be65aca3b", 3, new DateTime(2019, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Problem with the sauna.", false, 3, null, 2 },
                    { 4, "45488c85-6e76-4280-9acb-d81be65aca3b", 1, new DateTime(2019, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Problem with mirror in room 209", false, 4, null, 1 },
                    { 5, "45488c85-6e76-4280-9acb-d81be65aca3b", 2, new DateTime(2019, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Broken table in the italian part.", false, 5, null, 1 },
                    { 6, "45488c85-6e76-4280-9acb-d81be65aca3b", 3, new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Problem with the jacuzzi.", false, 6, null, 2 },
                    { 7, "45488c85-6e76-4280-9acb-d81be65aca3b", 1, new DateTime(2019, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Problem with the door of room 302", false, 7, null, 1 },
                    { 8, "45488c85-6e76-4280-9acb-d81be65aca3b", 2, new DateTime(2019, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Broken chair in the fish part.", false, 8, null, 1 },
                    { 9, "45488c85-6e76-4280-9acb-d81be65aca3b", 3, new DateTime(2019, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Problem with the sauna.", false, 9, null, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LogBooks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LogBooks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LogBooks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LogBooks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LogBooks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LogBooks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LogBooks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LogBooks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LogBooks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Businesses",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
