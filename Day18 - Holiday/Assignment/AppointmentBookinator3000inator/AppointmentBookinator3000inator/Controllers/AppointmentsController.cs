using AppointmentBookinator3000inator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentBookinator3000inator.Controllers
{
    public class AppointmentsController : Controller
    {
        public static List<AppointmentModel> appointments;
        // GET: AppointmentsController1
        public ActionResult Index()
        {
            if (Request.HasFormContentType)
            {
                string id = Request.Form["id"];
                string title = Request.Form["title"];
                string individual = Request.Form["individual"];
                string start = Request.Form["start"];
                string end = Request.Form["end"];
                appointments = DBHandler.FetchAppointments( id , title , individual , start , end );
            }
            else {
                appointments = DBHandler.FetchAppointments();
            }

            return View( appointments );
        }

        // GET: AppointmentsController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AppointmentsController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppointmentsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                string title = collection["title"];
                string individual = collection["individual"];
                DateTime start_time = DateTime.Parse(collection["start"]);
                DateTime end_time = DateTime.Parse(collection["end"]);

                bool success = DBHandler.CreateAppointment( title , individual , start_time , end_time );

                if ( !success )
                {
                    AppointmentModel.isCreated = false;
                    return RedirectToAction(nameof(Create));
                }
                AppointmentModel.isCreated = true;
                return RedirectToAction(nameof(Index));
            }
            catch( Exception ex )
            {
                Console.WriteLine(ex.Message);
                AppointmentModel.isCreated = false;
                return View();
            }
        }

        // GET: AppointmentsController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View( appointments.Find(x => x.id == id) );
        }

        // POST: AppointmentsController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                string title = collection["title"];
                string individual = collection["individual"];
                DateTime start_time = DateTime.Parse(collection["start"]);
                DateTime end_time = DateTime.Parse(collection["end"]);

                bool success = DBHandler.AlterAppointment( id , title, individual, start_time, end_time);

                if (!success)
                {
                    AppointmentModel.isCreated = false;
                    return RedirectToAction(nameof(Create));
                }
                AppointmentModel.isCreated = true;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                AppointmentModel.isCreated = false;
                return View();
            }

        }

        // GET: AppointmentsController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View(appointments.Find(x => x.id == id));
        }

        // POST: AppointmentsController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                DBHandler.DeleteAppointment( id );
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
