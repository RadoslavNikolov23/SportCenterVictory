#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCV.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class SeedApplicationUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("0920b615-dd7d-46f5-b238-3ba891569b44"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("1ee19866-6828-412c-80f7-4572630f2a89"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("59015526-c85d-41f8-9550-e8822a1ee4b4"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("948af76c-23f3-4487-a245-c011e58a73db"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("b59e1fd1-f514-4f18-93f0-1d8b7992ce41"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("d270b6ba-60d3-4aee-8ebf-1f2591ebe17b"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("e2a0a45f-bbe7-468e-b697-17dbcd793c79"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("ec83a001-55df-45e5-b8c4-91f4d76f9fd0"));

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
                values: new object[] { "cbdd9b06-d882-4003-ae58-b3c785193b78", "AQAAAAIAAYagAAAAEE+OX7vgzozzVNHhM8RQkD1KbsUYRaxzR0uwQ22ZoiIrHdt79ASv5JYgFKK3l947tA==", "4ac353ce-0ed4-48ad-bdfc-11e32272cb67" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("16eaaf0f-2efc-4509-8cbe-c8792d187455"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da5a6a95-5f89-4c86-ab2b-965a17f75da7", "AQAAAAIAAYagAAAAEDbnG2rh1qPrSlsT3vAmhBmOt5s1rloNo+Ex0WlDJz9wHVnTKPzGNmVjGJHru2zgAA==", "98b6ba3d-6ba6-4fca-a057-0f91d4d85156" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("28fe258e-8826-4721-abea-f93ce8d1931a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b9d9ad3-f8ee-4d71-ab21-519faab5f951", "AQAAAAIAAYagAAAAENAel1E59yM42pZEY2Fq4t0aD4QILrKETa0WY4iLwpeUxp7yLauPq5KQyBnWuvTttg==", "7d7f6208-f6c7-440d-9549-944918d0f013" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4a4193c1-2fb3-441e-b8e1-74f9b04e0d2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45d87d01-bb9c-4a32-aac1-0ff59986db6d", "AQAAAAIAAYagAAAAEClMDUmLaNqPqCu8sC1t091RUuSaRApyzZfY88cboTy6Cl/NwcHDuAbmkTzlX2786w==", "2fbeb82d-20fe-4a43-a770-26af64f159ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6bdd6544-e5bb-4490-b980-022aad36802a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a32e1d2-41a9-4bab-b69e-ab863474dffa", "AQAAAAIAAYagAAAAEPLRqkhdkkk72jnJUqgPtJ+aDus0FZd2+3I/3TVmM3XOH8uXz+i3/D5GsbzgLP2T/Q==", "78af1101-6ef9-41b8-a716-926d45fd9ab8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a42e9995-8da2-4a1a-95a0-653809d0feb3"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31279923-60b9-47e1-9477-a82ad8b3ed2d", "AQAAAAIAAYagAAAAEHFKi+5ChwyuhknFm6fCW+vjk4N5JXjWb4wRGybtGYyh0zEX6FP6bQmxzpGwQOZXaA==", "56e1d4f6-c363-4024-8f96-fc1a096ee8a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ba5666bf-9f1f-4513-92d3-23974d9f687f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "feb76afb-1681-48d4-a468-505cddb92ece", "AQAAAAIAAYagAAAAEKrE05L9ibHywhWAHV/+xn8bcNQcaGqpxu6BmryK9ZQbXlgO4D9OecRHGDVPYqzkcQ==", "c601dbca-51e7-4333-ae96-5f96e0747349" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc4d02a0-44d0-459a-a7e6-04831e417e42"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f542044-6d02-411c-9b14-7e1a49806921", "AQAAAAIAAYagAAAAEL1xgfVBT+m3XepwZJPNGGCx+nQo55RkZA5+QG0xmhymTu7yNk6JN7WtqUEovq1ffA==", "bac6f131-69cc-4027-b53b-e5d7582e8236" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc52f7d1-319c-4e02-bc81-9a2b1afdd438"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a122e70-96d3-4761-aa54-51bacf311688", "AQAAAAIAAYagAAAAEBSU14iuH53+D8i72Zmdp6Zaww0clKZguaeeo7jEGYLbOx5CdEiCZXMCsY8DpopFlw==", "bb094fb2-c41e-4809-9a7e-e622957661de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd8a4bc5-c170-4eb8-92b6-fb84bfcd26bd"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef375bb3-6004-48c5-85b0-ed04d788779c", "AQAAAAIAAYagAAAAEAos5kFKrJVFXACGtVo/uCwD1yKastQOUieQL7iObl36416RddtmgRfndqdfsjo25A==", "9d3831b0-0749-464d-82b5-820ad4c5af06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3777e33-e646-48a2-8e00-03058aa6e054"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5bf317e-6bc6-4f4f-b8ad-9e398a492df4", "AQAAAAIAAYagAAAAEIIL9tQPxnfEbWZQE2+nKa/gZ3E/GcJZkOFLdvgJXVkexxKmbCUlRoLUqVn1qrujXQ==", "c70c3106-9086-4aad-a3b7-57d2947784b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3867b78-36a0-44b5-9800-f359a28d2965"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d262fb2-8a0b-4866-b113-32bd82ce1892", "AQAAAAIAAYagAAAAEBEwZuqMvzsBrhd+kboNSh1LkF39a8VG4UpY6SioU0354gBhmvg1XzZQDYB55pg55Q==", "ee0a95a6-de34-4178-b6e4-59c936560b11" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4fd993d-23fd-4832-9d51-d85a16efa5a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b20eebd-d7c7-4834-9fdf-aa5c2d6950fc", "AQAAAAIAAYagAAAAEFZewZFF/7Z6Iyzg+rusIFUc6zHh1tQ2nKh1zD9PqZnhGigdm8oBt2aoARq8crBSyQ==", "69531add-7af4-40b3-8db7-59d6c48b8f58" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1293b05f-fc49-49d4-8677-9f01f1274b83"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e313c8d3-2902-4ab9-9e61-7a1ad10b4e85", "AQAAAAIAAYagAAAAEEDhUKwo23H40QcVSi5eFSsiPs6Y2i4No/tEjk9j0sxhSuYn1vl8Nk5MTtENxnuccQ==", "951d713b-a1d6-492f-874f-84f28acd2dcb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("16eaaf0f-2efc-4509-8cbe-c8792d187455"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41ed0967-94e7-407e-a1e4-85df817b257e", "AQAAAAIAAYagAAAAEHwqlbzY88AJ8+wrEPtOpG84Nca0KwJYXc4s6ZVyWVD7pOrEDvgWUuxsqze216J//w==", "e91aa312-367c-4bb3-921b-54fea0958394" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("28fe258e-8826-4721-abea-f93ce8d1931a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20d5a22b-80a9-480f-a70b-8c87c002e7bb", "AQAAAAIAAYagAAAAEGI7cqS0Bm3iOgx/fFnX9WKQlJIx23CuX6oAOGcfxw8KsH4UrKaLd8Of3HpsFIsomA==", "ebd20c69-84ed-42a0-bf53-40434947301a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4a4193c1-2fb3-441e-b8e1-74f9b04e0d2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95a58c54-f8b4-484c-802a-e7147dab7f83", "AQAAAAIAAYagAAAAEDWBaLUMS7VNw1BrXRniWmck5JZN2MQcR/gZ232luTtTb33oKyJyFLrCSnZo0f6/hA==", "785122a9-2f75-4be3-b774-f606b5d68495" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6bdd6544-e5bb-4490-b980-022aad36802a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e019f7ba-0d32-4ad4-b306-ee50b4b54f94", "AQAAAAIAAYagAAAAEHdtOGX0TYCMCg3GuOU5njbY0hLz8wtnzrk4gY5qeKVuwlLxySmcoMAtZV+3fbVtxw==", "44bfecb4-8f4e-4db4-a931-b40a550bf826" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a42e9995-8da2-4a1a-95a0-653809d0feb3"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e94432c-479f-4647-b47a-c70d9eeb0bb5", "AQAAAAIAAYagAAAAEKs95Nq6gkNV4SaLEhDzfmP2k3LkOqav8wizLtWeXTtnkr8gH0tDpW0KGw2qsnHD1g==", "a7b8c899-6aa9-40c7-8b30-abc42f8c6297" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ba5666bf-9f1f-4513-92d3-23974d9f687f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e27e867-a4a9-4e3a-9905-289f140b5c18", "AQAAAAIAAYagAAAAEOJKObYnh0ccETFxt/6mjYiK+e6u2M/EDrnBwJw+ftgLbvOiLMjalrkEdStFWwjeEw==", "d28ff259-79cc-45ae-ac08-6177c125c322" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc4d02a0-44d0-459a-a7e6-04831e417e42"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6642d403-8a9c-4a8a-a769-017e660511e9", "AQAAAAIAAYagAAAAEAZvTFRVwfrcU1chhpccGMIjh4HqvLwsgJGmdvM5DHaD/B4OA7IMcVMi0EbW8UhxkA==", "a2ad8d64-48d2-44e8-85c3-247d8940d4e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc52f7d1-319c-4e02-bc81-9a2b1afdd438"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c45460ab-07ad-499f-a0a1-8cc34e67b213", "AQAAAAIAAYagAAAAELt3ETV/V8F1NkvH6i0ka68TMXCsyzdsQlLpquxY4r8qJrOECKFrH+EmQsN4PeMydg==", "c149649e-0628-4e11-b827-0b92dc470181" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd8a4bc5-c170-4eb8-92b6-fb84bfcd26bd"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f2da17d-f1ed-4906-8fb5-92d0a8e1fe63", "AQAAAAIAAYagAAAAEO0YUlPYA9M08yDxer+mBMzAfk3g6BdROA68EZF7UviT6SX51wtiTHsJmX4c7quR7Q==", "0f5ca47e-79a8-4b4c-8472-e03f4b524bb8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3777e33-e646-48a2-8e00-03058aa6e054"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56686408-70a8-4b9d-872d-0a88a5fa7df9", "AQAAAAIAAYagAAAAEG/XYQyJTOXSDjuy7LWE95jhIrSSoW5QE+F2yqvN1AY05YbNC78eSgp2nqUG9NOnXg==", "5fafd29a-1e7d-4dfb-9454-016652dd72cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3867b78-36a0-44b5-9800-f359a28d2965"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb73e00f-33cb-40e3-be9b-3113d82ab657", "AQAAAAIAAYagAAAAEIA/ZgYn0zOEbe9dXLUJeCNR7kDEpw5a9C3GvbWkzy+wkmc+SqVRpACfbrVr5apq7A==", "0f6dc451-6148-42a1-94cd-4afca7529846" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4fd993d-23fd-4832-9d51-d85a16efa5a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c81c8f33-b654-42a0-b6fe-4d737202f20d", "AQAAAAIAAYagAAAAEDf1eJ9QprPtxQqfHluKQmGpSPqI6nVBTmkCr29/FUfoZFsU+4Tl2PlgbbQxeBHcDQ==", "1a11ae66-27b6-43e7-b6fc-e134a6f6e714" });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "ApplicationUserId", "Bio", "Email", "FirstName", "ImageUrl", "LastName", "PhoneNumber", "TrainerSpecialty" },
                values: new object[,]
                {
                    { new Guid("0920b615-dd7d-46f5-b238-3ba891569b44"), null, "Advanced strength trainer focused on Olympic lifts and powerlifting competition prep.", "stefan.todorov@sportvictory.bg", "Stefan", "images/Trainers/Powerlifting/stefanTodorov.jpg", "Todorov", "+359887123321", 0 },
                    { new Guid("1ee19866-6828-412c-80f7-4572630f2a89"), null, "Focused on mobility, recovery, and competitive CrossFit coaching.", "georgi.kolev@sportvictory.bg", "Georgi", "images/Trainers/Crossfit/georgiKolev.jpg", "Kolev", "+359886998877", 0 },
                    { new Guid("59015526-c85d-41f8-9550-e8822a1ee4b4"), null, "Female powerlifting coach with a passion for strength training and mental toughness.", "kristina.dimitrova@sportvictory.bg", "Kristina", "images/Trainers/Powerlifting/kristinaDimitrova.jpg", "Dimitrova", "+359889332211", 0 },
                    { new Guid("948af76c-23f3-4487-a245-c011e58a73db"), null, "Certified fitness instructor and personal coach with a focus on fat loss and cardio endurance.", "viktor.nachev@sportvictory.bg", "Viktor", "images/Trainers/Fitness/viktorNachev.jpg", "Nachev", null, 0 },
                    { new Guid("b59e1fd1-f514-4f18-93f0-1d8b7992ce41"), null, "Certified CrossFit Level 2 coach with 7 years of experience in functional training.", "ivan.dimitrov@svc.bg", "Ivan", "images/Trainers/Crossfit/ivanDimitrov.jpg", "Dimitrov", "+359888123456", 1 },
                    { new Guid("d270b6ba-60d3-4aee-8ebf-1f2591ebe17b"), null, "Enthusiastic trainer offering tailored programs for male and female fitness and weight training.", "desislav.iliev@sportvictory.bg", "Desislav", "images/Trainers/Fitness/desislavIliev.jpg", "Iliev", "+359883456789", 0 },
                    { new Guid("e2a0a45f-bbe7-468e-b697-17dbcd793c79"), null, "Creative Fitness coach with a love for community building and mental resilience.", "sofia.zlateva@sportvictory.bg", "Sofia", "images/Trainers/Fitness/sofiaZlateva.jpg", "Zlateva", "+359888765432", 0 },
                    { new Guid("ec83a001-55df-45e5-b8c4-91f4d76f9fd0"), null, "Fitness and bodybuilding expert with over 10 years of personal training experience.", "maya.ivanova@svc.bg", "Maya", "images/Trainers/Crossfit/mayaIvanova.jpg", "Ivanova", "+359885987654", 1 }
                });

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
    }
}
