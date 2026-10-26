using WorkoutJournal.ViewModels;

namespace WorkoutJournal.Services
{
    public interface IWorkoutService
    {
        Task<List<WorkoutIndexViewModel>> GetAllWorkouts(string userId);
        Task CreateWorkout(WorkoutCreateViewModel model, string userId);
        Task<WorkoutEditViewModel> GetWorkout(int workoutId);
        Task EditWorkout(WorkoutEditViewModel model);
        Task DeleteWorkout(int id);

    }
}
