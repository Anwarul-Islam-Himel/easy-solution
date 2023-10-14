using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySolutionHospital.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDoctorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Doctor",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Doctor");
        }
    }
}
