using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Repository.EfCore.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { 1, false, "IT" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { 2, false, "HR" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { 3, false, "Audit" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "DeletedDate", "DepartmentId", "IsDeleted", "LastModifiedDate", "Name", "Surname" },
                values: new object[] { 1, new DateTime(1996, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, false, null, "Ramil", "Aliyev" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "DeletedDate", "DepartmentId", "IsDeleted", "LastModifiedDate", "Name", "Surname" },
                values: new object[] { 2, new DateTime(1995, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, false, null, "Kanan", "Mammadov" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "DeletedDate", "DepartmentId", "IsDeleted", "LastModifiedDate", "Name", "Surname" },
                values: new object[] { 3, new DateTime(1993, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, false, null, "Yusif", "Karimli" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
