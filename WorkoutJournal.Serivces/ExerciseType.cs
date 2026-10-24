using Microsoft.EntityFrameworkCore;
using WorkoutJournal.Data;
using WorkoutJournal.ViewModels;

namespace WorkoutJournal.Services
{
    public class ExerciseTypeService : IExerciseTypeService
    {
        private readonly WorkoutJournalDbContext _context;

        public ExerciseTypeService(WorkoutJournalDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExerciseTypeViewModel>> GetAll()
        {
            var exerciseTypes = await _context.ExerciseTypes.ToListAsync();

            var list = new List<ExerciseTypeViewModel>();
            foreach (var exerciseType in exerciseTypes)
            {
                var item = new ExerciseTypeViewModel
                {
                    Id = exerciseType.Id,
                    Name = exerciseType.Name
                };
                list.Add(item);
            }

            return list;
        }

    }
}