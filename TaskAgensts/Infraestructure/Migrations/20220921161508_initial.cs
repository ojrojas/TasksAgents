using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskAgents.Infraestructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NameActivity = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    State = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TypeTaskName = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    State = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TaskName = table.Column<string>(type: "TEXT", nullable: true),
                    TimeTask = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: true),
                    ActivityTaskId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TypeTaskId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AgentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AgentFullName = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    State = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Activities_ActivityTaskId",
                        column: x => x.ActivityTaskId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TypeTasks_TypeTaskId",
                        column: x => x.TypeTaskId,
                        principalTable: "TypeTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ActivityTaskId",
                table: "Tasks",
                column: "ActivityTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TypeTaskId",
                table: "Tasks",
                column: "TypeTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "TypeTasks");
        }
    }
}
