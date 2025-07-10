using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCV.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserFeedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1293b05f-fc49-49d4-8677-9f01f1274b83"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22609489-80aa-4e7e-a039-1960be9a55b9", "AQAAAAIAAYagAAAAEFR+jjASv0aZ4t9Aq5J0gZnODUVcV21ecQcelya9UH+Or5yp/hmSpjjHidMVUH1FHQ==", "f2ea7649-4aa5-4a78-a859-01f3fe584dd3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("16eaaf0f-2efc-4509-8cbe-c8792d187455"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92e04a2f-9cd6-433b-9965-ffc7058f596a", "AQAAAAIAAYagAAAAEIKIey6W4wdSwemkUY4J2k5mhlQByXopjmI2Bb/ZmGzyOjQUmzhjIBj5cyylcdLrUQ==", "36880180-1f37-43e6-b6f8-15457aa1bf30" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("28fe258e-8826-4721-abea-f93ce8d1931a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd68af34-327a-4046-b711-ac3477c539fe", "AQAAAAIAAYagAAAAELdviFyc9aSbuCt1pNEa3YuL21sEGNVzHFfqxsEAnN0H8zjZt7WrVlGlEPt35EiwkA==", "ccc5f382-8eec-4b15-a2f4-0128eb70d9f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4a4193c1-2fb3-441e-b8e1-74f9b04e0d2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6176af6-5161-43ed-895a-96d1dbc0c085", "AQAAAAIAAYagAAAAEDqsedM1LAxL4sGY5ekDeixFW112EzxwaNxNrmrke4baZu32nxMOmVE4upIKayteWg==", "dde526d3-0911-472d-92ac-75b280b2f854" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6bdd6544-e5bb-4490-b980-022aad36802a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cecdb460-dbbc-4818-8c6e-bcc48456acd7", "AQAAAAIAAYagAAAAEBTR0xGvJZ43AZU0sSXWbrJ09oBnc+dcyUfy4GiYBFfVsSzjEGUvlsove1kVprV9mw==", "04e0e6d1-6eb8-448b-8f48-f272bbac1841" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a42e9995-8da2-4a1a-95a0-653809d0feb3"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39847e51-60b5-4eba-95ed-a983a3db6114", "AQAAAAIAAYagAAAAEPoofLN0+e+YcTIL+AjbJDzMBAZ7HNhviP6uEHvWg5a5GjDeoJUudn3YjVEMC037Jg==", "b8762e0b-abc7-42b5-a0b1-3f2205a1c31d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ba5666bf-9f1f-4513-92d3-23974d9f687f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a7519f7-1cfc-432c-aa1c-bafa2e2019b8", "AQAAAAIAAYagAAAAEBQ10BLZs5/g1Pcmqun5WQdXw9gv7c0d+9IewEakVRS0jV5CkF+6FVU00hcy6HJgmA==", "0cbcff82-887c-40bc-9bee-2b3f9ba19a1a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc4d02a0-44d0-459a-a7e6-04831e417e42"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "038054cd-aeb6-45e0-a837-5f469b4044a4", "AQAAAAIAAYagAAAAEMejU5U1dM/mz4Z6PkOoMySrMdGyKhPtE7v2GNXXdH5way7mWbWL31LRkwgXdBKMPw==", "9ad3ff23-98a0-4688-9f75-2e27dbb56734" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc52f7d1-319c-4e02-bc81-9a2b1afdd438"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "943e9a9e-32cf-471d-a767-b0671a20dcc2", "AQAAAAIAAYagAAAAEAsJczySHgEADPOMWGwlmoihNq1/veK/Uf9Fg1mEy4Iir7IjuCtltZ4rnxT1JLDLbw==", "65b8a741-b920-45e5-828d-acc7c9da6ee7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd8a4bc5-c170-4eb8-92b6-fb84bfcd26bd"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22e06221-1e83-4ab0-8148-0c730814833a", "AQAAAAIAAYagAAAAEPKMbQB0TNdO3DTBNshkoeaXH3GRydMtbu14Pvbx6WFyszQy+kT8cufrSdLwsExgiw==", "ca7de856-bfa6-4f05-8b60-92cfb01645cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3777e33-e646-48a2-8e00-03058aa6e054"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8eb41af9-a4a8-490e-9734-6dee9415e615", "AQAAAAIAAYagAAAAEDOK9rDAasXuguzZPouyIr4vnIY/4oRdtX80FM7FHuTBqBMJ7Pe1341cR4UQ+ytN1Q==", "70ee98c3-f502-43ec-93c2-a5dbfd281eeb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3867b78-36a0-44b5-9800-f359a28d2965"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5476bbc-3c9b-47ae-8127-cd8ead249c69", "AQAAAAIAAYagAAAAEO6pgzy65jrfBsOi8+tmv/b6yFA1dojqbetSkko/61V8PsUKuSU3sJCz0k6XEVD7/Q==", "0a085c23-ddd2-4ac0-8a33-6ada250ab03d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4fd993d-23fd-4832-9d51-d85a16efa5a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "147ec12c-0cdf-421c-87f8-05eee1f2bab9", "AQAAAAIAAYagAAAAEJ3EZ2D9SV4RAN/GZnrgPu4ekdD9w9QuGg9mkQYmLNIUA15PhZIzawOu5shhGK48wQ==", "75447977-c555-40ac-b073-be69a481f4e5" });

            migrationBuilder.InsertData(
                table: "UserFeedbacks",
                columns: new[] { "Id", "ApplicationUserId", "Feedback", "ImageUrl", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, null, "The trainers are amazing and the CrossFit classes push me beyond my limits. Great vibe overall!", "images/Users/victoriaDimitrova.jpg", new Guid("16eaaf0f-2efc-4509-8cbe-c8792d187455"), "Victoria Dimitrova" },
                    { 2, null, "I really enjoy the new powerlifting area. More squat racks would be a great addition!", "images/Users/ivanPetrov.jpg", new Guid("c3777e33-e646-48a2-8e00-03058aa6e054"), "Ivan Petrov" },
                    { 3, null, "Excellent gym with a motivating atmosphere. Love the group workouts and the clean facilities.", "images/Users/mariaStefanova.jpg", new Guid("d4fd993d-23fd-4832-9d51-d85a16efa5a8"), "Maria Stefanova" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1293b05f-fc49-49d4-8677-9f01f1274b83"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0140855-ab42-433a-b784-eef8d41a4fe6", "AQAAAAIAAYagAAAAEOiHnmZM8ohlMUc403i8qZ121p/fOdxhObMIue4EWOp+fQvS6Ce1ynQSbLOXUKtTGg==", "26fb60d2-474f-491e-a016-db57104c0da9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("16eaaf0f-2efc-4509-8cbe-c8792d187455"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98eaedfc-3bd3-4578-8978-0f692077db1e", "AQAAAAIAAYagAAAAEJvw10dwUk3KH58mndd44BUxtem7I98WEvuxpWC1KIb031ixiprQN+1YPuOz9x3b8w==", "8f92542a-09f4-4efd-8647-9a6f1a07347e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("28fe258e-8826-4721-abea-f93ce8d1931a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "793e9550-35d4-4c1f-a7e2-5386fde9cd9b", "AQAAAAIAAYagAAAAEKYjKdqy3xfCZSH94a2HQgTRqIYc4S+NruhAkasqMlyXrGI7HadFzZxXC4F5QDcC8g==", "6c6ac2d1-f800-4b53-b77e-ec4a88fbc542" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4a4193c1-2fb3-441e-b8e1-74f9b04e0d2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da032f69-728e-48a1-a022-bd467c2adcfe", "AQAAAAIAAYagAAAAEG0uzi5C76IWbg5mmc7E3sAT8qRuS2CUdUCTiszQNZ9Y4ayiimQmYL09MWtli7XPSA==", "3ee6be35-2fda-4d9a-9785-be7e324b4d0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6bdd6544-e5bb-4490-b980-022aad36802a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fd6146a-df11-46c6-bbdd-59575aac07b2", "AQAAAAIAAYagAAAAEOnQZZ0jJdOZlg4KoT3iLvKJCSGS3T3FX2c88mq6AF3KU5yvJArjPFuHQcPzhLqknw==", "24ad0107-5be7-4b58-bbaf-43d7a4898a49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a42e9995-8da2-4a1a-95a0-653809d0feb3"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03ab194a-22be-42ea-905c-d6dc9fc3f659", "AQAAAAIAAYagAAAAEP/WuANJhMucx7hyveNyPXz3CyftqypItxebUAvnQ87Yqjx/UZRUoqZGcMD4nqWTiQ==", "b2852055-100e-47bf-9f3b-f40c11e6a741" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ba5666bf-9f1f-4513-92d3-23974d9f687f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38c84579-ff63-4027-bde4-eaaecd9a79f7", "AQAAAAIAAYagAAAAEMcuh2TqopsgK3j8nhYyXxuytK/sJauxF/ykS7gn6PidyOfOygKWJAZTptQGGjbzzQ==", "0863f9d7-be3c-4244-9a11-b9c375e6d3e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc4d02a0-44d0-459a-a7e6-04831e417e42"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41f76fd6-05ea-4593-aa09-d48e2e3c9602", "AQAAAAIAAYagAAAAEAnyCdyStLG4xcalpghgEZ3hNsf1n5Xwf9Tuxwqn1/36fHz0Dz79IaOWsImY8cA5EQ==", "249a445d-20fc-4965-a48e-006e084f7e0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc52f7d1-319c-4e02-bc81-9a2b1afdd438"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c522d013-284a-47be-9a26-9344d917e161", "AQAAAAIAAYagAAAAEC+sNtp9A8nlHrVMz35vy2TGKmwGj9+qNwWVedXdu/7AtqYkN+g56swwjBREUAyEbA==", "f6d16d4e-3701-4c86-bf4f-5d6ac7cc188e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd8a4bc5-c170-4eb8-92b6-fb84bfcd26bd"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7dab461-dd5b-449b-9db9-bb31ac0f2b85", "AQAAAAIAAYagAAAAEIMyiJ3dS+1XedYKJLfaUo7r75nwUX8sgiWa0y+OG+kQkt6YK2080sbU5bw3WHtSFg==", "88010d3d-7973-4446-ba8e-f23494df566b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3777e33-e646-48a2-8e00-03058aa6e054"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c77bd64-2e8c-4b34-803d-03ab92ae0245", "AQAAAAIAAYagAAAAEC3dc1I/mBKP/BhAfi0TaxSmDVL1ylX5MPYFsM7D1lL7CIsbrpIQRF0WbgyvVUkpew==", "ec55ea75-4110-4a20-80f1-836d2169d064" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3867b78-36a0-44b5-9800-f359a28d2965"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25697d20-7f74-4e17-82d1-9bbd391086e2", "AQAAAAIAAYagAAAAEHl2c4jvbvs530245hwV6olY7W49dWwxFqlmXV4H5e+/so9MU1YXrQGEeKjmuxiDrQ==", "ac7c537b-053b-4901-bda6-d578af83583c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4fd993d-23fd-4832-9d51-d85a16efa5a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f1a9bf4-0005-4c40-934a-2f7d1173114a", "AQAAAAIAAYagAAAAEOaM6SI5iQodgowlHb8iYbYUug5VitDioURb1B+HLpX/ugurqlmPqGcUoxA4ngnwsA==", "ce61d7c3-9c1b-4c23-96c4-2605fa08a7c5" });
        }
    }
}
