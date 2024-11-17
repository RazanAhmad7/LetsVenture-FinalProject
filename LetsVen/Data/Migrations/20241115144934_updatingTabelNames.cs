using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetsVen.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatingTabelNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "Images");

            migrationBuilder.RenameTable(
                name: "bookings",
                newName: "Bookings");

            migrationBuilder.RenameTable(
                name: "adventures",
                newName: "Adventures");

            migrationBuilder.RenameIndex(
                name: "IX_images_AdventureId",
                table: "Images",
                newName: "IX_Images_AdventureId");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_UserId",
                table: "Bookings",
                newName: "IX_Bookings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_adventures_UserId",
                table: "Adventures",
                newName: "IX_Adventures_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adventures",
                table: "Adventures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Adventures_AspNetUsers_UserId",
                table: "Adventures",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Adventures_AdventureId",
                table: "Images",
                column: "AdventureId",
                principalTable: "Adventures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adventures_AspNetUsers_UserId",
                table: "Adventures");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Adventures_AdventureId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adventures",
                table: "Adventures");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "images");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "bookings");

            migrationBuilder.RenameTable(
                name: "Adventures",
                newName: "adventures");

            migrationBuilder.RenameIndex(
                name: "IX_Images_AdventureId",
                table: "images",
                newName: "IX_images_AdventureId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_UserId",
                table: "bookings",
                newName: "IX_bookings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Adventures_UserId",
                table: "adventures",
                newName: "IX_adventures_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_images",
                table: "images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookings",
                table: "bookings",
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
    }
}
