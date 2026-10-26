namespace WorkoutJournal.ViewModels
{
    public class MonthlyProgressViewModel
    {
        public string MonthName { get; set; }
        public int Year { get; set; }
        public int NumberOfCompleted { get; set; }
        public int NumberOfSkipped { get; set; }
        public int NumberOfNotStarted { get; set; }
        public int NumberOfPartiallyCompleted { get; set; }

        public int TotalWorkout => NumberOfCompleted + NumberOfSkipped + NumberOfNotStarted + NumberOfPartiallyCompleted;
    }
}
