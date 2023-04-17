using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

          
        // GET: UserController
        public ActionResult Landing()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            string email = collection["email"];
            string pass = collection["password"];

            if (collection.Keys.Count == 4)
            {
                string username = collection["name"];
                DBHandler.CreateUser(username, email, pass);
            }
            else
            {
                DBHandler.LoginUser(email, pass);
            }

            Console.WriteLine("Posted to Edit");
            try
            {
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Landing(int id, IFormCollection collection)
        {
            string email = collection["email"];
            string pass = collection["password"];

            if (collection.Keys.Count == 4)
            {
                string username = collection["name"];
                DBHandler.CreateUser(username, email, pass);
            }
            else
            {
                DBHandler.LoginUser(email, pass);
            }

            Console.WriteLine("Posted to Edit");
            try
            {
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
