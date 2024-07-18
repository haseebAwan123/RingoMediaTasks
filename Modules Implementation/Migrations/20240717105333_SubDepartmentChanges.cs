using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules_Implementation.Migrations
{
    public partial class SubDepartmentChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubDepartments_Departments_DepartmentsDepartmentID",
                table: "SubDepartments");

            migrationBuilder.DropIndex(
                name: "IX_SubDepartments_DepartmentsDepartmentID",
                table: "SubDepartments");

            migrationBuilder.DropColumn(
                name: "DepartmentsDepartmentID",
                table: "SubDepartments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentsDepartmentID",
                table: "SubDepartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubDepartments_DepartmentsDepartmentID",
                table: "SubDepartments",
                column: "DepartmentsDepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_SubDepartments_Departments_DepartmentsDepartmentID",
                table: "SubDepartments",
                column: "DepartmentsDepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
