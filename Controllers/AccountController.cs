using Microsoft.AspNetCore.Mvc;

namespace Campus_Management_System.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "Admin" && password == "Admin123")
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "InValid Username Or Password";
                return View();
            }
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index", "Home");
        }
    }
}
