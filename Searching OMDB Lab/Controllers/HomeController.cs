using Microsoft.AspNetCore.Mvc;
using Searching_OMDB_Lab.Models;
using System.Diagnostics;

namespace Searching_OMDB_Lab.Controllers
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
        
        [HttpGet]
        public IActionResult MovieSearch()
        {
            return View();
        }


        [HttpPost]
        public IActionResult MovieSearch(string title)
        {
            List<MovieModel> result = MovieSearchDAL.GetMovie(title);

            return View(result);
        }



        [HttpGet]
        public IActionResult MovieNight()
        {
            return View();
        }


        [HttpPost]
        public IActionResult MovieNight(string title1, string title2, string title3)
        {
            List<MovieModel> result = MovieNightDAL.MovieNight(title1, title2, title3);

            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}