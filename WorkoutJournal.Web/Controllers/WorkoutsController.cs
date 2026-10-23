using Microsoft.AspNetCore.Mvc;
using WorkoutJournal.Data;
using Microsoft.EntityFrameworkCore;
using WorkoutJournal.Data.Models;

namespace WorkoutJournal.Controllers
{
    public class WorkoutsController : Controller
    {
        public  async Task<IActionResult> Index()
        {
            var workouts = await _context.Workouts.ToListAsync();
            return View(workouts);
        }

        private readonly WorkoutJournalDbContext _context;

        public WorkoutsController(WorkoutJournalDbContext context)
        {
            _context = context;
        }
       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Workout workout)
        {
            if (!ModelState.IsValid)
            {
                return View(workout);
            }
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
