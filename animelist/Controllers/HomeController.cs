using animelist.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AnimeLibrary.Data;

namespace animelist.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EpicPage()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //Action functions for anime
        public ActionResult DeleteAnime(int animeID)
        {
            DataAccess da = new DataAccess(_logger);
            AnimeModel todelete = da.GetAnimeModel(animeID);

            da.DeleteAnime(todelete);

            return RedirectToAction("GetAnime"); //returns to page of "GetAnime.cshtml"
        }
        public IActionResult GetAnime()
        {
            DataAccess da = new DataAccess(_logger);
            List<AnimeModel> models = da.GetAnimeModels();

            //apply delimiter for anime genres
            foreach (AnimeModel model in models)
            {
                model.animeType = TransformDelimiter(model.animeType);
            }

            return View(models);
        }

        private string TransformDelimiter(string str)
        {
            return str.Replace("~*~", ", ");
        }

        //Action functions for episode
        public IActionResult GetEpisode()
        {
            DataAccess da = new DataAccess(_logger);
            List<EpisodeModel> models = da.GetEpisodeModels();

            return View(models);
        }
        public ActionResult DeleteEpisode(int episodeID)
        {
            //figure out redirect
            DataAccess da = new DataAccess(_logger);
            EpisodeModel todelete = da.GetEpisodeModel(episodeID);

            da.DeleteEpisode(todelete);

            return RedirectToAction("GetEpisode");
        }

        //Action functions for review
        public IActionResult GetReview()
        {
            DataAccess da = new DataAccess(_logger);
            List<ReviewModel> models = da.GetReviewModels();

            return View(models);
        }
        public ActionResult DeleteReview(int reviewID)
        {
            DataAccess da = new DataAccess(_logger);
            ReviewModel todelete = da.GetReviewModel(reviewID);

            da.DeleteReview(todelete);

            return RedirectToAction("GetReview");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}