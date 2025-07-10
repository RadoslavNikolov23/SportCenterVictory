#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCV.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class SeedWorkoutPlans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkoutPlans",
                columns: new[] { "Id", "Description", "ImageUrl", "Title", "Type" },
                values: new object[,]
                {
                    { 1, "Day 1 – Upper Body\n- Push-Ups: 3 sets x 10 reps\n- Dumbbell Shoulder Press: 3 x 12\n- Bent Over Rows: 3 x 12\n- Plank: 3 x 30 sec\n\nDay 2 – Lower Body\n- Bodyweight Squats: 4 x 15\n- Glute Bridges: 3 x 20\n- Walking Lunges: 3 x 12 each leg\n- Standing Calf Raises: 3 x 20\n\nDay 3 – Core & Cardio\n- Russian Twists: 3 x 20\n- Bicycle Crunches: 3 x 15\n- Burpees: 3 x 10", null, "Full Body Burn – Beginner Fitness", 0 },
                    { 2, "Day 1 – Chest & Triceps\n- Bench Press: 4 x 10\n- Incline Dumbbell Press: 4 x 12\n- Triceps Dips: 3 x 15\n\nDay 2 – Back & Biceps\n- Deadlifts: 4 x 6\n- Lat Pulldowns: 4 x 12\n- Dumbbell Curls: 3 x 15\n\nDay 3 – Legs & Abs\n- Squats: 4 x 8\n- Romanian Deadlifts: 4 x 10\n- Hanging Leg Raises: 3 x 12", null, "Muscle Sculpt – Intermediate Fitness", 0 },
                    { 3, "4 Rounds for Time:\n- 30 sec Jump Squats\n- 20 Push-Ups\n- 40 Mountain Climbers\n- 20 Kettlebell Thrusters\n- 60 sec Rest between rounds\n\nFinish with 3 sets:\n- Crunches: 20 reps\n- Plank Hold: 60 sec", null, "Fat Blast HIIT – Fitness", 0 },
                    { 4, "AMRAP in 20 min:\n- 5 Pull-Ups\n- 10 Box Jumps (24”/20”)\n- 15 One-Arm Kettlebell Swings (10kg/16kg)\n- 200m Run\n\nCool Down:\n- Foam roll + Stretch 10 min\n- Deep Breathing 3 min", null, "CrossFit WOD – 'Grinder'", 1 },
                    { 5, "Day 1 – Squat Focus\n- Back Squat: 5 x 5 @ 80%\n- Front Squat: 3 x 5\n- Walking Lunges: 3 x 12 each leg\n\nDay 2 – Bench Focus\n- Bench Press: 5 x 5 @ 80%\n- Incline Press: 3 x 10\n- Triceps Pushdown: 3 x 15\n\nDay 3 – Deadlift Focus\n- Deadlift: 5 x 5 @ 80%\n- Barbell Rows: 3 x 10\n- Plank: 3 x 45 sec", null, "Powerlifting Split – Strength Phase", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
