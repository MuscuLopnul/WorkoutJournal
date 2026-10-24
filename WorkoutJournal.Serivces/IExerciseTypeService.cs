using WorkoutJournal.ViewModels;

namespace WorkoutJournal.Services
{
    public interface IExerciseTypeService
    {
        Task<List<ExerciseTypeViewModel>> GetAll();

    }
}