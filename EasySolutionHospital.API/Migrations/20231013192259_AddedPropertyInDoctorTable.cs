using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySolutionHospital.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedPropertyInDoctorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConsultingTime",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeeAmount",
                table: "Doctor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomNumber",
                table: "Doctor",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsultingTime",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "FeeAmount",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "Doctor");
        }
    }
}
