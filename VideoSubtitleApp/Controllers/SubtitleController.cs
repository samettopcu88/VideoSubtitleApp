using Microsoft.AspNetCore.Mvc;
using VideoSubtitleApp.Models;

namespace VideoSubtitleApp.Controllers
{
    public class SubtitleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubtitleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Subtitle/Create
        public IActionResult Create(int videoId)
        {
            ViewBag.VideoId = videoId;
            return View();
        }

        // POST: Subtitle/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Subtitle subtitle)
        {
            if (ModelState.IsValid)
            {
                _context.Subtitles.Add(subtitle);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Video");
            }
            return View(subtitle);
        }

        // GET: Subtitle/Edit/5
        public IActionResult Edit(int id)
        {
            var subtitle = _context.Subtitles.Find(id);
            if (subtitle == null)
            {
                return NotFound();
            }
            return View(subtitle);
        }

        // POST: Subtitle/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Subtitle subtitle)
        {
            if (id != subtitle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(subtitle);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Video");
            }
            return View(subtitle);
        }
    }
}
