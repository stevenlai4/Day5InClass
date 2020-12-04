using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Day4InClass.Data.Migrations
{
    public partial class ProdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDos",
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
                    table.PrimaryKey("PK_ToDos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "CreatedOn", "Description", "IsComplete", "Priority" },
                values: new object[] { 1, new DateTime(2020, 12, 3, 12, 3, 46, 650, DateTimeKind.Local).AddTicks(6208), "Bake Cookies", false, 1 });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "CreatedOn", "Description", "IsComplete", "Priority" },
                values: new object[] { 2, new DateTime(2020, 12, 3, 12, 3, 46, 658, DateTimeKind.Local).AddTicks(9653), "Eat the cookies", false, 1 });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "CreatedOn", "Description", "IsComplete", "Priority" },
                values: new object[] { 3, new DateTime(2020, 12, 3, 12, 3, 46, 658, DateTimeKind.Local).AddTicks(9730), "Run around the block", false, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDos");
        }
    }
}
