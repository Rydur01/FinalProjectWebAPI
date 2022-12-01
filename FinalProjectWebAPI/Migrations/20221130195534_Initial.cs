using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectWebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Program = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "Birthday", "Name", "Program", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nathan Burns", "Information Technology", "2nd Year" },
                    { 2, new DateTime(2001, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ryan Durham", "Information Technology", "4th Year" },
                    { 3, new DateTime(2003, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Modupeoluwa Daniel", "Information Technology", "3rd Year" },
                    { 4, new DateTime(2000, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grant Kollar", "Cyber Security", "5th Year" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
