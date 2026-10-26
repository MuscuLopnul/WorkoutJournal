namespace WorkoutJournal.ViewModels
{
    public class TrainingProgramExerciseViewModel
    {
        public int Id { get; set; }

        public int ExerciseTypeId { get; set; }

        public string ExerciseType { get; set; }

        public int Sets { get; set; }

        public int Reps { get; set; }

        public decimal Weight { get; set; }
    }
}
