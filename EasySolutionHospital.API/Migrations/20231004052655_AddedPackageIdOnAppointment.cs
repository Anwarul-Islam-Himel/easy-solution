using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySolutionHospital.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedPackageIdOnAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Booking");
        }
    }
}
