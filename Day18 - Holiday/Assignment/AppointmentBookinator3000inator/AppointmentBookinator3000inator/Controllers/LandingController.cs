using AppointmentBookinator3000inator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentBookinator3000inator.Controllers
{
    public class LandingController : Controller
    {
        // GET: LandingController
        public ActionResult Index()
        {
            return View();
        }

        // POST: LandingController/Index/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int id, IFormCollection collection)
        {
            string email =  collection["email"];
            string pass = collection["password"];

            if ( collection.Keys.Count == 4 )
            { 
                string username = collection["name"];
                DBHandler.CreateUser(username , email, pass);
            }
            else {
                DBHandler.LoginUser(email, pass);
            }

            Console.WriteLine("Posted to Edit");
            try
            {
                return RedirectToAction("Index" , "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: LandingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LandingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LandingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LandingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LandingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Console.WriteLine( "Posted to Edit" );
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LandingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LandingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
