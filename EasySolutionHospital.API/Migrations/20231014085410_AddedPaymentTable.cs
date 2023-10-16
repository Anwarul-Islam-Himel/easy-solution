using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySolutionHospital.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedPaymentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalReceive",
                table: "Doctor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalPurchase",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentCard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCard", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentCard");

            migrationBuilder.DropColumn(
                name: "TotalReceive",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "TotalPurchase",
                table: "AspNetUsers");
        }
    }
}
