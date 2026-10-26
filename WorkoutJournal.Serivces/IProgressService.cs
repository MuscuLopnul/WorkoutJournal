using WorkoutJournal.ViewModels;

namespace WorkoutJournal.Services
{
    public interface IProgressService
    {
        Task<List<MonthlyProgressViewModel>> GetProgress(string userId);
    }
}
