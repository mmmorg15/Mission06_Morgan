using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Morgan.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Morgan.Controllers
{
    // This is the controller for the home page of the application. It contains actions for displaying the home page, a form for submitting movie information, and a confirmation page after the form is submitted
    public class HomeController : Controller
    {
        private FormContext _context;

        public HomeController(FormContext context)
        {
            _context = context;
        }

        // This action method returns the view for the home page of the application
        public IActionResult Index()
        {
            return View();
        }

        // This action method returns the view for the "Get to Know" page of the application
        public IActionResult GetToKnow()
        {
            return View();
        }


        [HttpGet]
        public IActionResult movieForm()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(new Movie());
        }


       

        [HttpPost]
        public IActionResult movieForm(Movie response)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(c => c.CategoryName)
                    .ToList();
                return View(response);
            }


            _context.Movies.Add(response); // add record to the database
            _context.SaveChanges(); // save the changes to the database
            return View("Confirmation", response);


        }

        public IActionResult MovieTable()
        {
            var movies = _context.Movies
                .Include(m => m.Category)
                .OrderBy(m => m.Title)
                .ToList();
            return View(movies);
        }

        //Edit Get
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
            return View(movie);
        }

        // Edit Post
        [HttpPost]
        public IActionResult Edit(Movie UpdatedMovie)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(c => c.CategoryName)
                    .ToList();
                return View(UpdatedMovie);
            }
            _context.Movies.Update(UpdatedMovie);
            _context.SaveChanges();

            return RedirectToAction("MovieTable");
        }

        // Delete Get
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Category)
                .SingleOrDefault(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // Delete Post
        [HttpPost]
        public IActionResult DeleteConfirmed(int movieId)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.MovieId == movieId);
            if (movie == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("MovieTable");
        }

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
