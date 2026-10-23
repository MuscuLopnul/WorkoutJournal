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
        }
    }
}