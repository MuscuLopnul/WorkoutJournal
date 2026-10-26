using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkoutJournal.Data.Models;

namespace WorkoutJournal.Data
{
    public class WorkoutJournalDbContext : IdentityDbContext<IdentityUser>
    {
        public WorkoutJournalDbContext(DbContextOptions<WorkoutJournalDbContext> options)
         : base(options)
        {
        }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseType> ExerciseTypes { get; set; }
        public DbSet<TrainingProgram> TrainingPrograms { get; set; }
        public DbSet<TrainingProgramExercise> TrainingProgramExercises { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Workout>()
                .HasMany(w => w.Exercises)
                .WithOne(e => e.Workout)
                .HasForeignKey(e => e.WorkoutId);

            builder.Entity<Workout>()
                .HasOne(w => w.User)
                .WithMany()
                .HasForeignKey(w => w.UserId);

            builder.Entity<Exercise>()
                .HasOne(e => e.Workout)
                .WithMany(w => w.Exercises)
                .HasForeignKey(e => e.WorkoutId);

            builder.Entity<Exercise>()
                .HasOne(e => e.ExerciseType)
                .WithMany()
                .HasForeignKey(e => e.ExerciseTypeId);

            builder.Entity<TrainingProgram>()
                .HasMany(w => w.Exercises)
                .WithOne(e => e.TrainingProgram)
                .HasForeignKey(e => e.TrainingProgramId);

            var exerciseTypes = new List<ExerciseType>
            {
                new ExerciseType { Id = 1, Name = "Bench Press" },
                new ExerciseType { Id = 2, Name = "Incline Dumbbell Press" },
                new ExerciseType { Id = 3, Name = "Shoulder Press" },
                new ExerciseType { Id = 4, Name = "Bicep Curl" },
                new ExerciseType { Id = 5, Name = "Hammer Curl" },
                new ExerciseType { Id = 6, Name = "Tricep Extension" },
                new ExerciseType { Id = 7, Name = "Barbell Squat" },
                new ExerciseType { Id = 8, Name = "Leg Press" },
                new ExerciseType { Id = 9, Name = "Romanian Deadlift" },
                new ExerciseType { Id = 10, Name = "Deadlift" },
                new ExerciseType { Id = 11, Name = "Lat Pulldown" },
                new ExerciseType { Id = 12, Name = "Barbell Row" },
                new ExerciseType { Id = 13, Name = "Dumbbell Row" },
                new ExerciseType { Id = 14, Name = "Chest Fly" },
                new ExerciseType { Id = 15, Name = "Lateral Raise" },
                new ExerciseType { Id = 16, Name = "Leg Curl" },
                new ExerciseType { Id = 17, Name = "Leg Extension" },
                new ExerciseType { Id = 18, Name = "Calf Raise" },
                new ExerciseType { Id = 19, Name = "Hip Thrust" },
                new ExerciseType { Id = 20, Name = "Weighted Lunges" }
            };

            builder.Entity<ExerciseType>().HasData(exerciseTypes);

            builder.Entity<TrainingProgram>().HasData(
                new TrainingProgram { Id = 1, Name = "Full Body Workout" },
                new TrainingProgram { Id = 2, Name = "Upper Body Workout" },
                new TrainingProgram { Id = 3, Name = "Leg Day" },
                new TrainingProgram { Id = 4, Name = "Push Day" },
                new TrainingProgram { Id = 5, Name = "Pull Day" },
                new TrainingProgram { Id = 6, Name = "Strength Training" }
            );

            builder.Entity<TrainingProgramExercise>().HasData(
                new TrainingProgramExercise
                {
                    Id = 1,
                    ExerciseTypeId = 1,
                    Sets = 3,
                    Reps = 10,
                    Weight = 40,
                    TrainingProgramId = 1
                },
                new TrainingProgramExercise
                {
                    Id = 2,
                    ExerciseTypeId = 2,
                    Sets = 4,
                    Reps = 8,
                    Weight = 60,
                    TrainingProgramId = 1
                },
                new TrainingProgramExercise
                {
                    Id = 3,
                    ExerciseTypeId = 3,
                    Sets = 3,
                    Reps = 8,
                    Weight = 80,
                    TrainingProgramId = 1
                },
                new TrainingProgramExercise
                {
                    Id = 4,
                    ExerciseTypeId = 4,
                    Sets = 3,
                    Reps = 10,
                    Weight = 30,
                    TrainingProgramId = 2
                },
                new TrainingProgramExercise
                {
                    Id = 5,
                    ExerciseTypeId = 5,
                    Sets = 3,
                    Reps = 12,
                    Weight = 35,
                    TrainingProgramId = 2
                },
                new TrainingProgramExercise
                {
                    Id = 6,
                    ExerciseTypeId = 6,
                    Sets = 3,
                    Reps = 12,
                    Weight = 10,
                    TrainingProgramId = 2
                },
                new TrainingProgramExercise
                {
                    Id = 7,
                    ExerciseTypeId = 2,
                    Sets = 4,
                    Reps = 10,
                    Weight = 60,
                    TrainingProgramId = 3
                },
                new TrainingProgramExercise
                {
                    Id = 8,
                    ExerciseTypeId = 3,
                    Sets = 3,
                    Reps = 8,
                    Weight = 80,
                    TrainingProgramId = 3
                },
                new TrainingProgramExercise
                {
                    Id = 9,
                    ExerciseTypeId = 1,
                    Sets = 3,
                    Reps = 12,
                    Weight = 30,
                    TrainingProgramId = 3
                },
                new TrainingProgramExercise
                {
                    Id = 10,
                    ExerciseTypeId = 1,
                    Sets = 4,
                    Reps = 8,
                    Weight = 50,
                    TrainingProgramId = 4
                },
                new TrainingProgramExercise
                {
                    Id = 11,
                    ExerciseTypeId = 4,
                    Sets = 3,
                    Reps = 10,
                    Weight = 25,
                    TrainingProgramId = 4
                },
                new TrainingProgramExercise
                {
                    Id = 12,
                    ExerciseTypeId = 6,
                    Sets = 3,
                    Reps = 12,
                    Weight = 10,
                    TrainingProgramId = 4
                },
                new TrainingProgramExercise
                {
                    Id = 13,
                    ExerciseTypeId = 5,
                    Sets = 4,
                    Reps = 10,
                    Weight = 35,
                    TrainingProgramId = 5
                },
                new TrainingProgramExercise
                {
                    Id = 14,
                    ExerciseTypeId = 3,
                    Sets = 3,
                    Reps = 8,
                    Weight = 70,
                    TrainingProgramId = 5
                },
                new TrainingProgramExercise
                {
                    Id = 15,
                    ExerciseTypeId = 6,
                    Sets = 3,
                    Reps = 12,
                    Weight = 12,
                    TrainingProgramId = 5
                },
                new TrainingProgramExercise
                {
                    Id = 16,
                    ExerciseTypeId = 1,
                    Sets = 4,
                    Reps = 6,
                    Weight = 60,
                    TrainingProgramId = 6
                },
                new TrainingProgramExercise
                {
                    Id = 17,
                    ExerciseTypeId = 2,
                    Sets = 4,
                    Reps = 6,
                    Weight = 80,
                    TrainingProgramId = 6
                },
                new TrainingProgramExercise
                {
                    Id = 18,
                    ExerciseTypeId = 3,
                    Sets = 3,
                    Reps = 6,
                    Weight = 100,
                    TrainingProgramId = 6
                });
        }
    }
}