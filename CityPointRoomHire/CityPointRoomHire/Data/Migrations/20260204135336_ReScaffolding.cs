using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityPointRoomHire.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReScaffolding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Venue",
                newName: "VenueId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Booking",
                newName: "BookingId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_VenueId",
                table: "Booking",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Venue_VenueId",
                table: "Booking",
                column: "VenueId",
                principalTable: "Venue",
                principalColumn: "VenueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Venue_VenueId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_VenueId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "VenueId",
                table: "Venue",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Booking",
                newName: "Id");
        }
    }
}
