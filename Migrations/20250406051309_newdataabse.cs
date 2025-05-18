using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApplication.Migrations
{
    /// <inheritdoc />
    public partial class newdataabse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietPlan");

            migrationBuilder.CreateTable(
                name: "BodyMeasurement",
                columns: table => new
                {
                    MeasurementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WeightKg = table.Column<float>(type: "real", nullable: false),
                    WaistCm = table.Column<float>(type: "real", nullable: false),
                    ChestCm = table.Column<float>(type: "real", nullable: false),
                    HipCm = table.Column<float>(type: "real", nullable: false),
                    BMI = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyMeasurement", x => x.MeasurementId);
                    table.ForeignKey(
                        name: "FK_BodyMeasurement_PersonalInformation_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionLog",
                columns: table => new
                {
                    NutritionLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MealType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    Calories = table.Column<float>(type: "real", nullable: false),
                    ProteinGrams = table.Column<float>(type: "real", nullable: false),
                    CarbGrams = table.Column<float>(type: "real", nullable: false),
                    FatGrams = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionLog", x => x.NutritionLogId);
                    table.ForeignKey(
                        name: "FK_NutritionLog_PersonalInformation_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecommendDietAndExercisePlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    DietName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DietPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExerciseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExercisePlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExeDuration = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendDietAndExercisePlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecommendDietAndExercisePlan_PersonalInformation_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutLog",
                columns: table => new
                {
                    WorkoutLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    ExerciseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    CaloriesBurned = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutLog", x => x.WorkoutLogId);
                    table.ForeignKey(
                        name: "FK_WorkoutLog_PersonalInformation_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyMeasurement_PersonalInformationId",
                table: "BodyMeasurement",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionLog_PersonalInformationId",
                table: "NutritionLog",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendDietAndExercisePlan_PersonalInformationId",
                table: "RecommendDietAndExercisePlan",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLog_PersonalInformationId",
                table: "WorkoutLog",
                column: "PersonalInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyMeasurement");

            migrationBuilder.DropTable(
                name: "NutritionLog");

            migrationBuilder.DropTable(
                name: "RecommendDietAndExercisePlan");

            migrationBuilder.DropTable(
                name: "WorkoutLog");

            migrationBuilder.CreateTable(
                name: "DietPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalGoalId = table.Column<int>(type: "int", nullable: false),
                    AgeGroupId = table.Column<int>(type: "int", nullable: false),
                    BodyGoalId = table.Column<int>(type: "int", nullable: false),
                    BodyTypeId = table.Column<int>(type: "int", nullable: false),
                    ProblemAreaId = table.Column<int>(type: "int", nullable: true),
                    StepDietId = table.Column<int>(type: "int", nullable: false),
                    StepWaterId = table.Column<int>(type: "int", nullable: false),
                    StepWorkoutId = table.Column<int>(type: "int", nullable: false),
                    WorkoutFrequencyId = table.Column<int>(type: "int", nullable: false),
                    SuggestedDiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetBodyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DietPlan_AdditionalGoal_AdditionalGoalId",
                        column: x => x.AdditionalGoalId,
                        principalTable: "AdditionalGoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietPlan_AgeGroup_AgeGroupId",
                        column: x => x.AgeGroupId,
                        principalTable: "AgeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietPlan_BodyGoal_BodyGoalId",
                        column: x => x.BodyGoalId,
                        principalTable: "BodyGoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietPlan_BodyType_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalTable: "BodyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietPlan_ProblemArea_ProblemAreaId",
                        column: x => x.ProblemAreaId,
                        principalTable: "ProblemArea",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DietPlan_StepDiet_StepDietId",
                        column: x => x.StepDietId,
                        principalTable: "StepDiet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietPlan_StepWater_StepWaterId",
                        column: x => x.StepWaterId,
                        principalTable: "StepWater",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietPlan_StepWorkout_StepWorkoutId",
                        column: x => x.StepWorkoutId,
                        principalTable: "StepWorkout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietPlan_WorkoutFrequency_WorkoutFrequencyId",
                        column: x => x.WorkoutFrequencyId,
                        principalTable: "WorkoutFrequency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DietPlan_AdditionalGoalId",
                table: "DietPlan",
                column: "AdditionalGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_DietPlan_AgeGroupId",
                table: "DietPlan",
                column: "AgeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DietPlan_BodyGoalId",
                table: "DietPlan",
                column: "BodyGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_DietPlan_BodyTypeId",
                table: "DietPlan",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DietPlan_ProblemAreaId",
                table: "DietPlan",
                column: "ProblemAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_DietPlan_StepDietId",
                table: "DietPlan",
                column: "StepDietId");

            migrationBuilder.CreateIndex(
                name: "IX_DietPlan_StepWaterId",
                table: "DietPlan",
                column: "StepWaterId");

            migrationBuilder.CreateIndex(
                name: "IX_DietPlan_StepWorkoutId",
                table: "DietPlan",
                column: "StepWorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_DietPlan_WorkoutFrequencyId",
                table: "DietPlan",
                column: "WorkoutFrequencyId");
        }
    }
}
