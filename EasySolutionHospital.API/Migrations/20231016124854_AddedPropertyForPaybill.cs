using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySolutionHospital.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedPropertyForPaybill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountPay",
                table: "Package",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPay",
                table: "Booking",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountPay",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "IsPay",
                table: "Booking");
        }
    }
}
