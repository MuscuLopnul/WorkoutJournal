using WorkoutJournal.Data;
using WorkoutJournal.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace WorkoutJournal.Services
{
    public class WorkService : IWorkoutService
    {
        private readonly WorkoutJournalDbContext _context;

        public WorkService(WorkoutJournalDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkoutIndexViewModel>> GetAllWorkouts()
        {
            var workouts = await _context.Workouts.ToListAsync();

            var list = new List<WorkoutIndexViewModel>();
            foreach (var workout in workouts)
            {
                var item = new WorkoutIndexViewModel
                {
                    Name = workout.Date.DayOfWeek.ToString(),
                };
                list.Add(item);
            }

            return list;
        }
    }
}
