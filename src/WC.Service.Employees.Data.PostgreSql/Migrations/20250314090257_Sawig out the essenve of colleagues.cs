using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WC.Service.Employees.Data.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class Sawigouttheessenveofcolleagues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colleagues");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colleagues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ColleagueEmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colleagues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colleagues_Employees_ColleagueEmployeeId",
                        column: x => x.ColleagueEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Colleagues_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colleagues_ColleagueEmployeeId",
                table: "Colleagues",
                column: "ColleagueEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Colleagues_EmployeeId_ColleagueEmployeeId",
                table: "Colleagues",
                columns: new[] { "EmployeeId", "ColleagueEmployeeId" },
                unique: true);
        }
    }
}
