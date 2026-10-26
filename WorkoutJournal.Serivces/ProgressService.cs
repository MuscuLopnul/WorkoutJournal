using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WorkoutJournal.Common.Enums;
using WorkoutJournal.Data;
using WorkoutJournal.ViewModels;

namespace WorkoutJournal.Services
{
    public class ProgressService : IProgressService
    {
        private readonly WorkoutJournalDbContext _context;

        public ProgressService(WorkoutJournalDbContext context)
        {
            _context = context;
        }

        public async Task<List<MonthlyProgressViewModel>> GetProgress(string userId)
        {
            var workouts = await _context.Workouts
               .Where(x => x.UserId == userId)
               .OrderByDescending(x => x.Date)
               .ToListAsync();

            var grouped = workouts.GroupBy(d => d.Date.Month);

            var list = new List<MonthlyProgressViewModel>();
            foreach (var group in grouped)
            {
                if (group.Any())
                {
                    var firstItemOfTheGroup = group.FirstOrDefault();
                    var item = new MonthlyProgressViewModel
                    {
                        MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(group.Key),
                        Year = firstItemOfTheGroup!.Date.Year,
                        NumberOfCompleted = group.Count(x => x.WorkoutStatus == WorkoutStatus.Completed),
                        NumberOfNotStarted = group.Count(x => x.WorkoutStatus == WorkoutStatus.NotStarted),
                        NumberOfSkipped = group.Count(x => x.WorkoutStatus == WorkoutStatus.Skipped),
                        NumberOfPartiallyCompleted = group.Count(x => x.WorkoutStatus == WorkoutStatus.PartiallyCompleted),
                    };
                    list.Add(item);
                }
            }

            return list;
        }
    }
}
