using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelBills.Web.Migrations
{
    public partial class issues2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "TripTypes");

            migrationBuilder.DropColumn(
                name: "TripDetailId",
                table: "TripExpenseTypes");

            migrationBuilder.AddColumn<int>(
                name: "TripTypeId",
                table: "Trips",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripExpenseTypeId",
                table: "TripDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TripTypeId",
                table: "Trips",
                column: "TripTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetails_TripExpenseTypeId",
                table: "TripDetails",
                column: "TripExpenseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripDetails_TripExpenseTypes_TripExpenseTypeId",
                table: "TripDetails",
                column: "TripExpenseTypeId",
                principalTable: "TripExpenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_TripTypes_TripTypeId",
                table: "Trips",
                column: "TripTypeId",
                principalTable: "TripTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripDetails_TripExpenseTypes_TripExpenseTypeId",
                table: "TripDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_TripTypes_TripTypeId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_TripTypeId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_TripDetails_TripExpenseTypeId",
                table: "TripDetails");

            migrationBuilder.DropColumn(
                name: "TripTypeId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "TripExpenseTypeId",
                table: "TripDetails");

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "TripTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripDetailId",
                table: "TripExpenseTypes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TripTypes_TripId",
                table: "TripTypes",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripExpenseTypes_TripDetailId",
                table: "TripExpenseTypes",
                column: "TripDetailId");

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
    }
}
