using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaHotel.Data.Migrations
{
    public partial class logsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1,
                column: "AuthorId",
                value: "8d16b6a1-aa0f-4696-a45f-b1e1fe8ca936");

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "CreatedOn" },
                values: new object[] { "8d16b6a1-aa0f-4696-a45f-b1e1fe8ca936", new DateTime(2019, 5, 21, 12, 50, 44, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "CreatedOn" },
                values: new object[] { "8d16b6a1-aa0f-4696-a45f-b1e1fe8ca936", new DateTime(2019, 5, 22, 7, 0, 43, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "CreatedOn" },
                values: new object[] { "a191788c-7ea2-4249-9f98-f0c89d29d1f9", new DateTime(2019, 5, 19, 19, 51, 11, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AuthorId", "CreatedOn" },
                values: new object[] { "1abe788c-6335-4c2f-b3f9-580542c1558a", new DateTime(2019, 5, 23, 23, 14, 24, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AuthorId", "CreatedOn" },
                values: new object[] { "1abe788c-6335-4c2f-b3f9-580542c1558a", new DateTime(2019, 5, 21, 9, 45, 37, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AuthorId", "CreatedOn" },
                values: new object[] { "a191788c-7ea2-4249-9f98-f0c89d29d1f9", new DateTime(2019, 5, 22, 14, 21, 52, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AuthorId", "CreatedOn" },
                values: new object[] { "5aab304a-4bcb-4d57-87ff-a7df4b0f6b21", new DateTime(2019, 5, 19, 16, 51, 29, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AuthorId", "CreatedOn" },
                values: new object[] { "5aab304a-4bcb-4d57-87ff-a7df4b0f6b21", new DateTime(2019, 5, 22, 20, 2, 48, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1,
                column: "AuthorId",
                value: "45488c85-6e76-4280-9acb-d81be65aca3b");

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "CreatedOn" },
                values: new object[] { "45488c85-6e76-4280-9acb-d81be65aca3b", new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "CreatedOn" },
                values: new object[] { "45488c85-6e76-4280-9acb-d81be65aca3b", new DateTime(2019, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "CreatedOn" },
                values: new object[] { "45488c85-6e76-4280-9acb-d81be65aca3b", new DateTime(2019, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AuthorId", "CreatedOn" },
                values: new object[] { "45488c85-6e76-4280-9acb-d81be65aca3b", new DateTime(2019, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AuthorId", "CreatedOn" },
                values: new object[] { "45488c85-6e76-4280-9acb-d81be65aca3b", new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AuthorId", "CreatedOn" },
                values: new object[] { "45488c85-6e76-4280-9acb-d81be65aca3b", new DateTime(2019, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AuthorId", "CreatedOn" },
                values: new object[] { "45488c85-6e76-4280-9acb-d81be65aca3b", new DateTime(2019, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AuthorId", "CreatedOn" },
                values: new object[] { "45488c85-6e76-4280-9acb-d81be65aca3b", new DateTime(2019, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
