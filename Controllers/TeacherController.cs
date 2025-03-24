using Microsoft.AspNetCore.Mvc;

namespace Campus_Management_System.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddTeacher()
        {
            return View();
        }
    }
}
