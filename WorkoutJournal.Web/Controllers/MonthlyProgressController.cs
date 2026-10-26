using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorkoutJournal.Services;

namespace WorkoutJournal.Controllers
{
    [Authorize]
    public class MonthlyProgressController : Controller
    {
        private readonly IProgressService _service;

        public MonthlyProgressController(IProgressService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var progress = await _service.GetProgress(GetUserId());
            return View(progress);
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        }
    }
}
