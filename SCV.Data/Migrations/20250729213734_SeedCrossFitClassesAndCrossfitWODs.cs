#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCV.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class SeedCrossFitClassesAndCrossfitWODs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CrossfitClasses",
                columns: new[] { "Id", "DayOfWeek", "Description", "Name", "StartTime", "TrainerName" },
                values: new object[,]
                {
                    { new Guid("43c892c1-6fd9-409e-82e8-4b38eedcbed5"), 1, "Enhance flexibility and mobility to improve overall performance.", "CrossFit Mobility", "Tuesday at 18:00", "Maya Ivanova" },
                    { new Guid("55ea312a-2607-432a-beaa-88cdae84261d"), 1, "Cardio-focused CrossFit session to build stamina and VO2 max.", "CrossFit Endurance", "Tuesday at 19:00", "Ivan Dimitrov" },
                    { new Guid("621d28e0-4142-4ba6-a754-a0f3537548e3"), 0, "Focus on building strength with heavy lifts and compound movements.", "CrossFit Strength", "Monday at 19:00", "Georgi Kolev" },
                    { new Guid("6b0d85a4-6707-4c9b-8759-132ec7512afe"), 5, "Classes teaching technique and power development in snatch and clean and jerk.", "CrossFit Olympic Lifting", "Saturday at 17:00", "Guest Coach: Tsvetan Nikolov" },
                    { new Guid("7724554f-7f07-49f5-a7e2-5cc81e77a81a"), 2, "Team-based workout to build camaraderie and competitive spirit.", "CrossFit Team Challenge", "Wednesday at 17:00", "Georgi Kolev" },
                    { new Guid("7aa86503-08e5-4d0f-a76e-331652c9235b"), 0, "A high-intensity Hero WOD designed to test endurance and mental toughness.", "WOD: Hero Workout", "Monday at 17:00", "Ivan Dimitrov" },
                    { new Guid("a67e482d-ede8-491b-8f71-eeb4b3ecefbc"), 4, "Introduction to CrossFit movements and techniques for beginners.", "CrossFit Basics", "Friday at 18:00", "Maya Ivanova" },
                    { new Guid("c33e1e9d-1a72-47d5-8e53-8ed00d668785"), 5, "Specialized training session to prepare for the CrossFit Open competition.", "CrossFit Open Prep", "Saturday at 10:00", "Guest Coach: Stoyan Dimitrov" }
                });

            migrationBuilder.InsertData(
                table: "CrossfitWorkoutOfTheDays",
                columns: new[] { "Id", "DescriptionHTML", "DescriptionPlain", "Name", "WorkoutDate" },
                values: new object[,]
                {
                    { new Guid("0940e1fb-1329-40cc-940b-66a27289bad2"), "<p><strong>Part 1</strong><br>\nIn 10 minutes:<br>\nEstablish a 2-rep-max shoulder press</p>\n\n<p>3 minutes rest</p>\n\n<p><strong>Part 2</strong><br>\nAs many calories as possible in 10 minutes of:<br>\nEcho bike</p>\n\n<p>Post to comments:<br>\n1. Max weight lifted on the shoulder press in pounds<br>\n2. Total calories completed on the bike<br>\n3. Total weight + calories</p>\n\n<p><strong>Stimulus and Strategy:</strong><br>\nThis two-part workout will test upper-body pressing strength, as well as general conditioning. Start at a light load in the shoulder press and build up quickly to establish a 2-rep max for the day with sound mechanics. New athletes can focus on mechanics and keep the loads sub-maximal. Ten minutes on the bike will feel like a LONG TIME where you are at your threshold for a large portion of the workout. Set a goal cadence to maintain and treat the last minute as a final sprint to the finish.</p>\n\n<p><strong>Scaling:</strong><br>\nReduce the time on the Echo bike in Part 2.</p>\n\n<p>To reduce the complexity of the shoulder presses, consider using a pair of dumbbells. This will eliminate the need to navigate the head and reduce the complexity of the rack position.</p>\n\n<p>In case of injury or limitation, perform bench presses or floor presses in place of the shoulder presses. If necessary, consider single-dumbbell shoulder presses. For the max calories in Part 2, use any machine available.</p>\n\n<p><strong>Intermediate option:</strong><br>\nSame as Rx’d.</p>\n\n<p><strong>Beginner option:</strong><br>\nSame as Rx’d.</p>\n\n<p><strong>Coaching cues:</strong><br>\nKeep your abdominals, glutes, and quadriceps tight throughout the shoulder press to reduce issues of overextending the trunk.</p>", "Part 1\nIn 10 minutes:\nEstablish a 2-rep-max shoulder press\n\n3 minutes rest\n\nPart 2\nAs many calories as possible in 10 minutes of:\nEcho bike\n\nPost to comments:\n1. Max weight lifted on the shoulder press in pounds\n2. Total calories completed on the bike\n3. Total weight + calories\n\nStimulus and Strategy:\nThis two-part workout will test upper-body pressing strength, as well as general conditioning. Start at a light load in the shoulder press and build up quickly to establish a 2-rep max for the day with sound mechanics. New athletes can focus on mechanics and keep the loads sub-maximal. Ten minutes on the bike will feel like a LONG TIME where you are at your threshold for a large portion of the workout. Set a goal cadence to maintain and treat the last minute as a final sprint to the finish.\n\nScaling:\nReduce the time on the Echo bike in Part 2.\n\nTo reduce the complexity of the shoulder presses, consider using a pair of dumbbells. This will eliminate the need to navigate the head and reduce the complexity of the rack position.\n\nIn case of injury or limitation, perform bench presses or floor presses in place of the shoulder presses. If necessary, consider single-dumbbell shoulder presses. For the max calories in Part 2, use any machine available.\n\nIntermediate option:\nSame as Rx’d.\n\nBeginner option:\nSame as Rx’d.\n\nCoaching cues:\nKeep your abdominals, glutes, and quadriceps tight throughout the shoulder press to reduce issues of overextending the trunk.", "Wednesday/250726", new DateTime(2025, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7e45fff5-e83f-48b1-bb99-90fc46f9ec08"), "<p><strong>Triple Deuce</strong></p><p>As many rounds and reps as possible in 20 minutes of:<br>22 burpees<br>22 air squats<br>22 pull-ups<br>22 sandbag ground-to-over-the-shoulders<br>722-meter run</p><p>♀ 40-lb sandbag<br>♂ 60-lb sandbag</p><p>Post rounds and reps to comments.</p><p>Army Sgt. 1st Class Jamie Nicholas, Army Sgt. 1st Class Gary Vasquez, and Army Capt. Richard Cliff, Jr., assigned to the 1st Battalion, 7th Special Forces Group in Fort Bragg, North Carolina, died Sept. 29, 2008, in Yakhchal, Afghanistan, from wounds sustained when their vehicle encountered an improvised explosive device during mounted operations.</p><p><strong>Stimulus and Strategy:</strong><br>This Hero workout will test cardiorespiratory endurance and stamina, where completing 3 or more rounds is a general guideline to follow. Since this is a Hero workout, feel free to attempt it as prescribed, even if 3 rounds may not be within reach. The air squats can be performed quickly, while the burpees and pull-ups may need some pacing to be able to complete them at a consistent pace. The sandbag is intended to be light so 22 reps can be completed with minimal rest between each.</p><p><strong>Scaling:</strong><br>Reduce the loading of the sandbag. Reduce the reps of the movements. Reduce the distance of the run.</p><p>To reduce the complexity of the burpees, perform up-downs. For the pull-ups, consider performing jumping pull-ups or ring rows. For the sandbag ground-to-over-the-shoulders, perform dumbbell power cleans, hang power cleans, or even light medicine-ball cleans over the shoulder</p><p>In case of injury or limitation, perform a 1,750/2,500-meter Echo bike or 800/1,000-meter row in place of the 722-meter run. For the air squats, consider squatting to a target that allows for a pain-free range of motion.</p><p><strong>Intermediate option:</strong><br>As many rounds and reps as possible in 20 minutes of:<br><strong>15</strong> burpees<br><strong>15</strong> air squats<br><strong>15 jumping</strong> pull-ups<br><strong>15</strong> sandbag ground-to-over-the-shoulders<br>722-meter run</p><p>♀ <strong>30</strong>-lb sandbag<br>♂ <strong>45</strong>-lb sandbag</p><p><strong>Beginner option:</strong><br>As many rounds and reps as possible in <strong>15</strong> minutes of:<br><strong>12</strong> burpees<br><strong>12</strong> air squats<br><strong>12 ring rows</strong><br><strong>12</strong> sandbag ground-to-over-the-shoulders<br><strong>400</strong>-meter run</p><p>♀ <strong>20</strong>-lb sandbag<br>♂ <strong>30</strong>-lb sandbag</p><p><strong>Coaching cues:</strong><br>Focus on using your hips and legs to launch the sandbag over your shoulders instead of solely pulling with your arms.</p>", "Triple Deuce\n\nAs many rounds and reps as possible in 20 minutes of:\n22 burpees\n22 air squats\n22 pull-ups\n22 sandbag ground-to-over-the-shoulders\n722-meter run\n\n♀ 40-lb sandbag\n♂ 60-lb sandbag\n\nPost rounds and reps to comments.\n\nArmy Sgt. 1st Class Jamie Nicholas, Army Sgt. 1st Class Gary Vasquez, and Army Capt. Richard Cliff, Jr., assigned to the 1st Battalion, 7th Special Forces Group in Fort Bragg, North Carolina, died Sept. 29, 2008, in Yakhchal, Afghanistan, from wounds sustained when their vehicle encountered an improvised explosive device during mounted operations.\n\nStimulus and Strategy:\nThis Hero workout will test cardiorespiratory endurance and stamina, where completing 3 or more rounds is a general guideline to follow. Since this is a Hero workout, feel free to attempt it as prescribed, even if 3 rounds may not be within reach. The air squats can be performed quickly, while the burpees and pull-ups may need some pacing to be able to complete them at a consistent pace. The sandbag is intended to be light so 22 reps can be completed with minimal rest between each.\n\nScaling:\nReduce the loading of the sandbag. Reduce the reps of the movements. Reduce the distance of the run.\n\nTo reduce the complexity of the burpees, perform up-downs. For the pull-ups, consider performing jumping pull-ups or ring rows. For the sandbag ground-to-over-the-shoulders, perform dumbbell power cleans, hang power cleans, or even light medicine-ball cleans over the shoulder\n\nIn case of injury or limitation, perform a 1,750/2,500-meter Echo bike or 800/1,000-meter row in place of the 722-meter run. For the air squats, consider squatting to a target that allows for a pain-free range of motion.\n\nIntermediate option:\nAs many rounds and reps as possible in 20 minutes of:\n15 burpees\n15 air squats\n15 jumping pull-ups\n15 sandbag ground-to-over-the-shoulders\n722-meter run\n\n♀ 30-lb sandbag\n♂ 45-lb sandbag\n\nBeginner option:\nAs many rounds and reps as possible in 15 minutes of:\n12 burpees\n12 air squats\n12 ring rows\n12 sandbag ground-to-over-the-shoulders\n400-meter run\n\n♀ 20-lb sandbag\n♂ 30-lb sandbag\n\nCoaching cues:\nFocus on using your hips and legs to launch the sandbag over your shoulders instead of solely pulling with your arms.", "Friday/250727", new DateTime(2025, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("91a4bb71-3c90-46aa-8a66-a9ce3ca67907"), "<p>For time:<br>\n21 GHD sit-ups<br>\n7 rope climbs to 15 feet<br>\n21 GHD sit-ups<br>\n21-meter double-kettlebell front-rack walking lunge<br>\n15 GHD sit-ups<br>\n5 rope climbs to 15 feet<br>\n15 GHD sit-ups<br>\n15-meter double-kettlebell front-rack walking lunge<br>\n9 GHD sit-ups<br>\n3 rope climbs to 15 feet<br>\n9 GHD sit-ups<br>\n9-meter double-kettlebell front-rack walking lunge</p>\n\n<p>♀ 35-lb kettlebells<br>\n♂ 53-lb kettlebells</p>\n\n<p>Post time to comments.</p>\n\n<p><strong>Stimulus and Strategy:</strong><br>\nExpect this conditioning workout to challenge the trunk and legs, as well as the skill of the rope climb. The GHD sit-up volume is reasonable, but expect this movement to increase the difficulty of the knee raise component of the rope climbs, as well as the core demands of the kettlebell front-rack walking lunges. The load of the kettlebells is intended to be moderate, where the initial round can be completed unbroken or with one break.</p>\n\n<p><strong>Scaling:</strong><br>\nReduce the loading of the kettlebells. Reduce the reps of the GHD sit-ups and rope climbs.</p>\n\n<p>To reduce the complexity of the GHD sit-ups, reduce the range of motion. For the rope climbs, reduce the height of the climb. For the kettlebell front-rack lunges, perform the lunges with a single kettlebell or hold the two kettlebells in the farmers carry position.</p>\n\n<p>In case of injury or limitation, perform sit-ups or V-ups in place of the GHD sit-ups. For the rope climbs, perform pull-to-stands. For the kettlebell front-rack lunges, eliminate the loading or consider step-ups to a low box.</p>\n\n<p><strong>Intermediate option:</strong><br>\nFor time:<br>\n<strong>15</strong> GHD sit-ups<br>\n7 rope climbs to <strong>12</strong> feet<br>\n<strong>15</strong> GHD sit-ups<br>\n<strong>15</strong>-meter double-kettlebell front-rack walking lunge<br>\n<strong>12</strong> GHD sit-ups<br>\n5 rope climbs to <strong>12</strong> feet<br>\n<strong>12</strong> GHD sit-ups<br>\n<strong>12</strong>-meter double-kettlebell front-rack walking lunge<br>\n9 GHD sit-ups<br>\n3 rope climbs to <strong>12</strong> feet<br>\n9 GHD sit-ups<br>\n9-meter double-kettlebell front-rack walking lunge</p>\n\n<p>♀ <strong>26</strong>-lb kettlebells<br>\n♂ <strong>36</strong>-lb kettlebells</p>\n\n<p><strong>Beginner option:</strong><br>\nFor time:<br>\n<strong>15 AbMat</strong> sit-ups<br>\n<strong>5 pull-to-stands</strong><br>\n<strong>15 AbMat</strong> sit-ups<br>\n<strong>15</strong>-meter <strong>walking lunge</strong><br>\n<strong>12 AbMat</strong> sit-ups<br>\n<strong>4 pull-to-stands</strong><br>\n<strong>12 AbMat</strong> sit-ups<br>\n<strong>12</strong>-meter <strong>walking lunge</strong><br>\n9 <strong>AbMat</strong> sit-ups<br>\n3 <strong>pull-to-stands</strong><br>\n9 <strong>AbMat</strong> sit-ups<br>\n9-meter <strong>walking lunge</strong></p>\n\n<p><strong>Coaching cues:</strong><br>\nTreat the rope climb as a stand or squat after securing the wrap instead of pulling with the arms. In the warm-up, practice establishing a secure foot hook before standing up and reaching for the next pull. This will reduce the risk of unnecessary foot sliding as you are climbing.</p>\n", "For time:\n21 GHD sit-ups\n7 rope climbs to 15 feet\n21 GHD sit-ups\n21-meter double-kettlebell front-rack walking lunge\n15 GHD sit-ups\n5 rope climbs to 15 feet\n15 GHD sit-ups\n15-meter double-kettlebell front-rack walking lunge\n9 GHD sit-ups\n3 rope climbs to 15 feet\n9 GHD sit-ups\n9-meter double-kettlebell front-rack walking lunge\n\n♀ 35-lb kettlebells\n♂ 53-lb kettlebells\n\nPost time to comments.\n\nStimulus and Strategy:\nExpect this conditioning workout to challenge the trunk and legs, as well as the skill of the rope climb. The GHD sit-up volume is reasonable, but expect this movement to increase the difficulty of the knee raise component of the rope climbs, as well as the core demands of the kettlebell front-rack walking lunges. The load of the kettlebells is intended to be moderate, where the initial round can be completed unbroken or with one break.\n\nScaling:\nReduce the loading of the kettlebells. Reduce the reps of the GHD sit-ups and rope climbs.\n\nTo reduce the complexity of the GHD sit-ups, reduce the range of motion. For the rope climbs, reduce the height of the climb. For the kettlebell front-rack lunges, perform the lunges with a single kettlebell or hold the two kettlebells in the farmers carry position.\n\nIn case of injury or limitation, perform sit-ups or V-ups in place of the GHD sit-ups. For the rope climbs, perform pull-to-stands. For the kettlebell front-rack lunges, eliminate the loading or consider step-ups to a low box.\n\nIntermediate option:\nFor time:\n15 GHD sit-ups\n7 rope climbs to 12 feet\n15 GHD sit-ups\n15-meter double-kettlebell front-rack walking lunge\n12 GHD sit-ups\n5 rope climbs to 12 feet\n12 GHD sit-ups\n12-meter double-kettlebell front-rack walking lunge\n9 GHD sit-ups\n3 rope climbs to 12 feet\n9 GHD sit-ups\n9-meter double-kettlebell front-rack walking lunge\n\n♀ 26-lb kettlebells\n♂ 36-lb kettlebells\n\nBeginner option:\nFor time:\n15 AbMat sit-ups\n5 pull-to-stands\n15 AbMat sit-ups\n15-meter walking lunge\n12 AbMat sit-ups\n4 pull-to-stands\n12 AbMat sit-ups\n12-meter walking lunge\n9 AbMat sit-ups\n3 pull-to-stands\n9 AbMat sit-ups\n9-meter walking lunge\n\nCoaching cues:\nTreat the rope climb as a stand or squat after securing the wrap instead of pulling with the arms. In the warm-up, practice establishing a secure foot hook before standing up and reaching for the next pull. This will reduce the risk of unnecessary foot sliding as you are climbing.\n", "Tuesday/250725", new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CrossfitClasses",
                keyColumn: "Id",
                keyValue: new Guid("43c892c1-6fd9-409e-82e8-4b38eedcbed5"));

            migrationBuilder.DeleteData(
                table: "CrossfitClasses",
                keyColumn: "Id",
                keyValue: new Guid("55ea312a-2607-432a-beaa-88cdae84261d"));

            migrationBuilder.DeleteData(
                table: "CrossfitClasses",
                keyColumn: "Id",
                keyValue: new Guid("621d28e0-4142-4ba6-a754-a0f3537548e3"));

            migrationBuilder.DeleteData(
                table: "CrossfitClasses",
                keyColumn: "Id",
                keyValue: new Guid("6b0d85a4-6707-4c9b-8759-132ec7512afe"));

            migrationBuilder.DeleteData(
                table: "CrossfitClasses",
                keyColumn: "Id",
                keyValue: new Guid("7724554f-7f07-49f5-a7e2-5cc81e77a81a"));

            migrationBuilder.DeleteData(
                table: "CrossfitClasses",
                keyColumn: "Id",
                keyValue: new Guid("7aa86503-08e5-4d0f-a76e-331652c9235b"));

            migrationBuilder.DeleteData(
                table: "CrossfitClasses",
                keyColumn: "Id",
                keyValue: new Guid("a67e482d-ede8-491b-8f71-eeb4b3ecefbc"));

            migrationBuilder.DeleteData(
                table: "CrossfitClasses",
                keyColumn: "Id",
                keyValue: new Guid("c33e1e9d-1a72-47d5-8e53-8ed00d668785"));

            migrationBuilder.DeleteData(
                table: "CrossfitWorkoutOfTheDays",
                keyColumn: "Id",
                keyValue: new Guid("0940e1fb-1329-40cc-940b-66a27289bad2"));

            migrationBuilder.DeleteData(
                table: "CrossfitWorkoutOfTheDays",
                keyColumn: "Id",
                keyValue: new Guid("7e45fff5-e83f-48b1-bb99-90fc46f9ec08"));

            migrationBuilder.DeleteData(
                table: "CrossfitWorkoutOfTheDays",
                keyColumn: "Id",
                keyValue: new Guid("91a4bb71-3c90-46aa-8a66-a9ce3ca67907"));
        }
    }
}
