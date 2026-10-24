using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorkoutJournal.Data.Models;
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
                return View(workout);
            }

            await _service.EditWorkout(workout);
            ViewBag.ExerciseTypes = await _exerciseTypeService.GetAll();
            return View(workout);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkoutCreateViewModel workout)
        {
            if (!ModelState.IsValid)
            {
                return View(workout);
            }

            await _service.CreateWorkout(workout, GetUserId());
            return RedirectToAction(nameof(Index));
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        }
    }
}
