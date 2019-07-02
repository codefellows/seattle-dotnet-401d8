using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDemo.Migrations
{
    public partial class newCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "Course",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "ID", "CourseCode", "Price", "Technology" },
                values: new object[,]
                {
                    { 1, "401-python", 500m, 3 },
                    { 2, "401-dotnet", 600m, 1 },
                    { 3, "401-java", 600m, 2 },
                    { 4, "201-Fundamentals", 600m, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "Course",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
