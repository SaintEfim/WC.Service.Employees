using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WC.Service.Employees.Data.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class Add_new_index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Colleagues_EmployeeId",
                table: "Colleagues");

            migrationBuilder.CreateIndex(
                name: "IX_Colleagues_EmployeeId_ColleagueEmployeeId",
                table: "Colleagues",
                columns: new[] { "EmployeeId", "ColleagueEmployeeId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Colleagues_EmployeeId_ColleagueEmployeeId",
                table: "Colleagues");

            migrationBuilder.CreateIndex(
                name: "IX_Colleagues_EmployeeId",
                table: "Colleagues",
                column: "EmployeeId");
        }
    }
}
