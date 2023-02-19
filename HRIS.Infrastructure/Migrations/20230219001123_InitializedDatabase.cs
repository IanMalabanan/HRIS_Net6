using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS.Infrastructure.Migrations
{
    public partial class InitializedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentSection",
                columns: table => new
                {
                    DepartmentCode = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentSection", x => new { x.DepartmentCode, x.Code });
                    table.ForeignKey(
                        name: "FK_DepartmentSection_Department_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Department",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmpID = table.Column<int>(type: "int", maxLength: 15, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    DepartmentSectionCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmpID);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Department",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Employee_DepartmentSection_DepartmentCode_DepartmentSectionCode",
                        columns: x => new { x.DepartmentCode, x.DepartmentSectionCode },
                        principalTable: "DepartmentSection",
                        principalColumns: new[] { "DepartmentCode", "Code" });
                });

            migrationBuilder.CreateTable(
                name: "CustomEmployee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefinedEmpID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    EmpID = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomEmployee", x => new { x.ID, x.DefinedEmpID });
                    table.ForeignKey(
                        name: "FK_CustomEmployee_Employee_EmpID",
                        column: x => x.EmpID,
                        principalTable: "Employee",
                        principalColumn: "EmpID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomEmployee_EmpID",
                table: "CustomEmployee",
                column: "EmpID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentCode_DepartmentSectionCode",
                table: "Employee",
                columns: new[] { "DepartmentCode", "DepartmentSectionCode" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomEmployee");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "DepartmentSection");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
