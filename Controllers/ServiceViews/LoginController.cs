using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.ViewsControllers
{
    [Authorize]
    public class LoginController : Controller
    {
        // GET: LoginViewController
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }
    }
}
