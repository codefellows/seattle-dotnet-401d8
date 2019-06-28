using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace d8EnrollmentDemo.Migrations
{
    public partial class addedSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "Birthdate", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(1975, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jack", "Shepard" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "Birthdate", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(1979, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kate", "Austin" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "Birthdate", "FirstName", "LastName" },
                values: new object[] { 3, new DateTime(1974, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hugo", "Reyes" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
