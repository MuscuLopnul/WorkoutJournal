using WorkoutJournal.ViewModels;

namespace WorkoutJournal.Services
{
    public interface ITrainingProgramService
    {
        Task<List<TrainingProgramViewModel>> GetAllPrograms();

    }
}
