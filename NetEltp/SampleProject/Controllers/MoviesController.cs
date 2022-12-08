using Microsoft.AspNetCore.Mvc;
using SampleProject.Models;

namespace SampleProject.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            var movie = new Movie() {Name="IronMan"};
           /* ViewData["Movie"] = movie;  
            ViewBag.Movie= movie;*/
            return View(movie);
        }
    }
}
