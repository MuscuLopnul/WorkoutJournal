using Microsoft.EntityFrameworkCore;
using WorkoutJournal.Data;
using WorkoutJournal.ViewModels;

namespace WorkoutJournal.Services
{
    public class TrainingProgramService : ITrainingProgramService
    {
        private readonly WorkoutJournalDbContext _context;

        public TrainingProgramService(WorkoutJournalDbContext context)
        {
            _context = context;
        }

        public async Task<List<TrainingProgramViewModel>> GetAllPrograms()
        {
            var programs = await _context.TrainingPrograms.Include(x => x.Exercises).ToListAsync();
            var list = new List<TrainingProgramViewModel>();
            foreach (var program in programs)
            {
                var item = new TrainingProgramViewModel
                {
                    Name = program.Name,
                    Id = program.Id,
                };
                list.Add(item);
            }

            return list;
        }
    }
}
