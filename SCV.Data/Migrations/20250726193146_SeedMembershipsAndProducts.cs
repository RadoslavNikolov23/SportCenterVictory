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
                columns: new[] { "Id", "Description", "Duration", "MembershipType", "Name", "Price", "TrainerId" },
                values: new object[,]
                {
                    { new Guid("0084ce57-2ad8-4de2-840b-d8e6d4dc1570"), "Advanced programming with detailed analytics and 24/7 coaching.", "1 Month", 2, "Powerlifting Experts", 69.99m, null },
                    { new Guid("1b961d8a-defd-426f-9d3d-2383b51400ef"), "Up to 8 classes a month, perfect for beginners or busy athletes.", "1 Month", 1, "CrossFit Limited", 59.99m, null },
                    { new Guid("370f11b9-0961-4470-ac75-e7a243bea0de"), "Elite-level coaching and competition prep for professional lifters.", "1 Month", 2, "Powerlifting Pros", 99.99m, null },
                    { new Guid("58241767-75d3-416f-963f-965193013eeb"), "Unlimited gym access, weekly trainer sessions, workout & meal plan.", "1 Month", 0, "Fitness Premium", 79.99m, null },
                    { new Guid("661f922e-6f92-48d1-b02c-b1354e8c2c83"), "Introductory strength program, includes 2 trainer sessions/month.", "1 Month", 2, "Powerlifting Beginners", 29.99m, null },
                    { new Guid("7d84436e-4fe8-4eed-9de7-95f7855ffc7b"), "One-time access to a CrossFit session, no subscription required.", "1 Day", 1, "CrossFit Drop-In", 14.99m, null },
                    { new Guid("840bbd66-abeb-49ff-a947-3b4d035e1f9f"), "Intermediate training plan with weekly progress check-ins.", "1 Month", 2, "Powerlifting Intermediates", 49.99m, null },
                    { new Guid("984a4fcc-db08-4767-9db0-81879ce9fa8c"), "Basic access to gym equipment and cardio area. Includes 1 trainer session/month.", "1 Month", 0, "Fitness Standard", 39.99m, null },
                    { new Guid("9a48ebfa-b098-4764-8aec-68bb1864c25a"), "Unlimited CrossFit classes, personal monitoring, and competition prep.", "1 Month", 1, "CrossFit Unlimited", 99.99m, null },
                    { new Guid("fcd7986d-4173-40aa-9aab-9c6c3287b538"), "Personalized fitness plan tailored by a personal trainer. Includes unlimited sessions and full access.", "1 Month", 0, "Fitness Individual", 99.99m, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "ProductCategory", "Quantity", "Title" },
                values: new object[,]
                {
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0001"), "Brown hoodie for CrossFit training.", "https://dl.dropboxusercontent.com/scl/fi/ioubda5hs2utyc62mvedr/crossfitHoodie01.jpg?rlkey=2najk5e2wt2pgbcz6kprmu1rs&st=h2q43wd6", 49.99m, 0, 25, "CrossFit Hoodie" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0002"), "Black hoodie for CrossFit sessions.", "https://dl.dropboxusercontent.com/scl/fi/6xiqszxl1vd0y1vsvdelk/crossfitHoodie02.jpg?rlkey=gvd8238250o4ra5n44ivpz3or&st=n5kirzrf", 52.99m, 0, 30, "CrossFit Hoodie" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0003"), "Black t-shirt, CrossFit edition.", "https://dl.dropboxusercontent.com/scl/fi/rpscr72a2cpxye7f02qh6/crossfitShirt01.jpg?rlkey=8990fhtd1no1y4yyk5bytuju7&st=9mqh715h", 24.99m, 0, 40, "CrossFit Shirt" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0004"), "Dark green CrossFit t-shirt.", "https://dl.dropboxusercontent.com/scl/fi/3r0opb42esipf3jc6qbxs/crossfitShirt02.jpg?rlkey=6yxp1g4xr8wr9tolh2i9razsk&st=eac42tjn", 24.99m, 0, 40, "Crossfit Shirt" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0005"), "Pink CrossFit t-shirt for women.", "https://dl.dropboxusercontent.com/scl/fi/a7st8xk4x6vn2pki00abk/crossfitShirt03.jpg?rlkey=stszx696okz1ejl9iwh2xllsw&st=dej09t7e", 24.99m, 0, 35, "CrossFit Shirt" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0006"), "Recovery muscle roller for athletes.", "https://dl.dropboxusercontent.com/scl/fi/c7okxrgi7gywdhck8grs6/muscleRoller.jpg?rlkey=jag2u213v8idobltx9k71nqoy&st=e088lnnd", 29.99m, 0, 20, "Muscle Roller" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0007"), "Shaker bottle with Spider-Man face.", "https://dl.dropboxusercontent.com/scl/fi/oqxd4zochtknx7owql0lq/shaker01.jpg?rlkey=c1my2lz1oh7oxrt309vd7255a&st=hntv27nw", 14.99m, 0, 50, "Shaker" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0008"), "Shaker bottle with Captain America shield.", "https://dl.dropboxusercontent.com/scl/fi/hg1z97r3nq2ezrv6n6anq/shaker02.jpg?rlkey=ogzbit9hoczb2dw3ybtndsgyg&st=5pbglcf9", 14.99m, 0, 50, "Shaker" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0009"), "Sturdy wrist wraps for weightlifting.", "https://dl.dropboxusercontent.com/scl/fi/j1kim39r33m5rpwxrmx95/wristWraps.jpg?rlkey=xbh2p9e256u8bm6wu1c1xkplw&st=lkkry4ab", 9.99m, 0, 60, "Wrist Wraps" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0010"), "BCAA supplement for muscle recovery - 0.500 grams, mango flavor.", "https://dl.dropboxusercontent.com/scl/fi/5oam8qizzojmk3nntmh4k/bcaa.jpg?rlkey=qdnwvziwe4k1mh6befgvi4h5t&st=gtz964o3", 14.99m, 1, 40, "BCAA" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0011"), "Creatine monohydrate powder - 0.500grams, unflavour.", "https://dl.dropboxusercontent.com/scl/fi/1hwd0mx4s75sbvkjkfml5/creatine.jpg?rlkey=b7yulqprbourfmru30tg1ojms&st=ob5gdk1t", 29.99m, 1, 40, "Creatine" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0012"), "Multivitamin tablets for daily wellness - 240 tabblets.", "https://dl.dropboxusercontent.com/scl/fi/yz7cprusi1paa297ls06l/multivatamins.jpg?rlkey=lizt1ze6m0pofw2tulpxxfbpx&st=x0wgfqof", 19.99m, 1, 40, "Multivatamins" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0013"), "Pre-workout supplement for energy and focus - 0.400 grams, cola flavor.", "https://dl.dropboxusercontent.com/scl/fi/8oo1ttfnx69x9f7tl7p73/preworkout.jpg?rlkey=cvukic1y4tmbajr89vluxnp22&st=q4h3wm8y", 32.99m, 1, 40, "Preworkout" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0014"), "Omega-3 softgels for heart and joint support - 250 soft gel tables.", "https://dl.dropboxusercontent.com/scl/fi/zbngp5rn5j0083qm5j0sb/omega.jpg?rlkey=jpqpq0xfrgywmeqrn207lgqs0&st=wa41hp5i", 22.99m, 1, 40, "Essential Omega" },
                    { new Guid("9f74f8c2-3f1f-4fcd-89c5-1c1a2a1a0015"), "Whey protein powder for muscle growth - 1 kg, chocolate flavor.", "https://dl.dropboxusercontent.com/scl/fi/57i5a4lrk3ykdffwumnly/wheyProtein.jpg?rlkey=kse99ji33i1ifrgw2aelrtrz2&st=kddhe0qa", 49.99m, 1, 40, "Whey Protein" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: new Guid("0084ce57-2ad8-4de2-840b-d8e6d4dc1570"));

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: new Guid("1b961d8a-defd-426f-9d3d-2383b51400ef"));

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: new Guid("370f11b9-0961-4470-ac75-e7a243bea0de"));

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: new Guid("58241767-75d3-416f-963f-965193013eeb"));

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: new Guid("661f922e-6f92-48d1-b02c-b1354e8c2c83"));

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: new Guid("7d84436e-4fe8-4eed-9de7-95f7855ffc7b"));

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: new Guid("840bbd66-abeb-49ff-a947-3b4d035e1f9f"));

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: new Guid("984a4fcc-db08-4767-9db0-81879ce9fa8c"));

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: new Guid("9a48ebfa-b098-4764-8aec-68bb1864c25a"));

            migrationBuilder.DeleteData(
                table: "Memberships",
                keyColumn: "Id",
                keyValue: new Guid("fcd7986d-4173-40aa-9aab-9c6c3287b538"));

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
