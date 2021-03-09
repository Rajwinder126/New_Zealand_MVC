using Microsoft.EntityFrameworkCore.Migrations;

namespace New_Zealand_MVC.Migrations
{
    public partial class New_Zealand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Famous_Hotel_Famous_HotelId",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "Famous_HotelId",
                table: "Booking",
                newName: "HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_Famous_HotelId",
                table: "Booking",
                newName: "IX_Booking_HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Famous_Hotel_HotelId",
                table: "Booking",
                column: "HotelId",
                principalTable: "Famous_Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Famous_Hotel_HotelId",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "Booking",
                newName: "Famous_HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_HotelId",
                table: "Booking",
                newName: "IX_Booking_Famous_HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Famous_Hotel_Famous_HotelId",
                table: "Booking",
                column: "Famous_HotelId",
                principalTable: "Famous_Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
