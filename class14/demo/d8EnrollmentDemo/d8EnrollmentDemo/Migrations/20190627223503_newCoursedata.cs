using Microsoft.EntityFrameworkCore.Migrations;

namespace d8EnrollmentDemo.Migrations
{
    public partial class newCoursedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "CourseCode", "Price", "Technology" },
                values: new object[] { 1, "dotnet-is-cool", 50m, 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "CourseCode", "Price", "Technology" },
                values: new object[] { 2, "java is delicious", 75m, 2 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "CourseCode", "Price", "Technology" },
                values: new object[] { 3, "The Scripting in Java is crazy", 100m, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
