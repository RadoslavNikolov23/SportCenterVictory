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
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8d28163a-03ae-4e27-bc00-31d529cd6b52"), new Guid("1293b05f-fc49-49d4-8677-9f01f1274b83") },
                    { new Guid("761adbdb-1d7f-4dbb-8ec1-4d62fd0acde9"), new Guid("16eaaf0f-2efc-4509-8cbe-c8792d187455") },
                    { new Guid("8add11c7-0c60-4776-9ad2-b598fa0f05ae"), new Guid("28fe258e-8826-4721-abea-f93ce8d1931a") },
                    { new Guid("e850a970-b0cd-40a1-ad09-4903d92d4d62"), new Guid("4a4193c1-2fb3-441e-b8e1-74f9b04e0d2c") },
                    { new Guid("e850a970-b0cd-40a1-ad09-4903d92d4d62"), new Guid("6bdd6544-e5bb-4490-b980-022aad36802a") },
                    { new Guid("e850a970-b0cd-40a1-ad09-4903d92d4d62"), new Guid("a42e9995-8da2-4a1a-95a0-653809d0feb3") },
                    { new Guid("e850a970-b0cd-40a1-ad09-4903d92d4d62"), new Guid("ba5666bf-9f1f-4513-92d3-23974d9f687f") },
                    { new Guid("e850a970-b0cd-40a1-ad09-4903d92d4d62"), new Guid("bc4d02a0-44d0-459a-a7e6-04831e417e42") },
                    { new Guid("e850a970-b0cd-40a1-ad09-4903d92d4d62"), new Guid("bc52f7d1-319c-4e02-bc81-9a2b1afdd438") },
                    { new Guid("e850a970-b0cd-40a1-ad09-4903d92d4d62"), new Guid("bd8a4bc5-c170-4eb8-92b6-fb84bfcd26bd") },
                    { new Guid("761adbdb-1d7f-4dbb-8ec1-4d62fd0acde9"), new Guid("c3777e33-e646-48a2-8e00-03058aa6e054") },
                    { new Guid("e850a970-b0cd-40a1-ad09-4903d92d4d62"), new Guid("c3867b78-36a0-44b5-9800-f359a28d2965") },
                    { new Guid("761adbdb-1d7f-4dbb-8ec1-4d62fd0acde9"), new Guid("d4fd993d-23fd-4832-9d51-d85a16efa5a8") }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1293b05f-fc49-49d4-8677-9f01f1274b83"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23749a8f-ecb6-4300-9339-af784119982f", "AQAAAAIAAYagAAAAELBb/wkEEJfGDiM/z/kbULToLp3k/7pzQpCLnPd4kwRWj3mn065QO4+WaaZuXwGd2g==", "15f6c8b3-7e3c-4e1b-a587-4b49eb2adc70" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("16eaaf0f-2efc-4509-8cbe-c8792d187455"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fac9495-cfca-4c17-8f2a-a2c089c1ec86", "AQAAAAIAAYagAAAAELVE1Y3mkhh807j0xnB80/1E7tJ+ZtLihCJLAOzCN7DlK3va+2VjsuA8sirKZvM+Jg==", "c1c1b397-22d3-4b75-894f-b87a2bbc9b80" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("28fe258e-8826-4721-abea-f93ce8d1931a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42f51452-37eb-4ef9-a79e-a72e332daf84", "AQAAAAIAAYagAAAAEDAUYUf6XhO5gIvmSIf9cXA5/QpXyUhqGTNUT8NzdbPnzgb1Tlq/CZo8FV3o4YfNXA==", "670d5bcf-1218-45f0-9292-0ccf47e50474" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4a4193c1-2fb3-441e-b8e1-74f9b04e0d2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad82b395-1dd1-4820-84bc-89a5a8276907", "AQAAAAIAAYagAAAAEA3eKk3ByvyLzYdQN7Kl3ZPuoQHyUn9HX3pD7uSLSF/kJX7Zr5DHc8Wx6MjqoCck0A==", "c614613f-e5e1-41b1-990e-8596363c8f38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6bdd6544-e5bb-4490-b980-022aad36802a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2d1cf04-a68c-45a1-89cb-ef943f79e60e", "AQAAAAIAAYagAAAAEMVhubfsv/ANYwlEXNrzoI6Owymlu3wPddO9rlW2wvs6JLBFuMu+pKWnXAqgifGaVA==", "a80fa6df-df13-4494-9760-de5c7d3faf1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a42e9995-8da2-4a1a-95a0-653809d0feb3"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "881257ea-cedd-4aa8-bc45-c57afdb69c2c", "AQAAAAIAAYagAAAAEOE2Y53P9C31yYxV6EG+Ai+E2ffcLkPr45CJLOwXrtpPO1vVoUyIqb7Mq7c8bkuaFA==", "2e085860-fc76-4b63-8600-7fe22626282f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ba5666bf-9f1f-4513-92d3-23974d9f687f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b93aa8b1-9ae0-4967-bd4e-eeb701266154", "AQAAAAIAAYagAAAAEIjPQXBmB/tuDyY/YA2gpxfXfudgfAleO6YOLMf9kgGnAdrbtkTWi7Wo8mLHF8SvQA==", "9e3ea7e6-cbf3-4ff6-a1c3-8faa241dcc4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc4d02a0-44d0-459a-a7e6-04831e417e42"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52ee8f29-dbb9-4b87-bd6a-f20c8523a522", "AQAAAAIAAYagAAAAENTacRBAuLvMSsjXkpW4XlunSvGSlnehKdC6p9S5dTVShEHl7LYjiVLeVYKqFUixzw==", "2443713d-c0c9-41f1-a511-154c88e59d25" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc52f7d1-319c-4e02-bc81-9a2b1afdd438"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3607c030-976a-467c-b79e-33ceb68b2ad1", "AQAAAAIAAYagAAAAEHwJQFQI+9gkHkHbzIfwKu62Cf6ea/cQgB4n795decBqtGKYhJJQAtd64brvqq58Yg==", "eeca679b-39e3-41cf-94a7-29045939571d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd8a4bc5-c170-4eb8-92b6-fb84bfcd26bd"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e92ee35-8ad9-4de4-863f-783aa0d80f8a", "AQAAAAIAAYagAAAAENtbdesK64flBae2ZhoDZKPEBx7FOadgDShb+nhSz67r2nDMIbiSDBZoHJqg25PC3w==", "4e4822de-1dab-47d3-a4b9-b5e931a82454" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3777e33-e646-48a2-8e00-03058aa6e054"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad9501c0-4a26-4189-a0ad-536414403bcb", "AQAAAAIAAYagAAAAEFV1oTPzLjFDlMsHtLYzJXalFFIduGjJS/Haa09ejN9kA4QXMBgJgDTnb2dH438jig==", "b15fe2a0-c719-4183-bbe7-ce28baaac460" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3867b78-36a0-44b5-9800-f359a28d2965"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf801502-34ef-4df3-b9d4-177dc1e9c514", "AQAAAAIAAYagAAAAEHh5e+lQZST/4HstBcK8M8MZXwY6/D2vxQU1ndj/nuXq8JTwbgRpCsSN1PFOAKCy+g==", "3e940995-3cac-4a8c-a7e0-86a2eb1624dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4fd993d-23fd-4832-9d51-d85a16efa5a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "341b1544-1954-4ccf-9fde-7b4515f4b6f7", "AQAAAAIAAYagAAAAEMHc+aAUgF+7GpnpYXywnOQfwptRHW7SAwSVNWArMQE6fW63fp0OO3srdQLmfLEmjQ==", "e644a2af-5011-4317-8907-cfa2dc5ae022" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d28163a-03ae-4e27-bc00-31d529cd6b52"), new Guid("1293b05f-fc49-49d4-8677-9f01f1274b83") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("761adbdb-1d7f-4dbb-8ec1-4d62fd0acde9"), new Guid("16eaaf0f-2efc-4509-8cbe-c8792d187455") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8add11c7-0c60-4776-9ad2-b598fa0f05ae"), new Guid("28fe258e-8826-4721-abea-f93ce8d1931a") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e850a970-b0cd-40a1-ad09-4903d92d4d62"), new Guid("4a4193c1-2fb3-441e-b8e1-74f9b04e0d2c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e850a970-b0cd-40a1-ad09-4903d92d4d62"), new Guid("6bdd6544-e5bb-4490-b980-022aad36802a") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e850a970-b0cd-40a1-ad09-4903d92d4d62"), new Guid("a42e9995-8da2-4a1a-95a0-653809d0feb3") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e850a970-b0cd-40a1-ad09-4903d92d4d62"), new Guid("ba5666bf-9f1f-4513-92d3-23974d9f687f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e850a970-b0cd-40a1-ad09-4903d92d4d62"), new Guid("bc4d02a0-44d0-459a-a7e6-04831e417e42") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e850a970-b0cd-40a1-ad09-4903d92d4d62"), new Guid("bc52f7d1-319c-4e02-bc81-9a2b1afdd438") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e850a970-b0cd-40a1-ad09-4903d92d4d62"), new Guid("bd8a4bc5-c170-4eb8-92b6-fb84bfcd26bd") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("761adbdb-1d7f-4dbb-8ec1-4d62fd0acde9"), new Guid("c3777e33-e646-48a2-8e00-03058aa6e054") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e850a970-b0cd-40a1-ad09-4903d92d4d62"), new Guid("c3867b78-36a0-44b5-9800-f359a28d2965") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("761adbdb-1d7f-4dbb-8ec1-4d62fd0acde9"), new Guid("d4fd993d-23fd-4832-9d51-d85a16efa5a8") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1293b05f-fc49-49d4-8677-9f01f1274b83"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65213abd-6987-4235-a4c5-04f63bcc41f7", "AQAAAAIAAYagAAAAEJCtTYc5G5bzScx0Um3DqnyXIenrAEDHtqLXka7Mw38i3p1CNSE3R9akhFXq8ulouQ==", "82bc457a-8642-449b-a896-4c86a0df2847" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("16eaaf0f-2efc-4509-8cbe-c8792d187455"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8512fb04-4b64-41e6-923e-a12dd94846c8", "AQAAAAIAAYagAAAAEOWRrqKWj/TEdGgMhuS84xWYkd397qL7yd6tyml8QvogW5jTw/gugP5ZUajjsvxsGw==", "0fcaa215-8426-4ffc-97fb-66ba927d901c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("28fe258e-8826-4721-abea-f93ce8d1931a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd8a1a3f-74ba-4087-a955-a38592765090", "AQAAAAIAAYagAAAAEG+4NR5dK0qGfo2jRVpjQKjFKwSydWDA+qLOeZIGQAhUfl1N/eYMtIVROI+4GcJA1w==", "f0b198fc-4145-41b7-a643-2d81f1ca002f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4a4193c1-2fb3-441e-b8e1-74f9b04e0d2c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d6f56de-dd02-4e7b-85ff-39dc6bee80d1", "AQAAAAIAAYagAAAAEIr373L1m2/bLnxr6LtaqZAYxhJhYImIe9gra9NU766jKEJnlzn3swa8b//pfc9r4A==", "daf884fe-48cb-4f79-a9c7-939516009d4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6bdd6544-e5bb-4490-b980-022aad36802a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9681631b-111e-4268-b030-c46c485c9f12", "AQAAAAIAAYagAAAAEEQTE9aAd7P6yP7AJZ+S4HqYFh23lD7K9XouCp0KfGqelxxB84DImFL/5SIkId+yNQ==", "8aa00f22-97fe-48d9-a56d-5b0f181e35b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a42e9995-8da2-4a1a-95a0-653809d0feb3"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b927a3f3-3104-4daa-b2d8-30383ca5a77e", "AQAAAAIAAYagAAAAEPp1tTLCp9QYYO8uAGGdo7hrPZGncEjybvKdqivPwhQsRyLc9n/cpM2bopLeKC7ZSA==", "d207e0b1-899a-47c6-8cd7-9fc7b5be8505" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ba5666bf-9f1f-4513-92d3-23974d9f687f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c80e1050-d774-41b2-9537-690592f895cc", "AQAAAAIAAYagAAAAEEcBNbiZt3K4AYqm/irQfiGy5BR8FOXA4NUtSPoVKTD9MB3e5b2Wtopcja/Ae6OzDA==", "df80f2b6-24ca-4712-9f4f-1d655d80baef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc4d02a0-44d0-459a-a7e6-04831e417e42"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb36b9a2-7d43-40d6-9be1-f7cbceacbbe0", "AQAAAAIAAYagAAAAEIRVhhn1HVaIB9Eh6WBoWGMtJEFaHYw94hLFkm/Q60MryamCdpesm0zDn25vPa3j9Q==", "3c1c684d-a61d-4fc2-a593-469dad073653" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc52f7d1-319c-4e02-bc81-9a2b1afdd438"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b4207f2-0491-436c-8419-51feb1f33f11", "AQAAAAIAAYagAAAAEFh/vekWkAPx/y+XJ5m17QkJWjyUj85SqKjJ5YYbB2MFm8rCOmmPVdq393NmuFw9UQ==", "9defa28a-cad4-4ca5-96a3-ad5024d8f52b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd8a4bc5-c170-4eb8-92b6-fb84bfcd26bd"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fedc86cb-d601-42a2-b782-f315a6f402a4", "AQAAAAIAAYagAAAAEG4YtNSekQL9sLarWoarcNQwxS+DIn0A7cf75G41tQ43sk9sZN1c/f0d0iIoX3bByg==", "6ce54230-8b85-4144-ba3f-c556b37aec24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3777e33-e646-48a2-8e00-03058aa6e054"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82004e41-cfe9-42bc-83ec-292fdc6124c9", "AQAAAAIAAYagAAAAEOyoXytSZWj1aJj9294SxC9DG1Nmymqj4h00XZcx2p5r1H9N338daikeIhRZZAtr8Q==", "eb8e362d-1121-46ce-921e-007219d0aff8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3867b78-36a0-44b5-9800-f359a28d2965"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bef4b1ca-bdd4-44e6-9ff4-55610d9ae006", "AQAAAAIAAYagAAAAEIy5Mfs6UbU5SCfn8eCUc8rFQgEkoGerqnTWlYnbd7wcv70oYGf+PCy15ayb/ZRqWQ==", "9a4b00f0-f51f-4ff6-aaf3-a8732747e7de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4fd993d-23fd-4832-9d51-d85a16efa5a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cfb21f8-91d3-4632-99d6-614711b54417", "AQAAAAIAAYagAAAAEH0qVlXLVezrRtzGvdYYvwncigS7yyf3FMbJUOxDW2eSNYWD6Zs0jWTC0pOkBabE9g==", "de6fecf9-f547-48ea-9cd0-1e2ffa63c223" });
        }
    }
}
