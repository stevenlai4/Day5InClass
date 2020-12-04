using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Day4InClass.Data.Migrations
{
    public partial class ProjectCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedOn", "Description", "IsComplete", "Priority" },
                values: new object[] { 1, new DateTime(2020, 12, 3, 12, 56, 9, 811, DateTimeKind.Local).AddTicks(4443), "Project 1", false, 1 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedOn", "Description", "IsComplete", "Priority" },
                values: new object[] { 2, new DateTime(2020, 12, 3, 12, 56, 9, 820, DateTimeKind.Local).AddTicks(3966), "Project 2", false, 1 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedOn", "Description", "IsComplete", "Priority" },
                values: new object[] { 3, new DateTime(2020, 12, 3, 12, 56, 9, 820, DateTimeKind.Local).AddTicks(4052), "Project 3", false, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
