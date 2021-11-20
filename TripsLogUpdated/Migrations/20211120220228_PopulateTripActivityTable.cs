using Microsoft.EntityFrameworkCore.Migrations;

namespace TripsLogUpdated.Migrations
{
    public partial class PopulateTripActivityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TripActivities",
                columns: new[] { "TripId", "ActivityId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TripActivities",
                keyColumns: new[] { "TripId", "ActivityId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TripActivities",
                keyColumns: new[] { "TripId", "ActivityId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "TripActivities",
                keyColumns: new[] { "TripId", "ActivityId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "TripActivities",
                keyColumns: new[] { "TripId", "ActivityId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "TripActivities",
                keyColumns: new[] { "TripId", "ActivityId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "TripActivities",
                keyColumns: new[] { "TripId", "ActivityId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "TripActivities",
                keyColumns: new[] { "TripId", "ActivityId" },
                keyValues: new object[] { 3, 7 });
        }
    }
}
