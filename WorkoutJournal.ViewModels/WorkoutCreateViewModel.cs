using System.ComponentModel.DataAnnotations;

namespace WorkoutJournal.ViewModels
{
    public class WorkoutCreateViewModel
    {
        public DateTime Date { get; set; }

        public string? Note { get; set; }
    }
}
