using Microsoft.AspNetCore.Mvc;
using WorkoutJournal.Services;
using WorkoutJournal.ViewModels;

namespace WorkoutJournal.Controllers
{
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
            var workouts = await _service.GetAllWorkouts();
            return View(workouts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkoutIndexViewModel workout)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(workout);
            //}
            //_context.Workouts.Add(workout);
            //await _context.SaveChangesAsync();
            await Task.Delay(1);
            return RedirectToAction(nameof(Index));
        }
    }
}
