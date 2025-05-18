using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApplication.Migrations
{
    /// <inheritdoc />
    public partial class faskfahgaz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasurementDate",
                table: "HealthLog");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "HealthLog",
                newName: "WaterIntake");

            migrationBuilder.RenameColumn(
                name: "MealType",
                table: "HealthLog",
                newName: "Supplements");

            migrationBuilder.RenameColumn(
                name: "LogType",
                table: "HealthLog",
                newName: "StepTaken");

            migrationBuilder.RenameColumn(
                name: "FoodItem",
                table: "HealthLog",
                newName: "SetsOrReps");

            migrationBuilder.AddColumn<bool>(
                name: "AlcoholConsumed",
                table: "HealthLog",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "JunkConsumed",
                table: "HealthLog",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonalRatings",
                table: "HealthLog",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlcoholConsumed",
                table: "HealthLog");

            migrationBuilder.DropColumn(
                name: "JunkConsumed",
                table: "HealthLog");

            migrationBuilder.DropColumn(
                name: "PersonalRatings",
                table: "HealthLog");

            migrationBuilder.RenameColumn(
                name: "WaterIntake",
                table: "HealthLog",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Supplements",
                table: "HealthLog",
                newName: "MealType");

            migrationBuilder.RenameColumn(
                name: "StepTaken",
                table: "HealthLog",
                newName: "LogType");

            migrationBuilder.RenameColumn(
                name: "SetsOrReps",
                table: "HealthLog",
                newName: "FoodItem");

            migrationBuilder.AddColumn<DateOnly>(
                name: "MeasurementDate",
                table: "HealthLog",
                type: "date",
                nullable: true);
        }
    }
}
