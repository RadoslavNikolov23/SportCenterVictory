#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCV.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

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
                values: new object[] { "9ab23c72-4470-485d-832e-b24d6ff56cd3", "AQAAAAIAAYagAAAAEIZfKRNmk0RZedbZbDR+UDeHyTFKfjJ64LmyTHbw2B9IT4umwznPatG8LTtaXHXfqg==", "738fe6ff-afeb-4d13-b181-100b9e1e6802" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("16eaaf0f-2efc-4509-8cbe-c8792d187455"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b417e5c-1a29-4cdd-afc0-7b8f1940aed8", "AQAAAAIAAYagAAAAEJhBIaRXS4n5XDXQNj3goMLEL3RREM/kvH+d+IvIm73B54NKn4Ey3QQpKnr/Gvc7Jg==", "1a5cfcc1-96d0-4c40-8245-5a752c8bc90a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("28fe258e-8826-4721-abea-f93ce8d1931a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02921fcc-09f2-4425-8ffd-abc7c6317c9a", "AQAAAAIAAYagAAAAEN8Oq+79mw6nFiq/57+sYTOzITLzSdnEo+a91EUCLKQLyrnxM8DsVXhwpRVvOq7PDA==", "cc0f1993-865a-4e5b-9bef-5e6cc491bfdc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4a4193c1-2fb3-441e-b8e1-74f9b04e0d2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fff1778c-94a6-4933-b786-426af7163714", "AQAAAAIAAYagAAAAEDPsyW936W5y+Bn4gpI1OJxguDxvKKYVfKVj+N86PeDGWRKeXeJmomaRmczlWdhjCg==", "fd9ec38b-a34e-4449-ab3e-c8592f5823fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6bdd6544-e5bb-4490-b980-022aad36802a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8aa66fe8-4014-48ae-8d5c-9ac225043fbd", "AQAAAAIAAYagAAAAELNcHFk3e/Dx+Dj5BLGFbP7OrWJck8JwjzyzojNBVzd6JPr9zDtTJvADOTK5nlteew==", "8f1d95dc-f831-4fa6-bf18-b9e8009516b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a42e9995-8da2-4a1a-95a0-653809d0feb3"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae4aac1e-3479-46f6-88d1-a14b09b9cb7d", "AQAAAAIAAYagAAAAEJC9b/NVJzzjM9fJBdoD6nLVINWbXePG97BkEGJZzyJoNmQ8Ad5fx/dY5rqtRbTvpg==", "9fa03778-d64b-42b2-b550-ca21cf7497f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ba5666bf-9f1f-4513-92d3-23974d9f687f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fe0a0d2-5641-4f46-878a-c3ee2a3b8df8", "AQAAAAIAAYagAAAAENp67G7Yj0JcLz0U10yvXxsYm8pAOfiWALJ2f7pkIup8XPMTaG+cMVxIAot4IVB/ew==", "a3520194-96e4-48c0-9f09-186a23f8e512" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc4d02a0-44d0-459a-a7e6-04831e417e42"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa89fb82-45d2-416e-9a5f-7af5131d45fb", "AQAAAAIAAYagAAAAEMCRnAxpjy9qkkeS1ul+QFMLQKSh4OtnAuig8/4UeBHkm3irnA2760O+blJmEPvc3A==", "5c7a087b-b1d7-4cf1-a9bb-bd43120f7879" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc52f7d1-319c-4e02-bc81-9a2b1afdd438"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df0c08bd-dbce-44b2-8824-26d404370ea6", "AQAAAAIAAYagAAAAEKNdwUCzpKewQvuW7h5dPEoKft1Ghpq84fa/I4VoiBnNg50zKfPthBdojlwcMImoNw==", "6b0f17ca-c207-4308-a51b-83640c1dd1ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd8a4bc5-c170-4eb8-92b6-fb84bfcd26bd"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70a395d3-e892-4f0c-bd21-c0a3fb840882", "AQAAAAIAAYagAAAAEClcrVAWY8fREEYzfHppx6UbwhQZ0hwq1Hf8nArgjsaOI3XJK6DRbr0rfV0Q34Lq1w==", "4d34b491-12d5-49de-8080-a137e2d335d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3777e33-e646-48a2-8e00-03058aa6e054"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0dd4daf-66d4-4088-876f-d433b5cec85b", "AQAAAAIAAYagAAAAEMvZWUvbPAimFDOUF8M7nyHWbU3kE6Opg4iFRqfZmXLHcXC2qyuPttR1NH5K5ktycg==", "c2acf54f-e1dc-4e69-adbb-c4c0d767a115" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3867b78-36a0-44b5-9800-f359a28d2965"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6da5eeb-ea91-45d1-8bf6-2d3caefc5ba3", "AQAAAAIAAYagAAAAELrA2MW3RIzJl1sCE/aRBOBIfLbjKk6P/4YCsd1MM0A/g/FawLPsrP2Z6wl+fe+ZuA==", "e7b64e0b-469a-4802-8fa0-a33f46539d18" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4fd993d-23fd-4832-9d51-d85a16efa5a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4427497-153d-44f6-b8e8-f766466e45a3", "AQAAAAIAAYagAAAAEMlXorgZEKG6auIXuy1mOZ5hYCOEZhrV98Rq5KtX8EH7XIH76a/97jRF9PeF0dW9uQ==", "3a8fcb87-20d8-47b1-a614-54237d7a6f1c" });

            migrationBuilder.InsertData(
                table: "UserFeedbacks",
                columns: new[] { "Id", "ApplicationUserId", "Feedback", "ImageUrl", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, null, "The trainers are amazing and the CrossFit classes push me beyond my limits. Great vibe overall!", "/images/Users/victoriaDimitrova.jpg", new Guid("16eaaf0f-2efc-4509-8cbe-c8792d187455"), "Victoria Dimitrova" },
                    { 2, null, "I really enjoy the new powerlifting area. More squat racks would be a great addition!", "/images/Users/ivanPetrov.jpg", new Guid("c3777e33-e646-48a2-8e00-03058aa6e054"), "Ivan Petrov" },
                    { 3, null, "Excellent gym with a motivating atmosphere. Love the group workouts and the clean facilities.", "/images/Users/mariaStefanova.jpg", new Guid("d4fd993d-23fd-4832-9d51-d85a16efa5a8"), "Maria Stefanova" }
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
                values: new object[] { "631e4cb3-ea15-4ee5-b655-a285a70356e0", "AQAAAAIAAYagAAAAENSUzuCC8dnhl4k8dnOKhzz7A6Zqh1+r+eJxB7bNWXElZBYzErO/yfT9U7WpfNZbyA==", "dd664ccf-85c3-498d-b291-6ac959be138b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("16eaaf0f-2efc-4509-8cbe-c8792d187455"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "194e4c78-7033-476c-80cd-14b3127f40f0", "AQAAAAIAAYagAAAAEF32Y31w6wYBJsGauM5IqmYOW9ocQgWLc4DruaCD4wwh1+KvEL5vhJRBpCdQsD43nA==", "1ea23019-7815-4009-bd5a-ea0544d2d990" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("28fe258e-8826-4721-abea-f93ce8d1931a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2c49fdc-e904-4f27-977a-fdc8ad941aec", "AQAAAAIAAYagAAAAECHU/+tTKN52hR9MfIxd4KOl+JoGh8TdX6y4yCkNSFLL8+cVZ0YpsDpTFDCNSUW6DQ==", "926ba49b-26e4-4e03-8b69-4cceced76400" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4a4193c1-2fb3-441e-b8e1-74f9b04e0d2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30db2d59-3ec4-48d4-aeaf-90943cdea93a", "AQAAAAIAAYagAAAAEElA6egX0l+5V+I1j6sPWWFw9CStq/hgxdytYiVLrLw5v9/6aMsN/0ZjTYzBQyCEqA==", "d94d67ce-eac6-4fe9-9c00-951967b56483" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6bdd6544-e5bb-4490-b980-022aad36802a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86ca9756-0f32-4e57-b7f4-a47fdc1b0e70", "AQAAAAIAAYagAAAAEJXRegLzcuwu0rShNDcUIWL93xwURpG2Scfx2LdPPoslJTBUi37KC+O8tEl7J8KxEw==", "6b228e75-7dce-493f-aeee-e2cd07f0de49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a42e9995-8da2-4a1a-95a0-653809d0feb3"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bcd95cc4-a6fc-4a75-b09a-a2e78ede4145", "AQAAAAIAAYagAAAAENnm7fvDbX0JjRZ+G6Z2gVshfmC5yWL1kxn8eNRbpezYFVKTMs1v6OQH/KjUZVgVbA==", "19c499df-fe86-4c8e-b2ad-c30f94e50467" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ba5666bf-9f1f-4513-92d3-23974d9f687f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa632a87-5cfc-43cd-8057-216722bb7309", "AQAAAAIAAYagAAAAEKSf4WZ/f4snRRxQSksSAl1ED47qHAZGaP3r4Akqu+VgRBrUWJJH8R2nePlzHJfNcw==", "e8e2fd1c-b572-468a-873c-e451c1369288" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc4d02a0-44d0-459a-a7e6-04831e417e42"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f8ae29e-af13-45de-95cc-7193dbdc15b5", "AQAAAAIAAYagAAAAEAZ8Ca+Nb+v0umq7mCal8acw3c1LzF3eTAFjp+VBN9mS078MwEm8vSjyK8A5rRHCbw==", "7da51fd2-6e51-4bb3-9e45-afa8341f1b58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc52f7d1-319c-4e02-bc81-9a2b1afdd438"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55fd6a2a-b04a-4832-ba50-a4f2e260c5d5", "AQAAAAIAAYagAAAAED+2zaiC9wwWI/91oUkqpdMx2HlV13fLbDNfGwI2nzv1ecYiuSUHNYyJUi1v9Ba3jA==", "41457766-38cf-40a0-a56a-d65b25c2e488" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd8a4bc5-c170-4eb8-92b6-fb84bfcd26bd"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5525a37a-c376-4786-8363-8b7c2933bfe1", "AQAAAAIAAYagAAAAEOTLVzMjXElDmCSV0bOGKoTyrVTEWsk7BdxqbD5WnbSY7lJM9m4nCv8mIeoZqF14yQ==", "da3f34e4-f99f-4190-b11e-becede394039" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3777e33-e646-48a2-8e00-03058aa6e054"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6dd2d08f-8698-4961-8578-9a8fea9dd279", "AQAAAAIAAYagAAAAEB6m/UT/VddEXyTC9ZXaBEACI8pycwv4bLjddiO7Pe6kDY5oc/usHGbz2YbbugtyxQ==", "a2dac493-4619-4e39-8dff-1cd2886e9f03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3867b78-36a0-44b5-9800-f359a28d2965"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b502a2b1-d49c-41b3-9119-9b41d3fff3b5", "AQAAAAIAAYagAAAAED3p88apWD8OagNLF+9XY/6cT1wmysj6bwAV8u80aHhKO/XNupoLdHNQV+AHyqjL4w==", "646d74b1-b686-45d5-978d-3dfc3a4df853" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4fd993d-23fd-4832-9d51-d85a16efa5a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39b02ab5-d17c-4725-9ce6-f1ba0948df98", "AQAAAAIAAYagAAAAEC5RM92QsbKAt981AVd41Uzx/nN4hwtrsYnyfNvOfrIsMk+jUn8Zkv6E51MWJwQsWg==", "a0804e3b-ea7f-4a18-bcd5-97a9d33c6b76" });
        }
    }
}
