using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkoutJournal.Data.Enums;

namespace WorkoutJournal.Data.Models
{
    public class Workout
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [StringLength(500, MinimumLength = 5)]
        public string? Note { get; set; }

        public ICollection<Exercise> Exercises { get; set; } = [];

        [Required]
        public WorkoutStatus WorkoutStatus { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
    }
}
