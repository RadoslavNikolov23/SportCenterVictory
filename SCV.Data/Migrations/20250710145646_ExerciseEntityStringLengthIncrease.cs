#nullable disable

namespace SCV.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;


    /// <inheritdoc />
    public partial class ExerciseEntityStringLengthIncrease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Mechanic",
                table: "Exercises",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                comment: "Mechanic of the exercise - compound, isolation, etc.",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true,
                oldComment: "Mechanic of the exercise - compound, isolation, etc.");

            migrationBuilder.AlterColumn<string>(
                name: "Force",
                table: "Exercises",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                comment: "Type of force applied in the exercise - push, pull, etc.",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "Type of force applied in the exercise - push, pull, etc.");

            migrationBuilder.AlterColumn<string>(
                name: "Equipment",
                table: "Exercises",
                type: "nvarchar(140)",
                maxLength: 140,
                nullable: true,
                comment: "Equipment used for the exercise - barbell, dumbbell, bodyweight, etc.",
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120,
                oldNullable: true,
                oldComment: "Equipment used for the exercise - barbell, dumbbell, bodyweight, etc.");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Exercises",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Category of the exercise - strength, cardio, flexibility, etc.",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Category of the exercise - strength, cardio, flexibility, etc.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Mechanic",
                table: "Exercises",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                comment: "Mechanic of the exercise - compound, isolation, etc.",
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true,
                oldComment: "Mechanic of the exercise - compound, isolation, etc.");

            migrationBuilder.AlterColumn<string>(
                name: "Force",
                table: "Exercises",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "Type of force applied in the exercise - push, pull, etc.",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true,
                oldComment: "Type of force applied in the exercise - push, pull, etc.");

            migrationBuilder.AlterColumn<string>(
                name: "Equipment",
                table: "Exercises",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true,
                comment: "Equipment used for the exercise - barbell, dumbbell, bodyweight, etc.",
                oldClrType: typeof(string),
                oldType: "nvarchar(140)",
                oldMaxLength: 140,
                oldNullable: true,
                oldComment: "Equipment used for the exercise - barbell, dumbbell, bodyweight, etc.");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Exercises",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Category of the exercise - strength, cardio, flexibility, etc.",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Category of the exercise - strength, cardio, flexibility, etc.");
        }
    }
}
