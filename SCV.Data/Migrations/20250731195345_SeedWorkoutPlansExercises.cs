#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCV.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;


    /// <inheritdoc />
    public partial class SeedWorkoutPlansExercises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkoutPlanExercises",
                columns: new[] { "ExerciseId", "WorkoutPlanId" },
                values: new object[,]
                {
                    { "Ab_Roller", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") },
                    { "Barbell_Bench_Press_-_Medium_Grip", new Guid("022aec47-1894-4b70-856b-64caece77676") },
                    { "Barbell_Bench_Press_-_Medium_Grip", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") },
                    { "Barbell_Deadlift", new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2") },
                    { "Barbell_Deadlift", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") },
                    { "Barbell_Full_Squat", new Guid("022aec47-1894-4b70-856b-64caece77676") },
                    { "Barbell_Full_Squat", new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2") },
                    { "Barbell_Full_Squat", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") },
                    { "Barbell_Shoulder_Press", new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2") },
                    { "Bench_Press_-_Powerlifting", new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2") },
                    { "Bent_Over_Barbell_Row", new Guid("022aec47-1894-4b70-856b-64caece77676") },
                    { "Bent_Over_Barbell_Row", new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2") },
                    { "Bodyweight_Walking_Lunge", new Guid("022aec47-1894-4b70-856b-64caece77676") },
                    { "Bodyweight_Walking_Lunge", new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2") },
                    { "Cable_Crossover", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") },
                    { "Crunches", new Guid("022aec47-1894-4b70-856b-64caece77676") },
                    { "Crunches", new Guid("47c520d4-622c-4898-92e5-47041cd20fd7") },
                    { "Dips_-_Triceps_Version", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") },
                    { "Dumbbell_Bicep_Curl", new Guid("022aec47-1894-4b70-856b-64caece77676") },
                    { "Dumbbell_Bicep_Curl", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") },
                    { "Dumbbell_Shoulder_Press", new Guid("022aec47-1894-4b70-856b-64caece77676") },
                    { "EZ-Bar_Skullcrusher", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") },
                    { "Freehand_Jump_Squat", new Guid("47c520d4-622c-4898-92e5-47041cd20fd7") },
                    { "Front_Squat_Clean_Grip", new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2") },
                    { "Full_Range-Of-Motion_Lat_Pulldown", new Guid("022aec47-1894-4b70-856b-64caece77676") },
                    { "Full_Range-Of-Motion_Lat_Pulldown", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") },
                    { "Hammer_Curls", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") },
                    { "Hanging_Leg_Raise", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") },
                    { "Incline_Dumbbell_Press", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") },
                    { "Kettlebell_Thruster", new Guid("47c520d4-622c-4898-92e5-47041cd20fd7") },
                    { "Leg_Extensions", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") },
                    { "Lying_Leg_Curls", new Guid("022aec47-1894-4b70-856b-64caece77676") },
                    { "Lying_Leg_Curls", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") },
                    { "Mountain_Climbers", new Guid("47c520d4-622c-4898-92e5-47041cd20fd7") },
                    { "Plank", new Guid("022aec47-1894-4b70-856b-64caece77676") },
                    { "Plank", new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2") },
                    { "Plank", new Guid("47c520d4-622c-4898-92e5-47041cd20fd7") },
                    { "Pushups", new Guid("47c520d4-622c-4898-92e5-47041cd20fd7") },
                    { "Romanian_Deadlift", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") },
                    { "Seated_Cable_Rows", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") },
                    { "Standing_Calf_Raises", new Guid("022aec47-1894-4b70-856b-64caece77676") },
                    { "Triceps_Pushdown", new Guid("022aec47-1894-4b70-856b-64caece77676") },
                    { "Triceps_Pushdown", new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Ab_Roller", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Barbell_Bench_Press_-_Medium_Grip", new Guid("022aec47-1894-4b70-856b-64caece77676") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Barbell_Bench_Press_-_Medium_Grip", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Barbell_Deadlift", new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Barbell_Deadlift", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Barbell_Full_Squat", new Guid("022aec47-1894-4b70-856b-64caece77676") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Barbell_Full_Squat", new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Barbell_Full_Squat", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Barbell_Shoulder_Press", new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Bench_Press_-_Powerlifting", new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Bent_Over_Barbell_Row", new Guid("022aec47-1894-4b70-856b-64caece77676") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Bent_Over_Barbell_Row", new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Bodyweight_Walking_Lunge", new Guid("022aec47-1894-4b70-856b-64caece77676") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Bodyweight_Walking_Lunge", new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Cable_Crossover", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Crunches", new Guid("022aec47-1894-4b70-856b-64caece77676") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Crunches", new Guid("47c520d4-622c-4898-92e5-47041cd20fd7") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Dips_-_Triceps_Version", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Dumbbell_Bicep_Curl", new Guid("022aec47-1894-4b70-856b-64caece77676") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Dumbbell_Bicep_Curl", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Dumbbell_Shoulder_Press", new Guid("022aec47-1894-4b70-856b-64caece77676") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "EZ-Bar_Skullcrusher", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Freehand_Jump_Squat", new Guid("47c520d4-622c-4898-92e5-47041cd20fd7") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Front_Squat_Clean_Grip", new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Full_Range-Of-Motion_Lat_Pulldown", new Guid("022aec47-1894-4b70-856b-64caece77676") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Full_Range-Of-Motion_Lat_Pulldown", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Hammer_Curls", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Hanging_Leg_Raise", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Incline_Dumbbell_Press", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Kettlebell_Thruster", new Guid("47c520d4-622c-4898-92e5-47041cd20fd7") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Leg_Extensions", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Lying_Leg_Curls", new Guid("022aec47-1894-4b70-856b-64caece77676") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Lying_Leg_Curls", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Mountain_Climbers", new Guid("47c520d4-622c-4898-92e5-47041cd20fd7") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Plank", new Guid("022aec47-1894-4b70-856b-64caece77676") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Plank", new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Plank", new Guid("47c520d4-622c-4898-92e5-47041cd20fd7") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Pushups", new Guid("47c520d4-622c-4898-92e5-47041cd20fd7") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Romanian_Deadlift", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Seated_Cable_Rows", new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Standing_Calf_Raises", new Guid("022aec47-1894-4b70-856b-64caece77676") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Triceps_Pushdown", new Guid("022aec47-1894-4b70-856b-64caece77676") });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Triceps_Pushdown", new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2") });
        }
    }
}
