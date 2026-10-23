using WorkoutJournal.Data;
using WorkoutJournal.ViewModels;
using Microsoft.EntityFrameworkCore;
using WorkoutJournal.Data.Models;
using WorkoutJournal.Data.Enums;

namespace WorkoutJournal.Services
{
    public class WorkService : IWorkoutService
    {
        private readonly WorkoutJournalDbContext _context;

        public WorkService(WorkoutJournalDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkoutIndexViewModel>> GetAllWorkouts(string userId)
        {
            var workouts = await _context.Workouts
                .Where(x => x.UserId == userId).ToListAsync();

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

        public async Task CreateWorkout(WorkoutCreateViewModel model, string userId)
        {
            var workout = new Workout
            {
                Date = model.Date,
                Note = model.Note,
                WorkoutStatus = WorkoutStatus.NotStarted,
                UserId = userId
            };

            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
        }
    }
}
