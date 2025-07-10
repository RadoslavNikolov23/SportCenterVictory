#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCV.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class SeedCrossfitClassesAndCrossfitWODs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CrossfitClasses",
                columns: new[] { "Id", "ApplicationUserId", "Description", "Name", "StartTime", "TrainerName" },
                values: new object[,]
                {
                    { 1, null, "A high-intensity Hero WOD designed to test endurance and mental toughness.", "WOD: Hero Workout", "Monday at 17:00", "Ivan Dimitrov" },
                    { 2, null, "Focus on building strength with heavy lifts and compound movements.", "CrossFit Strength", "Monday at 19:00", "Georgi Kolev" },
                    { 3, null, "Enhance flexibility and mobility to improve overall performance.", "CrossFit Mobility", "Tuesday at 18:00", "Maya Ivanova" },
                    { 4, null, "Team-based workout to build camaraderie and competitive spirit.", "CrossFit Team Challenge", "Wednesday at 17:00", "Georgi Kolev" },
                    { 5, null, "Cardio-focused CrossFit session to build stamina and VO2 max.", "CrossFit Endurance", "Thuesday at 19:00", "Ivan Dimitrov" },
                    { 6, null, "Introduction to CrossFit movements and techniques for beginners.", "CrossFit Basics", "Friday at 18:00", "Maya Ivanova" },
                    { 7, null, "Specialized training session to prepare for the CrossFit Open competition.", "CrossFit Open Prep", "Saturday at 10:00", "Guest Coach: Stoyan Dimitrov" },
                    { 8, null, "Classes teaching technique and power development in snatch and clean and jerk.", "CrossFit Olympic Lifting", "Saturday at 17:00", "Guest Coach: Tsvetan Nikolov" }
                });

            migrationBuilder.InsertData(
                table: "CrossfitWorkoutOfTheDays",
                columns: new[] { "Id", "DescriptionHTML", "DescriptionPlain", "Name", "WorkoutDate" },
                values: new object[,]
                {
                    { 1, "<p><strong>Triple Deuce</strong></p><p>As many rounds and reps as possible in 20 minutes of:<br>22 burpees<br>22 air squats<br>22 pull-ups<br>22 sandbag ground-to-over-the-shoulders<br>722-meter run</p>...", "Triple Deuce\n\nAs many rounds and reps as possible in 20 minutes of:\n22 burpees\n22 air squats\n22 pull-ups\n22 sandbag ground-to-over-the-shoulders\n722-meter run\n\n♀ 40-lb sandbag\n♂ 60-lb sandbag\n\nPost rounds and reps to comments.\n\nArmy Sgt. 1st Class Jamie Nicholas...", "Friday/250704", new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "<p>5 rounds, each for time, of:<br>500-meter row</p><p>Rest 3 minutes between efforts.</p><p>Post times to the comments.</p>...", "5 rounds, each for time, of:\n500-meter row\n\nRest 3 minutes between efforts.\n\nPost times to the comments.\n\nStimulus and Strategy:\nToday’s workout consists of 5 all-out sprints on the rower...", "Saturday/250705", new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "<p><strong>Rest Day</strong></p><p><a href=\"https://youtu.be/aqHQ6hpiXdk\">Why We Plateau and How to Overcome It</a></p>...", "Rest Day\n\nWhy We Plateau and How to Overcome It\n\nJoin CrossFit coaches Eric O'Connor and Pat Barber as they break down the real reasons athletes hit plateaus and the proven strategies to push past them...", "Sunday/250706", new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CrossfitClasses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CrossfitClasses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CrossfitClasses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CrossfitClasses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CrossfitClasses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CrossfitClasses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CrossfitClasses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CrossfitClasses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CrossfitWorkoutOfTheDays",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CrossfitWorkoutOfTheDays",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CrossfitWorkoutOfTheDays",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
