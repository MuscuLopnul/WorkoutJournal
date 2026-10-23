using System.ComponentModel.DataAnnotations;

namespace WorkoutJournal.Data.Models
{
    public class WorkoutExercise
    {
        public int Id { get; set; }
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }
        public Workout Workout { get; set; } = null!;
        public Exercise Exercise { get; set; } = null!;
        [Range(1,6)]
        public int Sets { get; set; }     
        [Range(1,20)]
        public int Reps { get; set; }
        [Range(0.5,500)]
        public decimal Weight { get; set; }
    }
}
