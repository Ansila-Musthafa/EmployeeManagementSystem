using Employee_Mangement_system.Models;
using Microsoft.AspNetCore.Mvc;
using Model_Layer;

namespace Employee_Mangement_system.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login loginDetails)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7086")
            };
            var postTask = client.PostAsJsonAsync("api/Admin/login", loginDetails);
            postTask.Wait();
            var Result = postTask.Result;
            if (!Result.IsSuccessStatusCode)
            {
                return BadRequest("User wrong");
            }
            return RedirectToAction("dashboard", "Home");
        }



       
        public IActionResult Register(AdminRegistrationMvc registerDetails)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7086")
            };
            var postTask = client.PostAsJsonAsync("api/Admin/register", registerDetails);
            postTask.Wait();
            var Result = postTask.Result;
            if (Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
           
        }
        public IActionResult LogOut()
        {
            return RedirectToAction("Login", "Admin");
        }
    }
}
