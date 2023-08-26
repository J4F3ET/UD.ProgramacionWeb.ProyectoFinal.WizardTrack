using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.ViewsControllers
{
    public class LoginController : Controller
    {
        // GET: LoginViewController
        public IActionResult Index()
        {
            return View();
        }
    }
}
