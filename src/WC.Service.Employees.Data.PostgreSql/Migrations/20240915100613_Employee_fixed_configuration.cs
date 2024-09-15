using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WC.Service.Employees.Data.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class Employee_fixed_configuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_PositionId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Colleagues_EmployeeId_ColleagueEmployeeId",
                table: "Colleagues");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Colleagues_EmployeeId",
                table: "Colleagues",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_PositionId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Colleagues_EmployeeId",
                table: "Colleagues");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colleagues_EmployeeId_ColleagueEmployeeId",
                table: "Colleagues",
                columns: new[] { "EmployeeId", "ColleagueEmployeeId" },
                unique: true);
        }
    }
}
