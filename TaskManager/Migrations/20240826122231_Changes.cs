using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Lists_ListID",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.RenameColumn(
                name: "ListID",
                table: "Tasks",
                newName: "StoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ListID",
                table: "Tasks",
                newName: "IX_Tasks_StoryId");

            migrationBuilder.CreateTable(
                name: "UserStories",
                columns: table => new
                {
                    StoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoryTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStories", x => x.StoryId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_UserStories_StoryId",
                table: "Tasks",
                column: "StoryId",
                principalTable: "UserStories",
                principalColumn: "StoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_UserStories_StoryId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "UserStories");

            migrationBuilder.RenameColumn(
                name: "StoryId",
                table: "Tasks",
                newName: "ListID");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_StoryId",
                table: "Tasks",
                newName: "IX_Tasks_ListID");

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    ListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.ListId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Lists_ListID",
                table: "Tasks",
                column: "ListID",
                principalTable: "Lists",
                principalColumn: "ListId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
