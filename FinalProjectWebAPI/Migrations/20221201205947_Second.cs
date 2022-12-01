using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectWebAPI.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Foods",
                newName: "FoodId");

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hobby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Days = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    ShowID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Person = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhereToWatch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seasons = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.ShowID);
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "Id", "Days", "Hobby", "Name", "Reason" },
                values: new object[] { 1, "Everyday", "Studying the bible", "Mo Daniel", "To Know who I am" });

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

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "ShowID", "Person", "Seasons", "ShowsName", "WhereToWatch" },
                values: new object[,]
                {
                    { 1, "Grant Kollar", 23, "South Park", "YouTube TV" },
                    { 2, "Jacob", 3, "The Boys", "Amazon" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.RenameColumn(
                name: "FoodId",
                table: "Foods",
                newName: "Id");
        }
    }
}
