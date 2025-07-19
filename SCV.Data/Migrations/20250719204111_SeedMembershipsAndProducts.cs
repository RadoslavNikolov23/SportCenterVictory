#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCV.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class SeedMembershipsAndProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "Id", "Description", "Duration", "MembershipTier", "MembershipType", "Name", "Price", "TrainerId" },
                values: new object[,]
                {
                    { 1, "Basic access to gym equipment and cardio area. Includes 1 trainer session/month.", "1 Month", 0, 0, "Fitness Standard", 39.99m, null },
                    { 2, "Unlimited gym access, weekly trainer sessions, workout & meal plan.", "1 Month", 1, 0, "Fitness Premium", 79.99m, null },
                    { 3, "Personalized fitness plan tailored by a dedicated trainer. Includes unlimited sessions and full access.", "1 Month", 2, 0, "Fitness Individual", 99.99m, null },
                    { 4, "Unlimited CrossFit classes, personal monitoring, and competition prep.", "1 Month", 3, 1, "CrossFit Unlimited", 99.99m, null },
                    { 5, "Up to 8 classes a month, perfect for beginners or busy athletes.", "1 Month", 4, 1, "CrossFit Limited", 59.99m, null },
                    { 6, "One-time access to a CrossFit session, no subscription required.", "1 Day", 5, 1, "CrossFit Drop-In", 14.99m, null },
                    { 7, "Introductory strength program, includes 2 trainer sessions/month.", "1 Month", 6, 2, "Powerlifting Beginners", 29.99m, null },
                    { 8, "Intermediate training plan with weekly progress check-ins.", "1 Month", 7, 2, "Powerlifting Intermediates", 49.99m, null },
                    { 9, "Advanced programming with detailed analytics and 24/7 coaching.", "1 Month", 8, 2, "Powerlifting Experts", 69.99m, null },
                    { 10, "Elite-level coaching and competition prep for professional lifters.", "1 Month", 9, 2, "Powerlifting Pros", 99.99m, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "ProductCategory", "Quantity", "Title" },
                values: new object[,]
                {
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0001"), "Brown hoodie for CrossFit training.", "/images/Store/Eqiupment/crossfitHoodie01.jpg", 49.99m, 0, 25, "CrossFit Hoodie" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0002"), "Black hoodie for CrossFit sessions.", "/images/Store/Eqiupment/crossfitHoodie02.jpg", 52.99m, 0, 30, "CrossFit Hoodie" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0003"), "Black t-shirt, CrossFit edition.", "/images/Store/Eqiupment/crossfitShirt01.jpg", 24.99m, 0, 40, "CrossFit Shirt" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0004"), "Dark green CrossFit t-shirt.", "/images/Store/Eqiupment/crossfitShirt02.jpg", 24.99m, 0, 40, "Crossfit Shirt" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0005"), "Pink CrossFit t-shirt for women.", "/images/Store/Eqiupment/crossfitShirt03.jpg", 24.99m, 0, 35, "CrossFit Shirt" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0006"), "Recovery muscle roller for athletes.", "/images/Store/Eqiupment/muscleRoller.jpg", 29.99m, 0, 20, "Muscle Roller" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0007"), "Shaker bottle with Spider-Man face.", "/images/Store/Eqiupment/shaker01.jpg", 14.99m, 0, 50, "Shaker" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0008"), "Shaker bottle with Captain America shield.", "/images/Store/Eqiupment/shaker02.jpg", 14.99m, 0, 50, "Shaker" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0009"), "Sturdy wrist wraps for weightlifting.", "/images/Store/Eqiupment/wristWraps.jpg", 9.99m, 0, 60, "Wrist Wraps" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0010"), "BCAA supplement for muscle recovery - 0.500 grams, mango flavor.", "/images/Store/Nutrition/bcaa.jpg", 14.99m, 1, 40, "BCAA" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0011"), "Creatine monohydrate powder - 0.500grams, unflavour.", "/images/Store/Nutrition/creatine.jpg", 29.99m, 1, 40, "Creatine" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0012"), "Multivitamin tablets for daily wellness - 240 tabblets.", "/images/Store/Nutrition/multivatamins.jpg", 19.99m, 1, 40, "Multivatamins" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0013"), "Pre-workout supplement for energy and focus - 0.400 grams, cola flavor.", "/images/Store/Nutrition/preworkout.jpg", 32.99m, 1, 40, "Preworkout" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0014"), "Omega-3 softgels for heart and joint support - 250 soft gel tables.", "/images/Store/Nutrition/omega.jpg", 22.99m, 1, 40, "Essential Omega" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0015"), "Whey protein powder for muscle growth - 1 kg, chocolate flavor.", "/images/Store/Nutrition/wheyProtein.jpg", 49.99m, 1, 40, "Whey Protein" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0001"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0002"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0003"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0004"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0005"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0006"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0007"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0008"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0009"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0010"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0011"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0012"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0013"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0014"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0015"));
        }
    }
}
