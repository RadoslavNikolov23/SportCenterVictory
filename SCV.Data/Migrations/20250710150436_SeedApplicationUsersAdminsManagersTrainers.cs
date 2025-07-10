#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCV.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class SeedApplicationUsersAdminsManagersTrainers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegisteredOn", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1293b05f-fc49-49d4-8677-9f01f1274b83"), 0, "973c2bea-f485-4a9e-a7d9-e5125f8a17aa", "manager@sportcentervictory.com", true, "Manager Rado", false, null, "MANAGER@SPORTCENTERVICTORY.COM", "MANAGER@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAENO+NfohqmxVx5M2nbbzXkXDF7KY8Eh8sIERSSiefj+f1nWo2PcXMta8F1zXAvxecw==", null, false, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), "0a514660-4ea6-400b-9a68-efabca72421c", false, "manager@sportcentervictory.com" },
                    { new Guid("16eaaf0f-2efc-4509-8cbe-c8792d187455"), 0, "a8b9e213-5e83-4f3e-972f-821cd0b44e73", "victoriadimitrova@sportcentervictory.com", true, "Victoria Dimitrova", false, null, "VICTORIADIMITROVA@SPORTCENTERVICTORY.COM", "VICTORIADIMITROVA@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAENEjB419kYb9j4vBXVYnoMhVFUJuOkJL+Maes2RqyfbbLuz+WI3HWAXopQ0PQk/8Yw==", null, false, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), "03c2ed1b-d9f3-4e3d-a0cc-ecd75880cd20", false, "victoriadimitrova@sportcentervictory.com" },
                    { new Guid("28fe258e-8826-4721-abea-f93ce8d1931a"), 0, "0ef40f4f-7ae1-44c7-ba03-e2b9b494bc60", "admin@sportcentervictory.com", true, "Admin User - Rado", false, null, "ADMIN@SPORTCENTERVICTORY.COM", "ADMIN@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAELd8cfUJUXH4IJqHS4o7T2y2vb0Ht/1wXP8lECSIwHmRZAbFZtWw0NOnKrM74SFZww==", null, false, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), "b46b4e03-e42c-487c-967d-9bfe95019ef0", false, "admin@sportcentervictory.com" },
                    { new Guid("4a4193c1-2fb3-441e-b8e1-74f9b04e0d2c"), 0, "c56472c1-4d48-4be5-91d0-7a0047d82b60", "stefantodorov@sportcentervictory.com", true, "Stefan Todorov", false, null, "STEFANTODOROV@SPORTCENTERVICTORY.COM", "STEFANTODOROV@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEBMssmk9YifvvyYXif1/6MJHIxxWl7t8FWnkbBLd0XSxNCVKh9unU3jkGnROXkBhDg==", null, false, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), "aba1f248-96b9-4a0e-841d-763d1ba0474d", false, "stefantodorov@sportcentervictory.com" },
                    { new Guid("6bdd6544-e5bb-4490-b980-022aad36802a"), 0, "7cbc1602-87d5-45c0-8f98-2f9ff689a56c", "mayaivanova@sportcentervictory.com", true, "Maya Ivanova", false, null, "MAYAIVANOVA@SPORTCENTERVICTORY.COM", "MAYAIVANOVA@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEFgX7e0yRu3mZVdMUU1Em3xhMe7UmEzyK+PoNoLQKJ/eZTuPIo33XwpcRG0ffeBoHw==", null, false, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), "27df9c36-0a20-4ee6-9fcc-1b40d0043d60", false, "mayaivanova@sportcentervictory.com" },
                    { new Guid("a42e9995-8da2-4a1a-95a0-653809d0feb3"), 0, "6e4cfa1b-39e6-4031-ae10-bb8657c16200", "desislaviliev@sportcentervictory.com", true, "Desislav Iliev", false, null, "DESISLAVILIEV@SPORTCENTERVICTORY.COM", "DESISLAVILIEV@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAECsl3dQkgG5KraS7KPTQxLZzWFF66f0QXAR6OvQFkdVTmncsA7dsZ7BQNuYbXf4h4Q==", null, false, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), "bf4b882c-eacf-4f28-8b26-c2711c05f432", false, "desislaviliev@sportcentervictory.com" },
                    { new Guid("ba5666bf-9f1f-4513-92d3-23974d9f687f"), 0, "c525b21f-aee3-493a-b248-e7f55c20ff56", "viktornachev@sportcentervictory.com", true, "Viktor Nachev", false, null, "VIKTORNACHEV@SPORTCENTERVICTORY.COM", "VIKTORNACHEV@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEFN2vcVygupOxS1N3h9nzwKiL37t7O89SivS7Zk9I7IZ7dr8OkXNoMgnL8cow+99FQ==", null, false, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), "2c94dc3b-3515-4a7c-bbc6-1f8b68d668f6", false, "viktornachev@sportcentervictory.com" },
                    { new Guid("bc4d02a0-44d0-459a-a7e6-04831e417e42"), 0, "31d5a3e5-9daa-4ec0-b336-eeab7ca3c008", "sofiazlateva@sportcentervictory.com", true, "Sofia Zlateva", false, null, "SOFIAZLATEVA@SPORTCENTERVICTORY.COM", "SOFIAZLATEVA@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEFCE/w8Yi2UmQATZRfesAeXe6mjTiHHXOZa+D0gYfX3hhGdpuRFUVqYKCkZp4zASSA==", null, false, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), "8ed041d4-b482-4ea0-a999-fc2668eb8ae0", false, "sofiazlateva@sportcentervictory.com" },
                    { new Guid("bc52f7d1-319c-4e02-bc81-9a2b1afdd438"), 0, "165cac33-97c9-4856-9aba-3fb93f676de2", "kristinadimitrova@sportcentervictory.com", true, "Kristina Dimitrova", false, null, "KRISTINADIMITROVA@SPORTCENTERVICTORY.COM", "KRISTINADIMITROVA@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEEOmTgbjjeEvAq/ADxn4DmXBj+ijut/lu+RdRxrr0GllN/grBCNyaBnoFNBPjDm+rw==", null, false, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), "dd431cf6-04fc-4725-978c-0218f6e291f8", false, "kristinadimitrova@sportcentervictory.com" },
                    { new Guid("bd8a4bc5-c170-4eb8-92b6-fb84bfcd26bd"), 0, "73df1f88-6261-4e0a-9658-b7d217f64a4e", "georgikolev@sportcentervictory.com", true, "Georgi Kolev", false, null, "GEORGIKOLEV@SPORTCENTERVICTORY.COM", "GEORGIKOLEV@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEL+7BSnCtuLSWNeFr8K0Ak0kZm20OOnWG5amAlyr2Av4PBJz5D0ta+kD+L5KBmlhQA==", null, false, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), "b3b70fea-9a48-4dba-9b17-4030a7ffc058", false, "georgikolev@sportcentervictory.com" },
                    { new Guid("c3777e33-e646-48a2-8e00-03058aa6e054"), 0, "b06635b8-c28b-4fa4-806d-8c2dc1ef5b31", "ivanpetrov@sportcentervictory.com", true, "Ivan Petrov", false, null, "IVANPETROV@SPORTCENTERVICTORY.COM", "IVANPETROV@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAENpI7A3W9uiuOcn/S3YAq8nx6eL/Q1iIcwZz51CJKNUr5mNlpq60Vjbc5oYz2rJRgw==", null, false, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), "4813cda0-6dda-4b93-b6b4-c2281eaafad9", false, "ivanpetrov@sportcentervictory.com" },
                    { new Guid("c3867b78-36a0-44b5-9800-f359a28d2965"), 0, "19cafcbe-d2ef-425b-ae14-72dffee09538", "ivandimitrov@sportcentervictory.com", true, "Ivan Dimitrov", false, null, "IVANDIMITROV@SPORTCENTERVICTORY.COM", "IVANDIMITROV@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEJyVVJIslzuscFL4me9fOCkDzrp5Qo8Fd6oSSAvpeZ1meXEEF5KSvy8AzCyw+JCElA==", null, false, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), "29178b7a-f947-4af6-a4a1-2d0aec3402ee", false, "ivandimitrov@sportcentervictory.com" },
                    { new Guid("d4fd993d-23fd-4832-9d51-d85a16efa5a8"), 0, "cf56bdfc-da56-4914-9895-3c3a76bd5591", "mariastefanova@sportcentervictory.com", true, "Maria Stefanova", false, null, "MARIASTEFANOVA@SPORTCENTERVICTORY.COM", "MARIASTEFANOVA@SPORTCENTERVICTORY.COM", "AQAAAAIAAYagAAAAEGZytAd6OZuyvrp02QKI6XH2vt3TOOg9GWyoblzB/pDQTl2uLaub1VOqCsrkjKhg+A==", null, false, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Utc), "681fdced-4ac9-497e-81d7-52d846c63ae0", false, "mariastefanova@sportcentervictory.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
