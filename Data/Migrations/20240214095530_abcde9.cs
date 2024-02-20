using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class abcde9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Location", "Name", "ServiceStartDate" },
                values: new object[,]
                {
                    { 1, "Amman", "JU", new DateTime(1965, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Irbid", "JUST", new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "RoleId", "UniversityId", "UniverstityId" },
                values: new object[,]
                {
                    { 1, "Ali@gmail.com", "Ali", "Yousef", "123", 1, null, 1 },
                    { 2, "Ammar@gmail.com", "Ammar", "Ahmed", "123", 1, null, 1 },
                    { 3, "Hosny@gmail.com", "Hosny", "Tamer", "123", 2, null, 1 },
                    { 4, "Majed@gmail.com", "Majed", "Saed", "123", 1, null, 1 },
                    { 5, "Khaled@gmail.com", "Khaled", "Jaber", "123", 1, null, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
