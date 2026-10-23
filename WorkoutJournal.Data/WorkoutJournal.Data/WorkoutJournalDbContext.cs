using Microsoft.EntityFrameworkCore;
using WorkoutJournal.Data.Models;

namespace WorkoutJournal.Data
{
    public class WorkoutJournalDbContext : DbContext
    {
        public WorkoutJournalDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    }
}