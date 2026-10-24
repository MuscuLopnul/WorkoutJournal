using Microsoft.EntityFrameworkCore;
using WorkoutJournal.Common.Enums;
using WorkoutJournal.Data;
using WorkoutJournal.Data.Models;
using WorkoutJournal.ViewModels;

namespace WorkoutJournal.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly WorkoutJournalDbContext _context;

        public WorkoutService(WorkoutJournalDbContext context)
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
                    Id = workout.Id,
                    Name = workout.Date.DayOfWeek.ToString(),
                    WorkoutStatus = workout.WorkoutStatus.ToString()
                };
                list.Add(item);
            }

            return list;
        }

        public async Task<WorkoutEditViewModel> GetWorkout(int workoutId)
        {
            var workout = await _context.Workouts
                .Include(x => x.Exercises)
                .FirstOrDefaultAsync(x => x.Id == workoutId);
            var model = new WorkoutEditViewModel();
            model.Id = workout.Id;
            model.Date = workout.Date;
            model.Note = workout.Note;
            model.WorkoutStatus = workout.WorkoutStatus;
            model.Exercises = new List<WorkoutEditExerciseViewModel>();
            foreach (var exercise in workout.Exercises)
            {
                var item = new WorkoutEditExerciseViewModel
                {
                    Id = exercise.Id,
                    ExerciseTypeId = exercise.ExerciseTypeId,
                    Sets = exercise.Sets,
                    Reps = exercise.Reps,
                    Weight = exercise.Weight,
                };
                model.Exercises.Add(item);
            }

            return model;
        }

        public async Task CreateWorkout(WorkoutCreateViewModel model, string userId)
        {
            var trainingProgram = await _context
                .TrainingPrograms
                .Include(x => x.Exercises)
                .FirstOrDefaultAsync(x => x.Id == model.TrainingProgramId);

            var exercises = new List<Exercise>();
            foreach (var trainingProgramExercise in trainingProgram.Exercises)
            {
                var item = new Exercise
                {
                    Reps = trainingProgramExercise.Reps,
                    Sets = trainingProgramExercise.Sets,
                    ExerciseTypeId = trainingProgramExercise.ExerciseTypeId,
                    Weight = trainingProgramExercise.Weight
                };
                exercises.Add(item);
            }

            var workout = new Workout
            {
                Date = model.Date,
                Note = model.Note,
                WorkoutStatus = WorkoutStatus.NotStarted,
                UserId = userId,
                Exercises = exercises
            };

            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
        }

        public async Task EditWorkout(WorkoutEditViewModel model)
        {
            var workout = await _context.Workouts.Include(x => x.Exercises).FirstOrDefaultAsync(x => x.Id == model.Id);
            if (workout == null)
            {
                return;
            }
            
            workout.Date = workout.Date;
            workout.Note = workout.Note;
            workout.WorkoutStatus = workout.WorkoutStatus;
            
            foreach (var exercise in workout.Exercises)
            {
                var newExercise = model.Exercises.FirstOrDefault(x => x.Id == exercise.Id);
                if(newExercise != null)
                {
                    exercise.ExerciseTypeId = newExercise.ExerciseTypeId;
                    exercise.Reps = newExercise.Reps;
                    exercise.Sets = newExercise.Sets;
                    exercise.Weight = newExercise.Weight;
                }
            }

            _context.Workouts.Update(workout);
            await _context.SaveChangesAsync();
        }
    }
}
