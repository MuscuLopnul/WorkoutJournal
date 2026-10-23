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

        public WorkoutsController(IWorkoutService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var workouts = await _service.GetAllWorkouts(GetUserId());
            return View(workouts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new WorkoutCreateViewModel()
            {
                Date = DateTime.Now,
            });
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
