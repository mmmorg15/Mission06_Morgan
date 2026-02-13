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

        // This action method returns the view for the movie form page of the application when a GET request is made. It allows users to access the form to submit movie information
        [HttpGet]
        public IActionResult movieForm()
        {
            return View();
        }

        // This action method handles the submission of the movie form when a POST request is made. It checks if the submitted model is valid, and if so, it adds the movie information to the database and saves the changes. If the model is not valid, it returns the view with the response model to show validation errors
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult movieForm(movieFormModel response)
        {
            if (!ModelState.IsValid) // check if the model state is valid
                return View(response); // if not, return the view with the response model to show validation errors

                _context.movies.Add(response); // add record to the database
                _context.SaveChanges(); // save the changes to the database
                return View("Confirmation", response);
            
            
        }

    }
}
