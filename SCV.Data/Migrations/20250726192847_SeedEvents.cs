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
                    { new Guid("567ab3d2-ef91-4612-9767-969c74efb87e"), "Hands-on technique workshop on snatch and clean & jerk.", 2, "https://dl.dropboxusercontent.com/scl/fi/0vbiwjvllt1ym52m42chh/powerliftingOlympicLifting.jpg?rlkey=ox8cp80m4mck06tpl3i8drsar&st=8tzm76fl", "Sport Center Victory - Ruse", new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olympic Lifting Workshop" },
                    { new Guid("5866069b-fb02-47e9-a5f8-2a76404321f2"), "A weekend retreat focusing on yoga, meditation, and wellness on the beach.", 0, "https://dl.dropboxusercontent.com/scl/fi/jb1xkthdmdc9vcx4mlitd/fitnessYoga.jpg?rlkey=92dq14uikhvk8gorimortf2g1&st=2uwlwv0h", "Sport Center Victory - Ruse", new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yoga Retreat Weekend" },
                    { new Guid("60916c4f-48f8-4b09-ba6c-a3742805e635"), "Try a real CrossFit Open WOD with the community and judges.", 1, "https://dl.dropboxusercontent.com/scl/fi/oqj3jwvapkztafoohivtt/crossFitOpenNight.jpg?rlkey=urnmnhteku1nhhytsxadwepxu&st=r7ft453r", "Sport Center Victory - Ruse", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CrossFit Open Night" },
                    { new Guid("934f5774-f63d-449e-b4bd-50215cb68a9c"), "A local competition for intermediate-level CrossFitters.", 1, "https://dl.dropboxusercontent.com/scl/fi/hld3j69y20yj27jw4dawv/crossFitRegional.jpg?rlkey=k0lbgmtwlngh1th2d6ivbxsk0&st=kncc2ohd", "Sport Center Victory - Ruse", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CrossFit Regional Challenge" },
                    { new Guid("d9f284b3-bbf8-4713-81c9-2fa481818359"), "6-week transformation bootcamp with professional trainers and nutritionists.", 0, "https://dl.dropboxusercontent.com/scl/fi/us2z7n8g4hmye4xa5qqxl/fitnessTransformation.jpg?rlkey=i87hkjeici7r8bg1qjr8xfb37&st=z6a6rgb4", "Sport Center Victory - Ruse", new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fitness Transformation Bootcamp" },
                    { new Guid("f05919a8-b627-4fbe-88a6-ffaeaafd4042"), "Open bench press meet-up for all strength levels.", 2, "https://dl.dropboxusercontent.com/scl/fi/m49eajd8f9ub0x4261v3p/powerliftingBenchpress.png?rlkey=d53a1zlt6m4roq5kltglj30ev&st=9e8qzhd2", "Sport Center Victory - Ruse", new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bench Press Meet-Up" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("567ab3d2-ef91-4612-9767-969c74efb87e"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("5866069b-fb02-47e9-a5f8-2a76404321f2"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("60916c4f-48f8-4b09-ba6c-a3742805e635"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("934f5774-f63d-449e-b4bd-50215cb68a9c"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("d9f284b3-bbf8-4713-81c9-2fa481818359"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("f05919a8-b627-4fbe-88a6-ffaeaafd4042"));
        }
    }
}
