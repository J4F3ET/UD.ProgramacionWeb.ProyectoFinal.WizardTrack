using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.ServiceViews
{
    public class MetricsController : Controller
    {
        // GET: MetricsController
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "");
            }
            return View();
        }

        // GET: MetricsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MetricsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MetricsController/Create
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

        // GET: MetricsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MetricsController/Edit/5
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

        // GET: MetricsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MetricsController/Delete/5
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
