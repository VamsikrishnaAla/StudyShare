using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore; // Required for ToListAsync() and other EF Core async methods


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebApplication1Context _context;

        // Constructor to inject the database context
        public HomeController(WebApplication1Context context)
        {
            _context = context;
        }


        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}
        // public IActionResult findresource()
        public async Task<IActionResult> FindResource()

        {
            var resources = await _context.StudyShare.ToListAsync();

            return View(resources);
        }

        public IActionResult shareresource()
        {
            return View();
        }
        public IActionResult charts()
        {
            return View();
        }

//        public IActionResult FindResource()
//{
//    var resources = _context.StudyShare.ToList(); // Assuming you have a DbContext with StudyShares table
//    return View(resources);
//}


        public IActionResult about_us()
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
