#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCV.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class SeedApplicationUsersAdminMangerTraienrAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("761adbdb-1d7f-4dbb-8ec1-4d62fd0acde9"), null, "User", "USER" },
                    { new Guid("8add11c7-0c60-4776-9ad2-b598fa0f05ae"), null, "Admin", "ADMIN" },
                    { new Guid("8d28163a-03ae-4e27-bc00-31d529cd6b52"), null, "Manager", "MANAGER" },
                    { new Guid("e850a970-b0cd-40a1-ad09-4903d92d4d62"), null, "Trainer", "TRAINER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegisteredOn", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1293b05f-fc49-49d4-8677-9f01f1274b83"), 0, "65213abd-6987-4235-a4c5-04f63bcc41f7", "manager@sportcentervictory.com", true, "Manager Rado", false, null, "MANAGER@SPORTCENTERVICTORY.COM", "MANAGER@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEJCtTYc5G5bzScx0Um3DqnyXIenrAEDHtqLXka7Mw38i3p1CNSE3R9akhFXq8ulouQ==", null, false, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "82bc457a-8642-449b-a896-4c86a0df2847", false, "manager@sportcentervictory.com" },
                    { new Guid("16eaaf0f-2efc-4509-8cbe-c8792d187455"), 0, "8512fb04-4b64-41e6-923e-a12dd94846c8", "victoriadimitrova@sportcentervictory.com", true, "Victoria Dimitrova", false, null, "VICTORIADIMITROVA@SPORTCENTERVICTORY.COM", "VICTORIADIMITROVA@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEOWRrqKWj/TEdGgMhuS84xWYkd397qL7yd6tyml8QvogW5jTw/gugP5ZUajjsvxsGw==", null, false, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "0fcaa215-8426-4ffc-97fb-66ba927d901c", false, "victoriadimitrova@sportcentervictory.com" },
                    { new Guid("28fe258e-8826-4721-abea-f93ce8d1931a"), 0, "cd8a1a3f-74ba-4087-a955-a38592765090", "admin@sportcentervictory.com", true, "Admin User - Rado", false, null, "ADMIN@SPORTCENTERVICTORY.COM", "ADMIN@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEG+4NR5dK0qGfo2jRVpjQKjFKwSydWDA+qLOeZIGQAhUfl1N/eYMtIVROI+4GcJA1w==", null, false, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "f0b198fc-4145-41b7-a643-2d81f1ca002f", false, "admin@sportcentervictory.com" },
                    { new Guid("4a4193c1-2fb3-441e-b8e1-74f9b04e0d2c"), 0, "4d6f56de-dd02-4e7b-85ff-39dc6bee80d1", "stefantodorov@sportcentervictory.com", true, "Stefan Todorov", false, null, "STEFANTODOROV@SPORTCENTERVICTORY.COM", "STEFANTODOROV@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEIr373L1m2/bLnxr6LtaqZAYxhJhYImIe9gra9NU766jKEJnlzn3swa8b//pfc9r4A==", null, false, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "daf884fe-48cb-4f79-a9c7-939516009d4a", false, "stefantodorov@sportcentervictory.com" },
                    { new Guid("6bdd6544-e5bb-4490-b980-022aad36802a"), 0, "9681631b-111e-4268-b030-c46c485c9f12", "mayaivanova@sportcentervictory.com", true, "Maya Ivanova", false, null, "MAYAIVANOVA@SPORTCENTERVICTORY.COM", "MAYAIVANOVA@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEEQTE9aAd7P6yP7AJZ+S4HqYFh23lD7K9XouCp0KfGqelxxB84DImFL/5SIkId+yNQ==", null, false, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "8aa00f22-97fe-48d9-a56d-5b0f181e35b2", false, "mayaivanova@sportcentervictory.com" },
                    { new Guid("a42e9995-8da2-4a1a-95a0-653809d0feb3"), 0, "b927a3f3-3104-4daa-b2d8-30383ca5a77e", "desislaviliev@sportcentervictory.com", true, "Desislav Iliev", false, null, "DESISLAVILIEV@SPORTCENTERVICTORY.COM", "DESISLAVILIEV@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEPp1tTLCp9QYYO8uAGGdo7hrPZGncEjybvKdqivPwhQsRyLc9n/cpM2bopLeKC7ZSA==", null, false, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "d207e0b1-899a-47c6-8cd7-9fc7b5be8505", false, "desislaviliev@sportcentervictory.com" },
                    { new Guid("ba5666bf-9f1f-4513-92d3-23974d9f687f"), 0, "c80e1050-d774-41b2-9537-690592f895cc", "viktornachev@sportcentervictory.com", true, "Viktor Nachev", false, null, "VIKTORNACHEV@SPORTCENTERVICTORY.COM", "VIKTORNACHEV@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEEcBNbiZt3K4AYqm/irQfiGy5BR8FOXA4NUtSPoVKTD9MB3e5b2Wtopcja/Ae6OzDA==", null, false, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "df80f2b6-24ca-4712-9f4f-1d655d80baef", false, "viktornachev@sportcentervictory.com" },
                    { new Guid("bc4d02a0-44d0-459a-a7e6-04831e417e42"), 0, "cb36b9a2-7d43-40d6-9be1-f7cbceacbbe0", "sofiazlateva@sportcentervictory.com", true, "Sofia Zlateva", false, null, "SOFIAZLATEVA@SPORTCENTERVICTORY.COM", "SOFIAZLATEVA@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEIRVhhn1HVaIB9Eh6WBoWGMtJEFaHYw94hLFkm/Q60MryamCdpesm0zDn25vPa3j9Q==", null, false, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "3c1c684d-a61d-4fc2-a593-469dad073653", false, "sofiazlateva@sportcentervictory.com" },
                    { new Guid("bc52f7d1-319c-4e02-bc81-9a2b1afdd438"), 0, "8b4207f2-0491-436c-8419-51feb1f33f11", "kristinadimitrova@sportcentervictory.com", true, "Kristina Dimitrova", false, null, "KRISTINADIMITROVA@SPORTCENTERVICTORY.COM", "KRISTINADIMITROVA@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEFh/vekWkAPx/y+XJ5m17QkJWjyUj85SqKjJ5YYbB2MFm8rCOmmPVdq393NmuFw9UQ==", null, false, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "9defa28a-cad4-4ca5-96a3-ad5024d8f52b", false, "kristinadimitrova@sportcentervictory.com" },
                    { new Guid("bd8a4bc5-c170-4eb8-92b6-fb84bfcd26bd"), 0, "fedc86cb-d601-42a2-b782-f315a6f402a4", "georgikolev@sportcentervictory.com", true, "Georgi Kolev", false, null, "GEORGIKOLEV@SPORTCENTERVICTORY.COM", "GEORGIKOLEV@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEG4YtNSekQL9sLarWoarcNQwxS+DIn0A7cf75G41tQ43sk9sZN1c/f0d0iIoX3bByg==", null, false, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "6ce54230-8b85-4144-ba3f-c556b37aec24", false, "georgikolev@sportcentervictory.com" },
                    { new Guid("c3777e33-e646-48a2-8e00-03058aa6e054"), 0, "82004e41-cfe9-42bc-83ec-292fdc6124c9", "ivanpetrov@sportcentervictory.com", true, "Ivan Petrov", false, null, "IVANPETROV@SPORTCENTERVICTORY.COM", "IVANPETROV@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEOyoXytSZWj1aJj9294SxC9DG1Nmymqj4h00XZcx2p5r1H9N338daikeIhRZZAtr8Q==", null, false, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "eb8e362d-1121-46ce-921e-007219d0aff8", false, "ivanpetrov@sportcentervictory.com" },
                    { new Guid("c3867b78-36a0-44b5-9800-f359a28d2965"), 0, "bef4b1ca-bdd4-44e6-9ff4-55610d9ae006", "ivandimitrov@sportcentervictory.com", true, "Ivan Dimitrov", false, null, "IVANDIMITROV@SPORTCENTERVICTORY.COM", "IVANDIMITROV@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEIy5Mfs6UbU5SCfn8eCUc8rFQgEkoGerqnTWlYnbd7wcv70oYGf+PCy15ayb/ZRqWQ==", null, false, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "9a4b00f0-f51f-4ff6-aaf3-a8732747e7de", false, "ivandimitrov@sportcentervictory.com" },
                    { new Guid("d4fd993d-23fd-4832-9d51-d85a16efa5a8"), 0, "5cfb21f8-91d3-4632-99d6-614711b54417", "mariastefanova@sportcentervictory.com", true, "Maria Stefanova", false, null, "MARIASTEFANOVA@SPORTCENTERVICTORY.COM", "MARIASTEFANOVA@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEH0qVlXLVezrRtzGvdYYvwncigS7yyf3FMbJUOxDW2eSNYWD6Zs0jWTC0pOkBabE9g==", null, false, new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Utc), "de6fecf9-f547-48ea-9cd0-1e2ffa63c223", false, "mariastefanova@sportcentervictory.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("761adbdb-1d7f-4dbb-8ec1-4d62fd0acde9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8add11c7-0c60-4776-9ad2-b598fa0f05ae"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d28163a-03ae-4e27-bc00-31d529cd6b52"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e850a970-b0cd-40a1-ad09-4903d92d4d62"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1293b05f-fc49-49d4-8677-9f01f1274b83"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("16eaaf0f-2efc-4509-8cbe-c8792d187455"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("28fe258e-8826-4721-abea-f93ce8d1931a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4a4193c1-2fb3-441e-b8e1-74f9b04e0d2c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6bdd6544-e5bb-4490-b980-022aad36802a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a42e9995-8da2-4a1a-95a0-653809d0feb3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ba5666bf-9f1f-4513-92d3-23974d9f687f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc4d02a0-44d0-459a-a7e6-04831e417e42"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc52f7d1-319c-4e02-bc81-9a2b1afdd438"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd8a4bc5-c170-4eb8-92b6-fb84bfcd26bd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3777e33-e646-48a2-8e00-03058aa6e054"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3867b78-36a0-44b5-9800-f359a28d2965"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4fd993d-23fd-4832-9d51-d85a16efa5a8"));
        }
    }
}
