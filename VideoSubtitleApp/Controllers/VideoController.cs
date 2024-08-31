using Microsoft.AspNetCore.Mvc;
using VideoSubtitleApp.Models;

namespace VideoSubtitleApp.Controllers
{
    public class VideoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VideoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Video/Upload
        public IActionResult Upload()
        {
            return View();
        }

        // POST: Video/Upload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile videoFile, string title)
        {
            if (videoFile != null && videoFile.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/videos", videoFile.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await videoFile.CopyToAsync(stream);
                }

                var video = new Video
                {
                    Title = title,
                    FilePath = filePath,
                    UploadDate = DateTime.Now
                };

                _context.Videos.Add(video);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: Video/Index
        public IActionResult Index()
        {
            var videos = _context.Videos.ToList();
            return View(videos);
        }
    }
}
