using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApplication.Migrations
{
    /// <inheritdoc />
    public partial class FJAGSFJASF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyMeasurement");

            migrationBuilder.DropTable(
                name: "NutritionLog");

            migrationBuilder.DropTable(
                name: "WorkoutLog");

            migrationBuilder.CreateTable(
                name: "HealthLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExerciseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationMinutes = table.Column<int>(type: "int", nullable: true),
                    CaloriesBurned = table.Column<float>(type: "real", nullable: true),
                    MealType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<float>(type: "real", nullable: true),
                    Calories = table.Column<float>(type: "real", nullable: true),
                    ProteinGrams = table.Column<float>(type: "real", nullable: true),
                    CarbGrams = table.Column<float>(type: "real", nullable: true),
                    FatGrams = table.Column<float>(type: "real", nullable: true),
                    MeasurementDate = table.Column<DateOnly>(type: "date", nullable: true),
                    WeightKg = table.Column<float>(type: "real", nullable: true),
                    WaistCm = table.Column<float>(type: "real", nullable: true),
                    ChestCm = table.Column<float>(type: "real", nullable: true),
                    HipCm = table.Column<float>(type: "real", nullable: true),
                    BMI = table.Column<float>(type: "real", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthLog_PersonalInformation_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthLog_PersonalInformationId",
                table: "HealthLog",
                column: "PersonalInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthLog");

            migrationBuilder.CreateTable(
                name: "BodyMeasurement",
                columns: table => new
                {
                    MeasurementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    BMI = table.Column<float>(type: "real", nullable: false),
                    ChestCm = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HipCm = table.Column<float>(type: "real", nullable: false),
                    WaistCm = table.Column<float>(type: "real", nullable: false),
                    WeightKg = table.Column<float>(type: "real", nullable: false)
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
                    Calories = table.Column<float>(type: "real", nullable: false),
                    CarbGrams = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FatGrams = table.Column<float>(type: "real", nullable: false),
                    FoodItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MealType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProteinGrams = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false)
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
                name: "WorkoutLog",
                columns: table => new
                {
                    WorkoutLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                    CaloriesBurned = table.Column<float>(type: "real", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    ExerciseName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "IX_WorkoutLog_PersonalInformationId",
                table: "WorkoutLog",
                column: "PersonalInformationId");
        }
    }
}
