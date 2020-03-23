using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelBills.Web.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalExpense",
                table: "Trips");

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "TripTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripDetailId",
                table: "TripExpenseTypes",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "BillValue",
                table: "TripDetails",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "TripDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TripTypes_TripId",
                table: "TripTypes",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripExpenseTypes_TripDetailId",
                table: "TripExpenseTypes",
                column: "TripDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetails_TripId",
                table: "TripDetails",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripDetails_Trips_TripId",
                table: "TripDetails",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TripExpenseTypes_TripDetails_TripDetailId",
                table: "TripExpenseTypes",
                column: "TripDetailId",
                principalTable: "TripDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TripTypes_Trips_TripId",
                table: "TripTypes",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripDetails_Trips_TripId",
                table: "TripDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TripExpenseTypes_TripDetails_TripDetailId",
                table: "TripExpenseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_TripTypes_Trips_TripId",
                table: "TripTypes");

            migrationBuilder.DropIndex(
                name: "IX_TripTypes_TripId",
                table: "TripTypes");

            migrationBuilder.DropIndex(
                name: "IX_TripExpenseTypes_TripDetailId",
                table: "TripExpenseTypes");

            migrationBuilder.DropIndex(
                name: "IX_TripDetails_TripId",
                table: "TripDetails");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "TripTypes");

            migrationBuilder.DropColumn(
                name: "TripDetailId",
                table: "TripExpenseTypes");

            migrationBuilder.DropColumn(
                name: "BillValue",
                table: "TripDetails");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "TripDetails");

            migrationBuilder.AddColumn<float>(
                name: "TotalExpense",
                table: "Trips",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
