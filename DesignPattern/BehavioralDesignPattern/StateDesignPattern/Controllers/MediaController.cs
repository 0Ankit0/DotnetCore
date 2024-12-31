using Microsoft.AspNetCore.Mvc;
using StateDesignPattern.Infrastructure;
using StateDesignPattern.Services;

namespace StateDesignPattern.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class MediaController : Controller
    {
        private readonly SongService _songService;
        private static readonly MediaPlayerContext MediaPlayer = new MediaPlayerContext();

        public MediaController(SongService songService)
        {
            _songService = songService;
        }

        public async Task<IActionResult> Index()
        {
            if (MediaPlayer.CurrentMedia == null)
            {
                await MediaPlayer.InitializeAsync(_songService);
            }

            return View(MediaPlayer);
        }

        [HttpPost]
        public JsonResult Play()
        {
            MediaPlayer.Play();
            return Json(new { state = MediaPlayer.CurrentState });
        }

        [HttpPost]
        public JsonResult Pause()
        {
            MediaPlayer.Pause();
            return Json(new { state = MediaPlayer.CurrentState });
        }

        [HttpPost]
        public JsonResult Stop()
        {
            MediaPlayer.Stop();
            return Json(new { state = MediaPlayer.CurrentState });
        }

        [HttpPost]
        public JsonResult Next()
        {
            MediaPlayer.NextTrack();
            return Json(new
            {
                state = MediaPlayer.CurrentState,
                isFirstTrack = MediaPlayer.CurrentMedia == MediaPlayer.MediaFiles.FirstOrDefault(),
                isLastTrack = MediaPlayer.CurrentMedia == MediaPlayer.MediaFiles.LastOrDefault()
            });
        }

        [HttpPost]
        public JsonResult Previous()
        {
            MediaPlayer.PreviousTrack();
            return Json(new
            {
                state = MediaPlayer.CurrentState,
                isFirstTrack = MediaPlayer.CurrentMedia == MediaPlayer.MediaFiles.FirstOrDefault(),
                isLastTrack = MediaPlayer.CurrentMedia == MediaPlayer.MediaFiles.LastOrDefault()
            });
        }

    }

}
