using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules_Implementation.Migrations
{
    public partial class EmailSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubDepartmentViewModel");

            migrationBuilder.DropTable(
                name: "DepartmentViewModel");

            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reminders");

            migrationBuilder.CreateTable(
                name: "DepartmentViewModel",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentDepartmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentViewModel", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "SubDepartmentViewModel",
                columns: table => new
                {
                    SubDepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    DepartmentViewModelDepartmentID = table.Column<int>(type: "int", nullable: true),
                    SubDepartmentLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubDepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDepartmentViewModel", x => x.SubDepartmentID);
                    table.ForeignKey(
                        name: "FK_SubDepartmentViewModel_DepartmentViewModel_DepartmentViewModelDepartmentID",
                        column: x => x.DepartmentViewModelDepartmentID,
                        principalTable: "DepartmentViewModel",
                        principalColumn: "DepartmentID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubDepartmentViewModel_DepartmentViewModelDepartmentID",
                table: "SubDepartmentViewModel",
                column: "DepartmentViewModelDepartmentID");
        }
    }
}
