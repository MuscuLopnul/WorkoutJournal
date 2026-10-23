using System.ComponentModel.DataAnnotations;

namespace WorkoutJournal.Data.Models
{
    public class ExerciseType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

// 1 - Bench press
// 2 - Dambles
// 3 - Batterfly