#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCV.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class SeedEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EventType", "ImageUrl", "Location", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, "6-week transformation bootcamp with professional trainers and nutritionists.", 0, "/events/fitnessTransformation.jpg", "Sport Center Victory - Ruse", new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fitness Transformation Bootcamp" },
                    { 2, "A weekend retreat focusing on yoga, meditation, and wellness on the beach.", 0, "/events/fitnessYoga.jpg", "Sport Center Victory - Ruse", new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yoga Retreat Weekend" },
                    { 3, "A local competition for intermediate-level CrossFitters.", 1, "/events/crossFitRegional.jpg", "Sport Center Victory - Ruse", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CrossFit Regional Challenge" },
                    { 4, "Try a real CrossFit Open WOD with the community and judges.", 1, "/events/crossFitOpenNight.jpg", "Sport Center Victory - Ruse", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CrossFit Open Night" },
                    { 5, "Open bench press meet-up for all strength levels.", 2, "/events/powerliftingBenchpress.png", "Sport Center Victory - Ruse", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bench Press Meet-Up" },
                    { 6, "Hands-on technique workshop on snatch and clean & jerk.", 2, "/events/powerliftingOlympicLifting.jpg", "Sport Center Victory - Ruse", new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olympic Lifting Workshop" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
