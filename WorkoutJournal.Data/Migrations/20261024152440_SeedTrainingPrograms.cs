using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkoutJournal.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedTrainingPrograms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TrainingPrograms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Full Body Workout" },
                    { 2, "Upper Body Workout" },
                    { 3, "Leg Day" },
                    { 4, "Push Day" },
                    { 5, "Pull Day" },
                    { 6, "Strength Training" }
                });

            migrationBuilder.InsertData(
                table: "TrainingProgramExercises",
                columns: new[] { "Id", "ExerciseTypeId", "Reps", "Sets", "TrainingProgramId", "Weight" },
                values: new object[,]
                {
                    { 1, 1, 10, 3, 1, 40m },
                    { 2, 2, 8, 4, 1, 60m },
                    { 3, 3, 8, 3, 1, 80m },
                    { 4, 4, 10, 3, 2, 30m },
                    { 5, 5, 12, 3, 2, 35m },
                    { 6, 6, 12, 3, 2, 10m },
                    { 7, 2, 10, 4, 3, 60m },
                    { 8, 3, 8, 3, 3, 80m },
                    { 9, 1, 12, 3, 3, 30m },
                    { 10, 1, 8, 4, 4, 50m },
                    { 11, 4, 10, 3, 4, 25m },
                    { 12, 6, 12, 3, 4, 10m },
                    { 13, 5, 10, 4, 5, 35m },
                    { 14, 3, 8, 3, 5, 70m },
                    { 15, 6, 12, 3, 5, 12m },
                    { 16, 1, 6, 4, 6, 60m },
                    { 17, 2, 6, 4, 6, 80m },
                    { 18, 3, 6, 3, 6, 100m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrainingProgramExercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrainingProgramExercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrainingProgramExercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TrainingProgramExercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TrainingProgramExercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TrainingProgramExercises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TrainingProgramExercises",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TrainingProgramExercises",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TrainingProgramExercises",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TrainingProgramExercises",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TrainingProgramExercises",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TrainingProgramExercises",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TrainingProgramExercises",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TrainingProgramExercises",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TrainingProgramExercises",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TrainingProgramExercises",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TrainingProgramExercises",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TrainingProgramExercises",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TrainingPrograms",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
