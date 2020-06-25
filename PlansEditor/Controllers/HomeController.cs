using Microsoft.AspNetCore.Mvc;

namespace PlansEditor.Controllers
{
    // todo: how to [Route("/")] ?
    public class HomeController : Controller
    {
        public IActionResult Plan()
        {
            return View();
        }

        public IActionResult Event(int planId)
        {
            ViewBag.PlanId = planId;
            return View();
        }
    }
}