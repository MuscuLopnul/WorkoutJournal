using System.ComponentModel.DataAnnotations;
using WorkoutJournal.Data.Enums;

namespace WorkoutJournal.Data.Models
{
    public class Workout
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [StringLength(5, MinimumLength = 500)]
        public string? Note { get; set; }

        public ICollection<Exercise> Exercises { get; set; } = [];

        [Required]
        public WorkoutStatus WorkoutStatus { get; set; }
    }
}
