using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorkoutJournal.Services;
using WorkoutJournal.ViewModels;

namespace WorkoutJournal.Controllers
{
    [Authorize]
    public class WorkoutsController : Controller
    {
        private readonly IWorkoutService _service;
        private readonly ITrainingProgramService _trainingProgramService;
        private readonly IExerciseTypeService _exerciseTypeService;

        public WorkoutsController(IWorkoutService service, ITrainingProgramService trainingProgramService, IExerciseTypeService exerciseTypeService)
        {
            _service = service;
            _trainingProgramService = trainingProgramService;
            _exerciseTypeService = exerciseTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var workouts = await _service.GetAllWorkouts(GetUserId());
            return View(workouts);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.TrainingPrograms = await _trainingProgramService.GetAllPrograms();
            return View(new WorkoutCreateViewModel()
            {
                Date = DateTime.Now,
            });
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            ViewBag.ExerciseTypes = await _exerciseTypeService.GetAll();
            var workout = await _service.GetWorkout(id);
            return View(workout);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WorkoutEditViewModel workout)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ExerciseTypes = await _exerciseTypeService.GetAll();
                return View(workout);
            }

            await _service.EditWorkout(workout);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkoutCreateViewModel workout)
        {
            if(workout.Date.Date < DateTime.Today)
            {
                ModelState.AddModelError("Date", "Date cannot be in the past!");
            }
          
            if (!ModelState.IsValid)
            {
                ViewBag.TrainingPrograms = await _trainingProgramService.GetAllPrograms();
                return View(workout);
            }

            await _service.CreateWorkout(workout, GetUserId());
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteWorkout(id);
            return RedirectToAction(nameof(Index));
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        }
    }
}
