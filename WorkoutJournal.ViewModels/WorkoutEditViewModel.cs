using System.ComponentModel.DataAnnotations;
using WorkoutJournal.Common.Enums;

namespace WorkoutJournal.ViewModels
{
    public class WorkoutEditViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string? Note { get; set; }

        public List<WorkoutEditExerciseViewModel> Exercises { get; set; } = [];

        public WorkoutStatus WorkoutStatus { get; set; }
    }

    public class WorkoutEditExerciseViewModel
    {
        public int Id { get; set; }

        public int ExerciseTypeId { get; set; }

        public int Sets { get; set; }

        public int Reps { get; set; }

        public decimal Weight { get; set; }
    }
}
