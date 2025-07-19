#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCV.Data.Migrations
{
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
                    { "Barbell_Bench_Press_-_Medium_Grip", 2 },
                    { "Barbell_Deadlift", 2 },
                    { "Barbell_Deadlift", 5 },
                    { "Barbell_Full_Squat", 2 },
                    { "Barbell_Full_Squat", 5 },
                    { "Barbell_Glute_Bridge", 1 },
                    { "Barbell_Shoulder_Press", 5 },
                    { "Bench_Press_-_Powerlifting", 5 },
                    { "Bent_Over_Barbell_Row", 1 },
                    { "Bent_Over_Barbell_Row", 5 },
                    { "Bodyweight_Squat", 1 },
                    { "Bodyweight_Walking_Lunge", 1 },
                    { "Bodyweight_Walking_Lunge", 5 },
                    { "Cable_Russian_Twists", 1 },
                    { "Crunches", 3 },
                    { "Dips_-_Triceps_Version", 2 },
                    { "Dumbbell_Shoulder_Press", 1 },
                    { "Flexor_Incline_Dumbbell_Curls", 2 },
                    { "Freehand_Jump_Squat", 3 },
                    { "Front_Box_Jump", 4 },
                    { "Front_Squat_Clean_Grip", 5 },
                    { "Full_Range-Of-Motion_Lat_Pulldown", 2 },
                    { "Hanging_Leg_Raise", 2 },
                    { "Incline_Dumbbell_Press", 2 },
                    { "Kettlebell_Thruster", 3 },
                    { "Mountain_Climbers", 3 },
                    { "One-Arm_Kettlebell_Swings", 4 },
                    { "Plank", 1 },
                    { "Plank", 3 },
                    { "Plank", 5 },
                    { "Pullups", 4 },
                    { "Pushups", 1 },
                    { "Pushups", 3 },
                    { "Romanian_Deadlift", 2 },
                    { "Triceps_Pushdown", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Barbell_Bench_Press_-_Medium_Grip", 2 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Barbell_Deadlift", 2 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Barbell_Deadlift", 5 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Barbell_Full_Squat", 2 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Barbell_Full_Squat", 5 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Barbell_Glute_Bridge", 1 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Barbell_Shoulder_Press", 5 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Bench_Press_-_Powerlifting", 5 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Bent_Over_Barbell_Row", 1 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Bent_Over_Barbell_Row", 5 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Bodyweight_Squat", 1 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Bodyweight_Walking_Lunge", 1 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Bodyweight_Walking_Lunge", 5 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Cable_Russian_Twists", 1 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Crunches", 3 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Dips_-_Triceps_Version", 2 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Dumbbell_Shoulder_Press", 1 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Flexor_Incline_Dumbbell_Curls", 2 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Freehand_Jump_Squat", 3 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Front_Box_Jump", 4 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Front_Squat_Clean_Grip", 5 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Full_Range-Of-Motion_Lat_Pulldown", 2 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Hanging_Leg_Raise", 2 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Incline_Dumbbell_Press", 2 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Kettlebell_Thruster", 3 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Mountain_Climbers", 3 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "One-Arm_Kettlebell_Swings", 4 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Plank", 1 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Plank", 3 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Plank", 5 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Pullups", 4 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Pushups", 1 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Pushups", 3 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Romanian_Deadlift", 2 });

            migrationBuilder.DeleteData(
                table: "WorkoutPlanExercises",
                keyColumns: new[] { "ExerciseId", "WorkoutPlanId" },
                keyValues: new object[] { "Triceps_Pushdown", 5 });
        }
    }
}
