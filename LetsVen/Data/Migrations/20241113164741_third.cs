using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetsVen.Data.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adventure_AspNetUsers_UserId",
                table: "Adventure");

            migrationBuilder.DropForeignKey(
                name: "FK_AdventureImages_Adventure_AdventureId",
                table: "AdventureImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_AspNetUsers_UserId",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdventureImages",
                table: "AdventureImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adventure",
                table: "Adventure");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "bookings");

            migrationBuilder.RenameTable(
                name: "AdventureImages",
                newName: "images");

            migrationBuilder.RenameTable(
                name: "Adventure",
                newName: "adventures");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_UserId",
                table: "bookings",
                newName: "IX_bookings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AdventureImages_AdventureId",
                table: "images",
                newName: "IX_images_AdventureId");

            migrationBuilder.RenameIndex(
                name: "IX_Adventure_UserId",
                table: "adventures",
                newName: "IX_adventures_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookings",
                table: "bookings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_images",
                table: "images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_adventures",
                table: "adventures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_adventures_AspNetUsers_UserId",
                table: "adventures",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_AspNetUsers_UserId",
                table: "bookings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_images_adventures_AdventureId",
                table: "images",
                column: "AdventureId",
                principalTable: "adventures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_adventures_AspNetUsers_UserId",
                table: "adventures");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_AspNetUsers_UserId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_images_adventures_AdventureId",
                table: "images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_images",
                table: "images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookings",
                table: "bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_adventures",
                table: "adventures");

            migrationBuilder.RenameTable(
                name: "images",
                newName: "AdventureImages");

            migrationBuilder.RenameTable(
                name: "bookings",
                newName: "Booking");

            migrationBuilder.RenameTable(
                name: "adventures",
                newName: "Adventure");

            migrationBuilder.RenameIndex(
                name: "IX_images_AdventureId",
                table: "AdventureImages",
                newName: "IX_AdventureImages_AdventureId");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_UserId",
                table: "Booking",
                newName: "IX_Booking_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_adventures_UserId",
                table: "Adventure",
                newName: "IX_Adventure_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdventureImages",
                table: "AdventureImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adventure",
                table: "Adventure",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Adventure_AspNetUsers_UserId",
                table: "Adventure",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdventureImages_Adventure_AdventureId",
                table: "AdventureImages",
                column: "AdventureId",
                principalTable: "Adventure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_AspNetUsers_UserId",
                table: "Booking",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
