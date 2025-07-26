#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCV.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class SeedWorkouPlans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorkoutPlans",
                columns: new[] { "Id", "Description", "ImageUrl", "Title", "Type" },
                values: new object[,]
                {
                    { new Guid("022aec47-1894-4b70-856b-64caece77676"), "Day 1 – Upper Body\n- Lat Pulldown: 3 sets x 8-10 reps\n- Bent Over Rows: 3 x 8-10 reps \n- Barbell Bench Press: 3 sets x 8-10 reps\n- Dumbbell Shoulder Press: 3 x 8-10 reps \n- Bicep Curl with dumbbells: 3 x 8-10 reps \n- Triceps Pushdown: 3 x 8-10 reps\n\nDay 2 – Lower Body\n- Squats: 3 x 8-10\n- Bodyweight Walking Lunges: 3 x 8-10 each leg\n- Lying Leg Curls: 3 x 8-10\n- Standing Calf Raises: 3 x 10\n- Plank: 3 x 30 sec\n- Crunches: 3 x 12-15 \n\nDay 3 – Optional Cardio or Rest day\n- For warm up: Burpees: 3 x 10\n- 20 minutes of walking on the Treadmill\nOr 20 minutes on the  Exercise bikes", "https://dl.dropboxusercontent.com/scl/fi/4dgg6mp2tjgvzv0pcqjiq/FullBodyBeginnerFitness.jpg?rlkey=clp3qppsk03ous2a93in8ukds&st=iu0a9e92", "Full Body – Beginner Fitness", 0 },
                    { new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2"), "Day 1 – Squat Focus\n- Back Squat: 5 x 5 @ 80%\n- Front Squat: 3 x 5\n- Walking Lunges: 3 x 12 each leg\n\nDay 2 – Bench Focus\n- Bench Press: 5 x 5 @ 80%\n- Incline Press: 3 x 10\n- Triceps Pushdown: 3 x 15\n\nDay 3 – Deadlift Focus\n- Deadlift: 5 x 5 @ 80%\n- Barbell Rows: 3 x 10\n- Plank: 3 x 45 sec", "https://dl.dropboxusercontent.com/scl/fi/sgl6jakmrh4zv6fw0fozm/PowerliftingSplit-Strength.jpg?rlkey=r4wjm06gry6w6jc2ggv2l27xb&st=ycdk52o7", "Powerlifting Split – Strength", 2 },
                    { new Guid("47c520d4-622c-4898-92e5-47041cd20fd7"), "4 Rounds for Time:\n- 30 sec Jump Squats\n- 20 Push-Ups\n- 40 Mountain Climbers\n- 20 Kettlebell Thrusters\n- 60 sec Rest between rounds\n\nFinish with 3 sets:\n- Crunches: 20 reps\n- Plank Hold: 60 sec", "https://dl.dropboxusercontent.com/scl/fi/luxe0zuskfqfaaqazsj7g/FatBlastHIITFitness.jpg?rlkey=1wgxbt3urb7rt6zxmw64dqqw1&st=rp2q1jm0", "Fat Blast HIIT – Fitness", 0 },
                    { new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd"), "Day 1 – Chest & Triceps\n- Bench Press: 4 x 6-8\n- Incline Dumbbell Press: 4 x 8-10\n- Cable Crossover: 4 x 10-12\n- EZ-Bar Skullcrusher: 3 x 8-10\n- Triceps Dips: 3 x 10-12\n\nDay 2 – Back & Biceps\n- Barbell Deadlift: 4 x 6\n- Lat Pulldowns: 4 x 10-12\n- Seated Cable Rows: 4 x 10-12- Dumbbell Curls: 3 x 8-10\n- Hammer Curls: 3 x 10-12\n\nDay 3 – Legs & Abs\n- Squats: 4 x 6\n- Romanian Deadlifts: 4 x 8-10\n- Leg Extensions: 4 x 10-12\n- Lying Leg Curls: 3 x 10-12\n- Ab Roller: 3 x 12\n- Hanging Leg Raises: 3 x 12", "https://dl.dropboxusercontent.com/scl/fi/6xw90evojamxwk6ewuwix/MuscleSculptIntermediateFitness.jpg?rlkey=a4e66pg3fv3d1mbsg4ch5937k&st=fxos16dd", "Muscle Sculpt – Intermediate Fitness", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: new Guid("022aec47-1894-4b70-856b-64caece77676"));

            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: new Guid("1b055049-3e04-424d-81d1-8efa83cd50c2"));

            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: new Guid("47c520d4-622c-4898-92e5-47041cd20fd7"));

            migrationBuilder.DeleteData(
                table: "WorkoutPlans",
                keyColumn: "Id",
                keyValue: new Guid("984a02e2-029d-44c1-855f-c90c056e3cdd"));
        }
    }
}
