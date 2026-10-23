using System.ComponentModel.DataAnnotations;

namespace WorkoutJournal.Data.Models
{
    public class Workout
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }
        public string? Notes { get; set; }
    }
}
