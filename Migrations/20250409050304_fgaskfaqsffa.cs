using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApplication.Migrations
{
    /// <inheritdoc />
    public partial class fgaskfaqsffa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonalInformationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonalInformationId",
                table: "AspNetUsers");
        }
    }
}
