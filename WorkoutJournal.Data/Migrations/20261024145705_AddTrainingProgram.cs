using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutJournal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTrainingProgram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Workouts");
        }
    }
}
