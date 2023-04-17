using Assessment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assessment.Controllers
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
            if ( UserData.email == null )
            { 
                return RedirectToAction("Landing" , "User");
            }

            return View(DBHandler.FetchFiles());
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            string filename = collection["filename"];
            DBHandler.CreateFile(filename);
            return RedirectToAction( "Index" , "Home" );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            DBHandler.DeleteFile(id);
            return RedirectToAction("Index" , "Home" );
        }

        public ActionResult Delete(int id)
        {
            DBHandler.DeleteFile(id);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            FileModel file = DBHandler.GetFile(id);
            Console.WriteLine("File Name : " + file.filename);
            return View(file);
        }

        public ActionResult Edit(int id)
        {
            return View(DBHandler.GetFile(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            string filename = collection["filename"];
            string content = collection["content"];
            DBHandler.UpdateFile(id , content , filename);
            return RedirectToAction("Index", "Home");
        }

    }
}