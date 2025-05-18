using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApplication.Migrations
{
    /// <inheritdoc />
    public partial class nullableremoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietPlan_AdditionalGoal_AdditionalGoalId",
                table: "DietPlan");

            migrationBuilder.AlterColumn<int>(
                name: "AdditionalGoalId",
                table: "DietPlan",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DietPlan_AdditionalGoal_AdditionalGoalId",
                table: "DietPlan",
                column: "AdditionalGoalId",
                principalTable: "AdditionalGoal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietPlan_AdditionalGoal_AdditionalGoalId",
                table: "DietPlan");

            migrationBuilder.AlterColumn<int>(
                name: "AdditionalGoalId",
                table: "DietPlan",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DietPlan_AdditionalGoal_AdditionalGoalId",
                table: "DietPlan",
                column: "AdditionalGoalId",
                principalTable: "AdditionalGoal",
                principalColumn: "Id");
        }
    }
}
