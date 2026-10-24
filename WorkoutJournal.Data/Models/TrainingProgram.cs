using System.ComponentModel.DataAnnotations;

namespace WorkoutJournal.Data.Models
{
    public class TrainingProgram
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<TrainingProgramExercise> Exercises { get; set; }
    }
}

// Biceps progrram: 10 chest, 20 pushups 