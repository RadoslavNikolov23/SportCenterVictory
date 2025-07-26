#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCV.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class SeedTrainerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "ApplicationUserId", "Bio", "Email", "FirstName", "ImageUrl", "LastName", "PhoneNumber", "TrainerSpecialty" },
                values: new object[,]
                {
                    { new Guid("0920b615-dd7d-46f5-b238-3ba891569b44"), null, "Advanced strength trainer focused on Olympic lifts and powerlifting competition prep.", "stefan.todorov@sportvictory.bg", "Stefan", "https://dl.dropboxusercontent.com/scl/fi/8vv5awc3b5v628oqm24p3/stefanTodorov.jpg?rlkey=nwujirkrn5tiph3i2xlknhhhg&st=m8ei3c8h", "Todorov", "+359887123321", 2 },
                    { new Guid("1ee19866-6828-412c-80f7-4572630f2a89"), null, "Focused on mobility, recovery, and competitive CrossFit coaching.", "georgi.kolev@sportvictory.bg", "Georgi", "https://dl.dropboxusercontent.com/scl/fi/gn09i29am96yme3e60gat/georgiKolev.jpg?rlkey=1784rc6kdkbwz5toq6pr9or24&st=we01oweu", "Kolev", "+359886998877", 1 },
                    { new Guid("59015526-c85d-41f8-9550-e8822a1ee4b4"), null, "Female powerlifting coach with a passion for strength training and mental toughness.", "kristina.dimitrova@sportvictory.bg", "Kristina", "https://dl.dropboxusercontent.com/scl/fi/fsjqeh2k5pslctikgpes5/kristinaDimitrova.jpg?rlkey=6zo6cp7lqt6nujvw684yuxcwo&st=1vyz0to8", "Dimitrova", "+359889332211", 2 },
                    { new Guid("948af76c-23f3-4487-a245-c011e58a73db"), null, "Certified fitness instructor and personal coach with a focus on fat loss and cardio endurance.", "viktor.nachev@sportvictory.bg", "Viktor", "https://dl.dropboxusercontent.com/scl/fi/v2mpcel8c6bvoj2bdcutd/victorNachev.jpg?rlkey=ru9niacljhtqsb5dhrm090ad8&st=tt7nodi4", "Nachev", null, 0 },
                    { new Guid("b59e1fd1-f514-4f18-93f0-1d8b7992ce41"), null, "Certified CrossFit Level 2 coach with 7 years of experience in functional training.", "ivan.dimitrov@svc.bg", "Ivan", "https://dl.dropboxusercontent.com/scl/fi/e5y5vnvznfeszajgbckto/ivanDimitrov.jpg?rlkey=gdgyjql76d2nzslay3tc9qu3l&st=5ev7xmwo", "Dimitrov", "+359888123456", 1 },
                    { new Guid("d270b6ba-60d3-4aee-8ebf-1f2591ebe17b"), null, "Enthusiastic trainer offering tailored programs for male and female fitness and weight training.", "desislav.iliev@sportvictory.bg", "Desislav", "https://dl.dropboxusercontent.com/scl/fi/p3w30h9aed73uhnu3d8b2/desislavIliev.jpg?rlkey=yu8697u4p6m04wt184mcaesas&st=w3ykg2yg", "Iliev", "+359883456789", 0 },
                    { new Guid("e2a0a45f-bbe7-468e-b697-17dbcd793c79"), null, "Creative Fitness coach with a love for community building and mental resilience.", "sofia.zlateva@sportvictory.bg", "Sofia", "https://dl.dropboxusercontent.com/scl/fi/8ossdlus3e6dk377nelgh/sofiaZlateva.jpg?rlkey=3uioardtahbua1fbqzspqlmgn&st=a8o202s3", "Zlateva", "+359888765432", 0 },
                    { new Guid("ec83a001-55df-45e5-b8c4-91f4d76f9fd0"), null, "CrossFit expert with over 10 years of personal training experience.", "maya.ivanova@svc.bg", "Maya", "https://dl.dropboxusercontent.com/scl/fi/5r4647d65hhepuej53vph/mayaIvanova.jpg?rlkey=t8bx9y25h9krf6r83atfomoq4&st=e2cb8kc2", "Ivanova", "+359885987654", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
