using AppointmentBookinator3000inator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentBookinator3000inator.Controllers
{
    public class LogoutController : Controller
    {
        // GET: LogoutController
        public ActionResult Index()
        {

            UserData.email = null;
            return RedirectToAction( "Index" , "Home" ); ;
        }

        // GET: LogoutController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LogoutController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogoutController/Create
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

        // GET: LogoutController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LogoutController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: LogoutController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LogoutController/Delete/5
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
