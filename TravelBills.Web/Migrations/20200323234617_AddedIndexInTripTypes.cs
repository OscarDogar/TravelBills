using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelBills.Web.Migrations
{
    public partial class AddedIndexInTripTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TripTypes_Type",
                table: "TripTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TripExpenseTypes_Type",
                table: "TripExpenseTypes",
                column: "Type",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TripTypes_Type",
                table: "TripTypes");

            migrationBuilder.DropIndex(
                name: "IX_TripExpenseTypes_Type",
                table: "TripExpenseTypes");
        }
    }
}
