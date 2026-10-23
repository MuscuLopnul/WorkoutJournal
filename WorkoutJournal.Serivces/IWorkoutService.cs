using WorkoutJournal.ViewModels;

namespace WorkoutJournal.Services
{
    public interface IWorkoutService
    {
        Task<List<WorkoutIndexViewModel>> GetAllWorkouts();
    }
}
