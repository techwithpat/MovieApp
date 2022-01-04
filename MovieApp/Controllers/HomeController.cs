using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Models;
using MovieApp.ViewModels;
using System.Diagnostics;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieDataContext context;

        public HomeController(MovieDataContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var movies = this.context.Movies.Include(m => m.Actors).Select( m => new MovieViewModel 
            {
                Title = m.Title,
                Year = m.Year.ToString(),
                Summary = m.Summary,
                Actors = string.Join(',', m.Actors.Select(a => a.Fullname))
            });

            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}