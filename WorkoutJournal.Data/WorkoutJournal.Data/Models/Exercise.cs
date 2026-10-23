using System.ComponentModel.DataAnnotations;

namespace WorkoutJournal.Data.Models
{
    public class Exercise
    {
     
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
