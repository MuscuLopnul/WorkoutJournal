using System.ComponentModel.DataAnnotations;

namespace WorkoutJournal.ViewModels
{
    public class WorkoutCreateViewModel
    {
        [Required]
        public DateTime Date { get; set; }

        public string? Note { get; set; }

        public int TrainingProgramId { get; set; }
    }
}
