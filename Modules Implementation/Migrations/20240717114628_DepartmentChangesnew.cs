using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules_Implementation.Migrations
{
    public partial class DepartmentChangesnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentViewModelDepartmentID",
                table: "SubDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DepartmentViewModel",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentDepartmentID = table.Column<int>(type: "int", nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentLogo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentViewModel", x => x.DepartmentID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubDepartments_DepartmentID",
                table: "SubDepartments",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_SubDepartments_DepartmentViewModelDepartmentID",
                table: "SubDepartments",
                column: "DepartmentViewModelDepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ParentDepartmentID",
                table: "Departments",
                column: "ParentDepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Departments_ParentDepartmentID",
                table: "Departments",
                column: "ParentDepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_SubDepartments_Departments_DepartmentID",
                table: "SubDepartments",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubDepartments_DepartmentViewModel_DepartmentViewModelDepartmentID",
                table: "SubDepartments",
                column: "DepartmentViewModelDepartmentID",
                principalTable: "DepartmentViewModel",
                principalColumn: "DepartmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Departments_ParentDepartmentID",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_SubDepartments_Departments_DepartmentID",
                table: "SubDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_SubDepartments_DepartmentViewModel_DepartmentViewModelDepartmentID",
                table: "SubDepartments");

            migrationBuilder.DropTable(
                name: "DepartmentViewModel");

            migrationBuilder.DropIndex(
                name: "IX_SubDepartments_DepartmentID",
                table: "SubDepartments");

            migrationBuilder.DropIndex(
                name: "IX_SubDepartments_DepartmentViewModelDepartmentID",
                table: "SubDepartments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ParentDepartmentID",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepartmentViewModelDepartmentID",
                table: "SubDepartments");
        }
    }
}
