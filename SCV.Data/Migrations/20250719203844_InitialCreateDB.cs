#nullable disable

namespace SCV.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class InitialCreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, comment: "Full name of the user"),
                    RegisteredOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date the user is register On the site"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                },
                comment: "Application user model that extends IdentityUser");

            migrationBuilder.CreateTable(
                name: "CrossfitWorkoutOfTheDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key for the workout of the day")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false, comment: "Name of the workout of the day - will contain part of the WorkoutDate"),
                    WorkoutDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date when the workout of the day is scheduled"),
                    DescriptionPlain = table.Column<string>(type: "nvarchar(max)", maxLength: 6025, nullable: false, comment: "Plain text description of the workout of the day"),
                    DescriptionHTML = table.Column<string>(type: "nvarchar(max)", maxLength: 7025, nullable: false, comment: "HTML formatted description of the workout of the day")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrossfitWorkoutOfTheDays", x => x.Id);
                },
                comment: "Represents a Crossfit Workout of the Day (WOD)");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key for the event")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Title of the event, e.g., 'CrossFit Regional Challenge'"),
                    EventType = table.Column<int>(type: "int", nullable: false, comment: "Type of the event - Fitness, CrossFit, Powerlifting"),
                    Description = table.Column<string>(type: "nvarchar(525)", maxLength: 525, nullable: true, comment: "Detailed description of the event, e.g., 'A local competition for intermediate-level CrossFitters.'"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Start date and time of the event"),
                    Location = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false, comment: "Location of the event, e.g., 'Sport Center Victory - Ruse'"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "URL of the event image"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Indicates if the event is deleted (soft delete)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                },
                comment: "Represents an event in the web application, such as a fitness, crossfit or powerlifting competition or training session.");

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(136)", maxLength: 136, nullable: false, comment: "Unique identifier for the exercise - the name in snake case will be the Id."),
                    Name = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false, comment: "Name of the exercise"),
                    Force = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "Type of force applied in the exercise - push, pull, etc."),
                    Mechanic = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, comment: "Mechanic of the exercise - compound, isolation, etc."),
                    Equipment = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: true, comment: "Equipment used for the exercise - barbell, dumbbell, bodyweight, etc."),
                    PrimaryMuscles = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Primary muscles targeted by the exercise."),
                    SecondaryMuscles = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Secondary muscles targeted by the exercise, if any."),
                    Instructions = table.Column<string>(type: "nvarchar(max)", maxLength: 5025, nullable: true, comment: "Instructions on how to perform the exercise."),
                    Category = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Category of the exercise - strength, cardio, flexibility, etc."),
                    ImageUrlOne = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "URL of the first image representing the exercise, if available.."),
                    ImageUrlTwo = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "URL of the second image representing the exercise, if available."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Indicates whether the exercise is deleted or not - soft deletion.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                },
                comment: "Represents an exercise in the database for the web app.");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary Key for the product."),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Title of the product, e.g., 'Weightlifting Belt'."),
                    ProductCategory = table.Column<int>(type: "int", nullable: false, comment: "Category of the product - 'Equipment' or 'Nutrition'."),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Quantity of the product available in stock."),
                    Description = table.Column<string>(type: "nvarchar(525)", maxLength: 525, nullable: true, comment: "Description of the product, providing details about its features and benefits."),
                    Price = table.Column<decimal>(type: "decimal(18,6)", nullable: false, comment: "Price of the product"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "URL of the product image, used for displaying the product in the UI."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Indicates if the product is currently available for purchase. If true, the product is deleted and not available.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                },
                comment: "Represents a product in the web application. Can be an Equipment or a Nutrition product.");

            migrationBuilder.CreateTable(
                name: "WorkoutPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key for the workout plan")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false, comment: "Title of the workout plan, e.g., 'Push/Pull/Legs'"),
                    Description = table.Column<string>(type: "nvarchar(2025)", maxLength: 2025, nullable: false, comment: "Description of the workout plan"),
                    Type = table.Column<int>(type: "int", nullable: false, comment: "Type of the workout plan - 'CrossFit', 'Powerlifting', 'Bodybuilding'"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "Optional image URL for the workout plan"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Indicates if the workout plan is currently active or deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlans", x => x.Id);
                },
                comment: "Workout Plan entity for a structured workout plan for fitness, crossFit or powerlifting");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CrossfitClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "CrossFit Class Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "CrossFit Class Name"),
                    Description = table.Column<string>(type: "nvarchar(2025)", maxLength: 2025, nullable: false, comment: "CrossFit Class Description for details"),
                    StartTime = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "CrossFit Class starting date and time - a string, because it will say in which day of the week will there be classes, ex. Monday 17:00"),
                    TrainerName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, comment: "CrossFit Class Trainer name - can be a Trainer in the Sport Center or a guest Trainer"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indicates if the class is active or not"),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrossfitClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrossfitClasses_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                },
                comment: "CrossFit Class Model");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Unique identifier for the order"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The day in which the order was made"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false, comment: "The total price of the order"),
                    OrderStatus = table.Column<int>(type: "int", nullable: false, comment: "Shows what is the status of the order - "),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false, comment: "Shows the method of payment"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Flag which is used for soft deletion"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the customer who made the order"),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key for the Trainer entity."),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "First name of the trainer."),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Last name of the trainer."),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false, comment: "Email address of the trainer. Must be unique."),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, comment: "Phone number of the trainer. Optional, can be null."),
                    Bio = table.Column<string>(type: "nvarchar(525)", maxLength: 525, nullable: false, comment: "Short biography of the trainer, describing their experience and qualifications."),
                    TrainerSpecialty = table.Column<int>(type: "int", nullable: false, comment: "Specialty of the trainer, indicating their area of expertise (e.g., Fitness, CrossFit, Powerlifting)."),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "URL of the trainer's profile image. Optional, can be null."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Indicates whether the trainer is marked as deleted. Used for soft deletion."),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Foreign key so that the user can be identify as a trainer/coach.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                },
                comment: "Represents a personal trainer in the web application. Can be a fitness, crossfit or powerlifting trainer/coach.");

            migrationBuilder.CreateTable(
                name: "UserFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key for the UserFeedback Table.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The name of the user who provided the feedback."),
                    Feedback = table.Column<string>(type: "nvarchar(2024)", maxLength: 2024, nullable: false, comment: "The context of the feedback."),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "The URL of the image associated with the feedback, if any."),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "The status of the feedback, indicating whether it is pending, publish, or removed. The default will be pending."),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The Foreign key to the User how added the feedback"),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFeedbacks_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserFeedbacks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Represents user feedback in the system.");

            migrationBuilder.CreateTable(
                name: "EventUsers",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the referenced ApplicationUser. Part of the entity composite PK."),
                    EventId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key to the referenced Event. Part of the entity composite PK.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUsers", x => new { x.ApplicationUserId, x.EventId });
                    table.ForeignKey(
                        name: "FK_EventUsers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUsers_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Represents a user who has purchased a membership.");

            migrationBuilder.CreateTable(
                name: "WorkoutPlanExercises",
                columns: table => new
                {
                    ExerciseId = table.Column<string>(type: "nvarchar(136)", nullable: false, comment: "Foreign key to the referenced Exercise. Part of the entity composite PK."),
                    WorkoutPlanId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key to the referenced WorkoutPlan. Part of the entity composite PK.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlanExercises", x => new { x.ExerciseId, x.WorkoutPlanId });
                    table.ForeignKey(
                        name: "FK_WorkoutPlanExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutPlanExercises_WorkoutPlans_WorkoutPlanId",
                        column: x => x.WorkoutPlanId,
                        principalTable: "WorkoutPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Workout Plan Exercise entity representing an exercise within a workout plan");

            migrationBuilder.CreateTable(
                name: "CrossfitClassUsers",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the referenced ApplicationUser. Part of the entity composite PK."),
                    CrossfitClassId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key to the referenced CrossfitClass. Part of the entity composite PK."),
                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time when the user joined the class")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrossfitClassUsers", x => new { x.CrossfitClassId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_CrossfitClassUsers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CrossfitClassUsers_CrossfitClasses_CrossfitClassId",
                        column: x => x.CrossfitClassId,
                        principalTable: "CrossfitClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Represents a many-to-many relationship between ApplicationUser and CrossfitClass.");

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the referenced Order. Part of the entity composite PK."),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the referenced Product. Part of the entity composite PK."),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "The quantity of the product"),
                    Price = table.Column<decimal>(type: "decimal(18,6)", nullable: false, comment: "Price per single unit")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Represents an item in an order, linking a product to an order with quantity and price details");

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary Key for the membership.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Name of the membership"),
                    MembershipType = table.Column<int>(type: "int", nullable: false, comment: "Type of the membership - Fitness, CrossFit, Powerlifting."),
                    MembershipTier = table.Column<int>(type: "int", nullable: false, comment: "Tier of the membership - FitnessStandard, CrossFitUnlimited, PowerliftingBeginners and et."),
                    Description = table.Column<string>(type: "nvarchar(525)", maxLength: 525, nullable: false, comment: "Description of the membership."),
                    Price = table.Column<decimal>(type: "decimal(18,6)", nullable: false, comment: "Price of the membership."),
                    Duration = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Duration of the membership - '1 month', '3 months', '1 year'."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Indicates whether the membership is deleted."),
                    TrainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Foreign Key to the Trainer, who coaches in the membership. If null the membership is a class.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Memberships_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id");
                },
                comment: "Represents a membership in the web application, for the fitness, crossfit and powerlifting.");

            migrationBuilder.CreateTable(
                name: "TrainerUsers",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the referenced ApplicationUser. Part of the entity composite PK."),
                    TrainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the referenced Trainer. Part of the entity composite PK."),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Additional information about which course/membership/plan is the user attached to the trainer")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerUsers", x => new { x.ApplicationUserId, x.TrainerId });
                    table.ForeignKey(
                        name: "FK_TrainerUsers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerUsers_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Entity representing the many-to-many relationship between ApplicationUser and Trainer.");

            migrationBuilder.CreateTable(
                name: "MembershipUsers",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the referenced ApplicationUser. Part of the entity composite PK."),
                    MembershipId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key to the referenced Membership. Part of the entity composite PK."),
                    PurchasedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time when the membership was purchased."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Indicates whether the membership user is deleted. Used for soft deletion.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipUsers", x => new { x.ApplicationUserId, x.MembershipId });
                    table.ForeignKey(
                        name: "FK_MembershipUsers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembershipUsers_Memberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Memberships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Represents a user who has purchased a membership.");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CrossfitClasses_ApplicationUserId",
                table: "CrossfitClasses",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CrossfitClassUsers_ApplicationUserId",
                table: "CrossfitClassUsers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUsers_EventId",
                table: "EventUsers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_TrainerId",
                table: "Memberships",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipUsers_MembershipId",
                table: "MembershipUsers",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_ApplicationUserId",
                table: "Trainers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerUsers_TrainerId",
                table: "TrainerUsers",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFeedbacks_ApplicationUserId",
                table: "UserFeedbacks",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFeedbacks_UserId",
                table: "UserFeedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutPlanExercises_WorkoutPlanId",
                table: "WorkoutPlanExercises",
                column: "WorkoutPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CrossfitClassUsers");

            migrationBuilder.DropTable(
                name: "CrossfitWorkoutOfTheDays");

            migrationBuilder.DropTable(
                name: "EventUsers");

            migrationBuilder.DropTable(
                name: "MembershipUsers");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "TrainerUsers");

            migrationBuilder.DropTable(
                name: "UserFeedbacks");

            migrationBuilder.DropTable(
                name: "WorkoutPlanExercises");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CrossfitClasses");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "WorkoutPlans");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
