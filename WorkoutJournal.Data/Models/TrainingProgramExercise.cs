using System.ComponentModel.DataAnnotations;

namespace WorkoutJournal.Data.Models
{
    public class TrainingProgramExercise
    {
        public int Id { get; set; }

        [Required]
        public int ExerciseTypeId { get; set; }

        public ExerciseType ExerciseType { get; set; }

        [Required]
        [Range(1, 6)]
        public int Sets { get; set; }

        [Required]
        [Range(1, 20)]
        public int Reps { get; set; }

        [Required]
        [Range(0.5, 500)]
        public decimal Weight { get; set; }

        [Required]
        public int TrainingProgramId { get; set; }

        public TrainingProgram TrainingProgram { get; set; }
    }
}
