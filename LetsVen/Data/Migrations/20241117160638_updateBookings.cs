using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetsVen.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateBookings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdventureId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AdventureId",
                table: "Bookings",
                column: "AdventureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Adventures_AdventureId",
                table: "Bookings",
                column: "AdventureId",
                principalTable: "Adventures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Adventures_AdventureId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_AdventureId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "AdventureId",
                table: "Bookings");
        }
    }
}
