using Microsoft.AspNetCore.Mvc;

namespace TaskBoard.WEB.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult List()
        {
            return View();
        }

        public IActionResult Post()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }
    }
}
